using System;
using System.Collections.Generic;
using NUnit.Framework;
using ixts.Ausbildung.TextfileLines;
using ixts.Ausbildung.TextfileLines.Test;


namespace ixts.Ausbildung.TextFileLines.Test
{
    [TestFixture]
    public class TextFileLinesTests
    {
        [TestCase("LinesTest")]
        public void TextfileLinesTest(String path)
        {
            var expected = new List<String>
                {
                    "Das ist ein Test.",
                    "Wenn dieser Test erfolgreich ist,",
                    "kann man diese Zeilen",
                    "in einer List<String> lesen."
                };

            var textFileLines = new TextFileLine(path, new TestStreamFactory());
            var counter = 0;

            foreach (var line in textFileLines)
            {
                Assert.AreEqual(expected[counter], line);
                counter += 1;
            }
        }
    }
}
