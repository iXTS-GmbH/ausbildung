﻿using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TextFileLines.Test
{
    [TestFixture]
    public class TextFileMapperTests
    {
        [TestCaseSource("TextFileMapperTestSource")]
        public void TextFileMapperTest(ITextFileMapper textFileMapper, String inputFileName, List<String> expected )
        {
            var testStream = new TestStreamFactory();

            textFileMapper.Map(inputFileName,"outputFileName", testStream);

            var actual = testStream.Make("WriteTest", "outputFileName");

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

                new object[]{new TransformTestDeleteEmptyLines(),"EmptyLineTest", 
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

        [ExpectedException]
        [TestCase]
        public void NoOutputFileTest()
        {
            var textFileMapper = new NoOutputFileTest();
            textFileMapper.Map("Test",null);
        }
    }
}
