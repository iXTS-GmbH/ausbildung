using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TextFileLines.Test
{
    [TestFixture]
    public class TextFileMapperTests
    {
        [TestCaseSource("MapperTestsSource")]
        public void MapperTests(TextFileMapper textFileMapper, List<String> expected, String input)
        {
            var testStream = new TestStreamFactory();

            textFileMapper.Map(input,"outputFileName", testStream);

            var actual = testStream.Make("WriteTest", "outputFileName");

            foreach (var line in expected)
            {
                Assert.AreEqual(line, actual.ReadLine());
            }
        }

        private static readonly object[] MapperTestsSource =
            {
                new object[]{new ToUpperLineMapper(),new List<String>
                    {
                        "DAS IST EIN TEST.",
                        "WENN DIESER TEST ERFOLGREICH IST,",
                        "KANN MAN DIESE ZEILEN",
                        "IN CAPS LESEN."
                    },
                    "ToUpperLineMapperTest"},
                new object[]{new ToLowerLineMapper(),new List<String>
                    {
                        "das ist ein test.",
                        "wenn dieser test erfolgreich ist,",
                        "kann man diese zeilen",
                        "in kleinschreibung lesen"
                    },
                    "ToLowerLineMapperTest"}, 

                new object[]{new RemoveEmptyLinesMapper(),new List<String>
                    {
                        "Dies ist ein Test",
                        "um zu schauen ob Leerzeilen",
                        "korrekt entfernt werden"
                    },
                    "RemoveEmptyLinesMapperTest"},

                new object[]{new RemoveDuplicateLinesMapper(), new List<String>
                    {
                        "Diese Zeile kommt doppelt",
                        "Diese auch",
                        "Diese nicht"
                    },
                    "RemoveDuplicateLinesMapperTest"},
                new object[]{new ToNumberLinesMapper(), new List<String>
                    {
                        "1 Das ist die erste Zeile.",
                        "2 Das ist die zweite Zeile.",
                        "3 Das ist die dritte Zeile."
                    },
                    "ToNumberLinesMapperTest"}
            };


        [ExpectedException]
        [TestCase]
        public void NoOutputFileTest()
        {
            var textFileMapper = new NoOutputFile();
            var testStream = new TestStreamFactory();

            textFileMapper.Map("Test",null,testStream);
        }
    }
}
