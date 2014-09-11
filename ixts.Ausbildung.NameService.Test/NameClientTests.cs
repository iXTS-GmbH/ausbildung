using System;
using System.Net;
using NUnit.Framework;

namespace ixts.Ausbildung.NameService.Test
{
    [TestFixture]
    public class NameClientTests
    {
        private NameClient sut;
        private readonly TestSocketFactory testSocketFactory = new TestSocketFactory();
        private readonly TestSocket testSocket = new TestSocket();
        
        [SetUp]
        public void SetUp()
        {
            sut = new NameClient("localhost",2000,testSocketFactory);
        }

        [TestCase("1 ")]
        public void ClientPutTest(String expected)
        {
            testSocket.SetTestProtokoll("ClientPutTest");
            
            var actual = sut.Action("PUT", "GET", "VALUE");
            Assert.AreEqual(expected, actual);

        }

        [TestCase("1 GetValue")]
        public void ClientGetTest(String expected)
        {
            testSocket.SetTestProtokoll("ClientGetTest");

            var actual = sut.Action("GET", "GET");
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1 DelValue")]
        public void ClientDelTest(String expected)
        {
            testSocket.SetTestProtokoll("ClientDelTest");

            var actual = sut.Action("DEL", "DEL");
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void UnkownCommandTest()
        {
            sut.Action("UnkownCommand", "NoKey");

            Assert.True(sut.LastCommandUnkown);
        }

        [TestCase]
        public void IPTest()
        {
            var expected = IPAddress.Parse("172.16.92.128");
            var client = new NameClient("172.16.92.128", 2000, testSocketFactory);
            client.Action("PUT", "IPTest", "172.16.92.128");
            var actual = TestSocket.ServerIP;

            Assert.AreEqual(expected,actual);
        }


    }
}
