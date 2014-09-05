using System;
using System.Collections.Generic;
using System.Net.Sockets;
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
            var testSocketFactory = new TestSocketFaktory();
            sut = new NameServer(2000,testSocketFactory);
            testSocket = new TestSocket();
        }

        [TestCase]
        public void PutTest()
        {
            var expected = new List<String>
                {
                    "1 ",
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
            var expected = new List<String>
                {
                    "1 ",
                    "1 testValue",
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
            var expected = new List<String>
                {
                    "1 ",
                    "1 testValue",
                    "0",
                    "1 "
                };
            testSocket.SetTestProtokoll("DelTest");
            sut.Loop();
            var actual = TestSocket.Output;
            TestSocket.Output = new List<String>();

            Assert.AreEqual(expected,actual);
        }

        [TestCase]
        public void StopTest()
        {
            testSocket.SetTestProtokoll("StopTest");
            sut.Loop();
            
            Assert.IsFalse(TestSocket.Status);
        }

        [TestCase]
        public void IllegalCommandTest()
        {
            var expected = new List<String>
                {
                    "Illegal Command NotACommand",
                    "1 "
                };
            //testSocket.
        }
    }
}
