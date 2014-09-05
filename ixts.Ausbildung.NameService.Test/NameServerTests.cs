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

        }

        [TestCase]
        public void DelTest()
        {

        }

        [TestCase]
        public void StopTest()
        {

        }
    }
}
