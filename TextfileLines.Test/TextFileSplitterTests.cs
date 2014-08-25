using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TextFileLines.Test
{
    [TestFixture]
    public class TextFileSplitterTests
    {
        [TestCaseSource("TextFileSplitterTestSource")]
        public void TextFileSplitterTest(TextFileSplitter textFileSplitter, String input, String[][] expected)
        {
            var testStream = new TestFileStreamFactory();
            var lineStream = new TestStreamFactory();
            textFileSplitter.Split(input,testStream, lineStream); 
            var actual = testStream.Make(input);
            var output = actual.GetOutput();

            Assert.AreEqual(expected.Length,output.Length);

            for (var i = 0; i < output.Length; i++)
            {
                for (var j = 0; j < output[i].Length; j++)
                {
                   Assert.AreEqual(expected[i][j],output[i][j]); 
                }
            }
        }

        private static readonly object[] TextFileSplitterTestSource =
            {
                new object[]{new SplitTextFile(),"input",
                    new []{
                      new []{"Das ist ein Testfile","break"}, 
                      new []{"Das ist ein zweites Testfile","break"},
                      new []{"Das ist ein mehrzeiliges","drittes Testfile"} 
                    }
                } 
            };
    }
}
