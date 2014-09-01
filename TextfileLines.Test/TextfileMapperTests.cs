using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TextFileLines.Test
{
    [TestFixture]
    public class TextFileMapperTests
    {
        [TestCase]
        public void TextFileMapperTest()
        {
            var textFileMapper = new ToUpperLine();
            var expected = new List<String>
                {
                    "DAS IST EIN TEST.",
                    "WENN DIESER TEST ERFOLGREICH IST,",
                    "KANN MAN DIESE ZEILEN",
                    "IN CAPS LESEN."
                };

            var testStream = new TestStreamFactory();

            textFileMapper.Map("MapperTest","outputFileName", testStream);

            var actual = testStream.Make("WriteTest", "outputFileName");

            foreach (var line in expected)
            {
                Assert.AreEqual(line, actual.ReadLine());
            }
        }

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
