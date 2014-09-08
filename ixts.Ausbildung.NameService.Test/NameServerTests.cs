using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ixts.Ausbildung.NameService.Test
{

    [TestFixture]
    public class NameServerTests
    {
        private NameServer sut;
        private TestSocket testSocket;

        [SetUp]
        public void SetUp()
        {
            var testSocketFactory = new TestSocketFactory();
            var testStreamFactory = new TestStreamFactory();
            sut = new NameServer(2000,testSocketFactory,testStreamFactory);
            testSocket = new TestSocket();
        }

        [TestCase]
        public void PutTest()
        {
            TestStream.Map = new Dictionary<String, String>();

            var expected = new List<String>
                {
                    "1 ",
                    "1 firstValue",
                    "1 "
                };

            testSocket.SetTestProtokoll("PutTest");
            sut.Loop();
            var actual = TestSocket.Output;
            TestSocket.Output = new List<String>();

            Assert.AreEqual(expected,actual);
        }

        [TestCase]
        public void GetTest()
        {
            TestStream.Map = new Dictionary<String, String>();

            var expected = new List<String>
                {
                    "1 ",
                    "1 firstValue",
                    "1 "
                };

            testSocket.SetTestProtokoll("GetTest");
            sut.Loop();
            var actual = TestSocket.Output;
            TestSocket.Output = new List<String>();

            Assert.AreEqual(expected,actual);

        }

        [TestCase]
        public void DelTest()
        {
            TestStream.Map = new Dictionary<String, String>();

            var expected = new List<String>
                {
                    "1 ",
                    "1 firstValue",
                    "0",
                    "1 "
                };
            testSocket.SetTestProtokoll("DelTest");
            TestSocket.Output = new List<String>();
            sut.Loop();
            var actual = TestSocket.Output;
            TestSocket.Output = new List<String>();

            Assert.AreEqual(expected,actual);
        }

        [TestCase]
        public void StopTest()
        {
            TestStream.Map = new Dictionary<String, String>();

            testSocket.SetTestProtokoll("StopTest");
            sut.Loop();
            
            Assert.IsFalse(TestSocket.Status);
        }

        [TestCase]
        public void IllegalCommandTest()
        {

            var expected = new List<String>
                {
                    "Illegal Command: NotACommand",
                    "1 "
                };
            testSocket.SetTestProtokoll("IllegalCommandTest");
            sut.Loop();
            var actual = TestSocket.Output;
            TestSocket.Output = new List<String>();

            Assert.AreEqual(expected,actual);

        }

        [TestCase]
        public void LoadTest()
        {
            TestStream.Map = new Dictionary<string, string>
                {
                {"firstKey","firstValue"},
                {"secondKey","secondValue"},
                {"thirdKey","thirdValue"},
                {"fourdKey","fourdValue"}
                };

            var expected = new List<String>
                {
                    "1 firstValue",
                    "1 secondValue",
                    "1 thirdValue",
                    "1 fourdValue",
                    "1 "
                };
            testSocket.SetTestProtokoll("LoadTest");
            sut.Loop();
            var actual = TestSocket.Output;
            TestSocket.Output = new List<string>();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void SaveTest()
        {
            TestStream.Map = new Dictionary<string, string>
                {
                {"firstKey","firstValue"},
                {"secondKey","secondValue"},
                {"thirdKey","thirdValue"},
                {"fourdKey","fourdValue"}
                };

            var expected = new Dictionary<String, String>
                {
                    {"firstKey","firstValue"},
                    {"fiftKey","fiftValue"},
                    {"thirdKey","thirdValue"},
                    {"fourdKey","newfourdValue"}
                    
                };
            testSocket.SetTestProtokoll("SaveTest");
            sut.Loop();
            var actual = TestStream.ServerFile;
            TestStream.ServerFile = new Dictionary<String, String>();

            Assert.AreEqual(expected,actual);
        }

    }
}
