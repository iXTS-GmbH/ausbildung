using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TextfileLines.Test
{
    [TestFixture]
    public class TextfileLinesTests
    {
        [TestCaseSource("TextfileLinesTestSource")]
        public void TextfileLinesTest(List<String> expected, String path)
        {
            var r = new TextfileLines(path,new TestStreamReaderFactory());
            var count = 0;

            foreach (var line in r)
            {
                Assert.AreEqual(expected[count],line);
                count += 1;
            }
        }


        public static readonly object[] TextfileLinesTestSource =
            {
                new object[]{new List<String> {"Das ist ein Test.","Wenn dieser Test erfolgreich ist,","kann man diese Zeilen","in einer List<String> lesen."}, "Test"},
                new object[]{new List<String> {"Das ist ein Test,","welcher abdeckt ob","","leere Zeilen","richtig interpretiert werden."}, "NullTest"}
            };
    }
}
