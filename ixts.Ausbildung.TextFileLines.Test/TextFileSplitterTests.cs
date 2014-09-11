using System;
using System.Collections.Generic;
using NUnit.Framework;
using ixts.Ausbildung.TextfileLines;
using ixts.Ausbildung.TextfileLines.Test;

namespace ixts.Ausbildung.TextFileLines.Test
{
    [TestFixture]
    public class TextFileSplitterTests
    {

        [TestCase("BigFile")]
        public void BigTextFileSplitterTest(String input)
        {
            var textFileSplitter = new TextSplitter();
            var expected = new List<String[]>();

            for (var i = 0; i < 100; i++)
            {
                expected.Add(new[] { "Das ist ein großes TestFile", "break" });
            }

            var teststream = new TestStreamFactory();

            textFileSplitter.Split(input, teststream);

            teststream.Make(input);

            var actual = TestStream.OutputFiles.ToArray();
            TestStream.OutputFiles = new List<String[]>();

            Assert.AreEqual(expected.ToArray(), actual);
        }
    }
}
