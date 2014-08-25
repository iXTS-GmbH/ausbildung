using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TextFileLines.Test
{
    [TestFixture]
    public class TextFileMapperTests
    {
        [TestCaseSource("TextFileMapperTestSource")]
        public void TextFileMapperTest(TextFileMapper textFileMapper, String inputFileName, List<String> expected )
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
                new object[]{new ToUpperLine(),"ToUpperTest",
                    new List<String> {
                        "DAS IST EIN TEST.",
                        "WENN DIESER TEST ERFOLGREICH IST,",
                        "KANN MAN DIESE ZEILEN",
                        "IN CAPS LESEN." 
                }},

                new object[]{new DeleteEmptyLines(),"EmptyLineTest", 
                    new List<String>{
                        "Das ist ein Test,",
                        "welcher abdeckt ob",
                        "leere Zeilen",
                        
                        "richtig interpretiert werden."
                }},

                new object[]{new DeleteSameLines(), "SameLineTest",
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
            var testStream = new TestStreamFactory();
            textFileMapper.Map("Test",null,testStream);
        }
    }
}
