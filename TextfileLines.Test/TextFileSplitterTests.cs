﻿using System;
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
            var textFileSplitter = new SplitTextFile();
            var expected = new []
                {
                    new []{"Das ist ein Testfile","break"}, 
                    new []{"Das ist ein zweites Testfile","break"},
                    new []{"Das ist ein mehrzeiliges","drittes Testfile"} 
                };

            var testStream = new TestFileStreamFactory();

            textFileSplitter.Split("splitterTest",testStream); 

            var actual = testStream.Make("splitterTest");
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

        [TestCase]
        public void BigTextFileSplitterTest()
        {
            var textFileSplitter = new SplitTextFile();
            var input = "BigFile";
            var expected = new List<String[]>();

            for (var i = 0; i < 101; i++)
            {
                expected.Add(new [] { "Das ist ein großes TestFile", "break" });
            }

            var teststream = new TestFileStreamFactory();

            textFileSplitter.Split(input, teststream);

            var actual = teststream.Make(input);
            var output = actual.GetOutput();

            Assert.AreEqual(expected.Count, output.Length);

            for (var i = 0; i < output.Length; i++)
            {
                for (var j = 0; j < output[i].Length; j++)
                {
                    Assert.AreEqual(expected[i][j], output[i][j]);
                }
            }
        }
    }
}
