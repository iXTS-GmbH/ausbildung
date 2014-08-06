using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TextfileLines.Test
{
    [TestFixture]
    class TextfileMapperTests
    {
        [TestCaseSource("TextFileMapperTestSource")]
        public void TextFileMapperTest(ITextFileMapper s, String inputPath, List<String> expected )
        {
            var tSt = new TestStreamFactory();
            s.Map(inputPath,"outputPath", tSt);
            var actual = new TestStreamFactory().Make("WriteTest", "outputpath");
            foreach (var line in expected)
            {
                Assert.AreEqual(line, actual.ReadLine());
            }
        }

        public static readonly object[] TextFileMapperTestSource =
            {
                new object[]{new TransformTestToUpper(),"Test",
                    new List<String> {
                        "DAS IST EIN TEST.",
                        "WENN DIESER TEST ERFOLGREICH IST,",
                        "KANN MAN DIESE ZEILEN",
                        "IN EINER LIST<STRING> LESEN." 
                }},

                new object[]{new TransformTestDeleteEmptyLines(),"NullTest", 
                    new List<String>{
                        "Das ist ein Test,",
                        "welcher abdeckt ob",
                        "leere Zeilen",
                        "richtig interpretiert werden."
                    }},

                new object[]{new TransformTestSameLines(), "SameLineTest",
                    new List<String>{
                        "Diese Zeile kommt mehrfach hintereinander",
                        "Diese auch"
                }}
            };
    }

    public class TransformTestToUpper : TextfileMapper
    {

        public override string Transform(string line)
        {
            return line.ToUpper();
        }
    }

    public class TransformTestDeleteEmptyLines : TextfileMapper
    {
        public override string Transform(string line)
        {
            if (String.IsNullOrEmpty(line))
            {
                return null;
            }
            return line;
        }
    }

    public class TransformTestSameLines : TextfileMapper
    {
        private String lastLine;
        public override string Transform(string line)
        {
            if (line.Equals(lastLine))
            {
                return null;
            }
            lastLine = line;
            return line;
        }
    }

}
