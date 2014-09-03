using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TextFileLines.Test
{
    [TestFixture]
    public class TextFileSplitterTests
    {
        [TestCase]
        public void TextFileSplitterTest()
        {
            var textFileSplitter = new TextSplitter();
            textFileSplitter.SetSplitPoint("split");

            var expected = new []
                {
                    new []{"Das ist ein Testfile","split"}, 
                    new []{"Das ist ein zweites Testfile","split"},
                    new []{"Das ist ein mehrzeiliges","drittes split Testfile"} 
                };

            var testStream = new TestStreamFactory();

            textFileSplitter.Split("splitterTest",testStream); 

            var actual = testStream.Make("splitterTest");
            var output = actual.GetOutput();

            Assert.AreEqual(expected,output);
        }

        [TestCase]
        public void BigTextFileSplitterTest()
        {
            var textFileSplitter = new TextSplitter();
            var input = "BigFile";
            var expected = new List<String[]>();

            for (var i = 0; i < 101; i++)
            {
                expected.Add(new [] { "Das ist ein großes TestFile", "break" });
            }

            var teststream = new TestStreamFactory();

            textFileSplitter.Split(input, teststream);

            var actual = teststream.Make(input);
            var output = actual.GetOutput();

            Assert.AreEqual(expected.ToArray(),output);
        }
    }
}
