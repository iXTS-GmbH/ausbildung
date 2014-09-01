using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TextFileLines.Test
{
    [TestFixture]
    public class TextFileLinesTests//TODO Source in Test hochziehen
    {
        [TestCaseSource("TextFileLinesTestSource")]
        public void TextfileLinesTest(List<String> expected, String path)
        {
            var textFileLines = new TextFileLines(path,new TestStreamFactory());
            var counter = 0;

            foreach (var line in textFileLines)
            {
                Assert.AreEqual(expected[counter],line);
                counter += 1;
            }
        }

        public static readonly object[] TextFileLinesTestSource =
            {
                new object[]{
                        new List<String>{
                            "Das ist ein Test.",
                            "Wenn dieser Test erfolgreich ist,",
                            "kann man diese Zeilen",
                            "in einer List<String> lesen."
                        },"LinesTest"}
            };
    }
}
