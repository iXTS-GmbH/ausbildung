﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;

namespace Palmmedia.ReportGenerator.Parser.Preprocessing.CodeAnalysis
{
    /// <summary>
    /// Represents method information extracted from a PartCover report.
    /// This class is used to compensate a deficiency of PartCover 2.3.0.35109.
    /// PartCover does not record coverage information for unexecuted methods any more.
    /// To provide correct reports the line numbers are determined from the source code files instead of
    /// PartCover's coverage information.
    /// </summary>
    internal class PartCoverMethodElement : SourceElement
    {
        /// <summary>
        /// The delimiters between parameters.
        /// </summary>
        private static readonly string[] ParameterDelimiter = new string[] { ", " };

        /// <summary>
        /// Dictionary containing some type mappings.
        /// </summary>
        private static readonly Dictionary<string, string> TypeReplacements = InitializeTypeReplacements();

        /// <summary>
        ///  The name of the method.
        /// </summary>
        private readonly string methodname;

        /// <summary>
        /// The return type of the method.
        /// </summary>
        private readonly string returnType;

        /// <summary>
        /// The parameters extracted from the method signature contained in the report generated by PartCover.
        /// </summary>
        private readonly string[] parameters;

        /// <summary>
        /// Initializes a new instance of the <see cref="PartCoverMethodElement"/> class.
        /// </summary>
        /// <param name="classname">The name of the class.</param>
        /// <param name="methodname">The name of the method.</param>
        /// <param name="signature">The signature of the method.</param>
        public PartCoverMethodElement(string classname, string methodname, string signature)
            : base(classname)
        {
            if (methodname == null)
            {
                throw new ArgumentNullException("methodname");
            }

            if (signature == null)
            {
                throw new ArgumentNullException("signature");
            }

            this.methodname = methodname;

            var match = Regex.Match(signature, @"(?<returnType>^\S*).*\((?<arguments>.*)\)", RegexOptions.Compiled);
            this.returnType = match.Groups["returnType"].Value;
            this.parameters = match.Groups["arguments"].Value.Split(ParameterDelimiter, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Gets a value indicating whether this method is a constructor.
        /// </summary>
        private bool IsConstructor
        {
            get
            {
                return this.methodname == ".ctor";
            }
        }

        /// <summary>
        /// Determines whether the given <see cref="ICSharpCode.NRefactory.PatternMatching.INode"/> matches the <see cref="SourceElement"/>.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>
        /// A <see cref="SourceElementPosition"/> or <c>null</c> if <see cref="SourceElement"/> does not match the <see cref="ICSharpCode.NRefactory.PatternMatching.INode"/>.
        /// </returns>
        public override SourceElementPosition GetSourceElementPosition(INode node)
        {
            if (this.IsConstructor)
            {
                ConstructorDeclaration constructorDeclaration = node as ConstructorDeclaration;

                if (constructorDeclaration != null)
                {
                    if (!this.DoesMethodnameMatch(constructorDeclaration.Name)
                        || !this.AreParametersMatching(constructorDeclaration.Parameters))
                    {
                        return null;
                    }

                    if (constructorDeclaration.Body != null)
                    {
                        return new SourceElementPosition(constructorDeclaration.Body.StartLocation.Line, constructorDeclaration.Body.EndLocation.Line);
                    }
                }

                return null;
            }

            MethodDeclaration methodDeclaration = node as MethodDeclaration;
            if (methodDeclaration != null)
            {
                if (!this.DoesMethodnameMatch(methodDeclaration.Name)
                    || !AreTypesEqual(this.returnType, methodDeclaration.ReturnType)
                    || !this.AreParametersMatching(methodDeclaration.Parameters))
                {
                    return null;
                }

                if (methodDeclaration.Body != null)
                {
                    return new SourceElementPosition(methodDeclaration.Body.StartLocation.Line, methodDeclaration.Body.EndLocation.Line);
                }
            }

            return null;
        }

        /// <summary>
        /// Determines whether the types are equal.
        /// </summary>
        /// <param name="expectedType">The expected type.</param>
        /// <param name="typeReference">The type reference.</param>
        /// <returns><c>true</c> if parameters are equal, otherwise <c>false</c>.</returns>
        private static bool AreTypesEqual(string expectedType, AstType typeReference)
        {
            SimpleType simpleType = typeReference as SimpleType; // Generic types

            if (simpleType != null)
            {
                if (simpleType.TypeArguments.Count == 1)
                {
                    typeReference = simpleType.TypeArguments.First();
                }
                else if (simpleType.TypeArguments.Count >= 2)
                {
                    // This can't be handled correctly
                    return true;
                }
            }

            ComposedType composedType = typeReference as ComposedType; // Arrays

            if (composedType != null)
            {
                if (!expectedType.EndsWith("[]", StringComparison.Ordinal))
                {
                    return false;
                }
                else
                {
                    expectedType = expectedType.Replace("[]", string.Empty);
                    typeReference = composedType.BaseType;
                }
            }

            if (expectedType.StartsWith("ref ", StringComparison.Ordinal))
            {
                expectedType = expectedType.Replace("ref ", string.Empty);
            }

            string typeReplacement;
            if (TypeReplacements.TryGetValue(expectedType, out typeReplacement))
            {
                expectedType = typeReplacement;
            }

            // Validate
            string typeName = typeReference.ToString();
            if (expectedType.Equals(typeName, StringComparison.OrdinalIgnoreCase)
                || ("System." + expectedType).Equals(typeName, StringComparison.OrdinalIgnoreCase)
                || expectedType.Substring(expectedType.LastIndexOf('.') + 1).Equals(typeName, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Initializes the type replacements.
        /// </summary>
        /// <returns>The type replacements.</returns>
        private static Dictionary<string, string> InitializeTypeReplacements()
        {
            var typeReplacements = new Dictionary<string, string>();
            typeReplacements.Add("unsigned byte", "byte");
            typeReplacements.Add("byte", "sbyte");
            typeReplacements.Add("unsigned short", "ushort");
            typeReplacements.Add("unsigned int", "uint");
            typeReplacements.Add("unsigned long", "ulong");

            return typeReplacements;
        }

        /// <summary>
        /// Determines whether all parameters match.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns><c>true</c> if all parameters are equal, otherwise <c>false</c>.</returns>
        private bool AreParametersMatching(ICollection<ParameterDeclaration> parameters)
        {
            if (this.parameters.Length != parameters.Count)
            {
                return false;
            }

            for (int i = 0; i < parameters.Count; i++)
            {
                if (!AreTypesEqual(this.parameters[i], parameters.ElementAt(i).Type))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines whether the method name matches.
        /// </summary>
        /// <param name="methodname">The name of the method.</param>
        /// <returns><c>true</c> if method names are equal, otherwise <c>false</c>.</returns>
        private bool DoesMethodnameMatch(string methodname)
        {
            if (this.IsConstructor)
            {
                string classname = this.Classname.Substring(this.Classname.LastIndexOf('.') + 1); // Remove namespace declaration
                return classname.Equals(methodname);
            }
            else
            {
                return this.methodname.Equals(methodname);
            }
        }
    }
}
