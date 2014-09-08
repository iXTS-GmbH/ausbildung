using System.Net;
using NUnit.Framework;

namespace ixts.Ausbildung.NameService.Test
{
    [TestFixture]
    public class NameClientTests
    {
        private NameClient sut;
        private TestSocketFactory testSocketFactory = new TestSocketFactory();
        private TestSocket testSocket = new TestSocket();
        
        [SetUp]
        public void SetUp()
        {
            sut = new NameClient("localhost",2000,testSocketFactory);
        }

        [TestCase]
        public void ClientPutTest()
        {
            testSocket.SetTestProtokoll("ClientPutTest");
            
            var expected = "";
            var actual = sut.Action("PUT", "GET", "VALUE");
            Assert.AreEqual(expected, actual);

        }

        [TestCase]
        public void ClientGetTest()
        {
            testSocket.SetTestProtokoll("ClientGetTest");

            var expected = "GetValue";
            var actual = sut.Action("GET", "GET");
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void ClientDelTest()
        {
            testSocket.SetTestProtokoll("ClientDelTest");

            var expected = "DelValue";
            var actual = sut.Action("DEL", "DEL");
            Assert.AreEqual(expected, actual);
        }

        [ExpectedException]
        [TestCase]
        public void IllegalCommandTest()
        {
            sut.Action("ILLEGALCOMMAND", "AFFE");
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
