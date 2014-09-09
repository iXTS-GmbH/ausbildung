using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ixts.Ausbildung.TextFileLines.Test
{
    [TestFixture]
    public class TextFileSplitterTests
    {
        [TestCase("splitterTest","split")]
        public void TextFileSplitterTest(String input,String splitPoint)
        {
            var textFileSplitter = new TextSplitter();
            textFileSplitter.SetSplitPoint(splitPoint);

            var expected = new []
                {
                    new []{"Das ist ein Testfile","split"}, 
                    new []{"Das ist ein zweites Testfile","split"},
                    new []{"Das ist ein mehrzeiliges","drittes split Testfile"} 
                };

            var testStream = new TestStreamFactory();

            textFileSplitter.Split(input,testStream); 

            var actual = testStream.Make(input);
            var output = actual.GetOutput();

            Assert.AreEqual(expected,output);
        }

        [TestCase("BigFile")]
        public void BigTextFileSplitterTest(String input)
        {
            var textFileSplitter = new TextSplitter();
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
