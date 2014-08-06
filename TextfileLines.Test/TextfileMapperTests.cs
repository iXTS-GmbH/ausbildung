using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TextFileLines.Test
{
    [TestFixture]
    public class TextFileMapperTests
    {
        [TestCaseSource("TextFileMapperTestSource")]
        public void TextFileMapperTest(ITextFileMapper textFileMapper, String inputPath, List<String> expected )
        {
            var testStream = new TestStreamFactory();

            textFileMapper.Map(inputPath,"outputPath", testStream);

            var actual = testStream.Make("WriteTest", "outputpath");

            foreach (var line in expected)
            {
                Assert.AreEqual(line, actual.ReadLine());
            }
        }

        //TODO Test für möglichkeit schreiben das outputFilename null ist und trotzdem .writeLine aufgerufen wird

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
    }
}
