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
            //var textFileMapper = new ToUpperLineMapper();
            //var expected = new List<String>
            //    {
            //        "DAS IST EIN TEST.",
            //        "WENN DIESER TEST ERFOLGREICH IST,",
            //        "KANN MAN DIESE ZEILEN",
            //        "IN CAPS LESEN."
            //    };"MapperTest"

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
                new object[]{new ToUpperLineMapper(),new List<String>{"DAS IST EIN TEST.","WENN DIESER TEST ERFOLGREICH IST,","KANN MAN DIESE ZEILEN","IN CAPS LESEN."},"ToUpperLineMapperTest"},
                new object[]{new RemoveEmptyLinesMapper(),new List<String>{"Dies ist ein Test", "um zu schauen ob Leerzeilen","korrekt entfernt werden"},"RemoveEmptyLinesMapperTest"},
                new object[]{new RemoveDuplicateLinesMapper(), new List<String>{"Diese Zeile kommt doppelt","Diese auch","Diese nicht"},"RemoveDuplicateLinesMapperTest"}
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
