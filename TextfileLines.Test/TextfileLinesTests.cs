using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TextfileLines.Test
{
    [TestFixture]
    public class TextfileLinesTests
    {
        [TestCase]
        public void TextfileLinesTest()
        {
            var expected = new List<String> {"Das ist ein Test.","Wenn dieser Test erfolgreich ist,","kann man diese Zeilen","in einer List<String> lesen."};
            var r = new TextfileLines("Test.txt",new TestStreamReaderFactory());
            var count = 0;

            foreach (var line in r)
            {
                Assert.AreEqual(expected[count],line);
                count += 1;
            }
        }

    }
}
