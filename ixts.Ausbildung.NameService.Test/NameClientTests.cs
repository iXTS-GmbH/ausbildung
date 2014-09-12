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
        private const int STANDARD_PORT = 2000;
        private const String LOCALHOST = "localhost";
        private const String BACK_LOOP = "127.0.0.1";
        private const String COMMAND_PUT = "PUT";
        private const String COMMAND_GET = "GET";
        private const String COMMAND_DEL = "DEL";
        private const String VALUE = "VALUE";
        private const String COMMAND_UNKNOWN = "UnkownCommand";
        private const String KEY_UNKNOWN = "UnkownKey";
        
        [SetUp]
        public void SetUp()
        {
            sut = new NameClient(LOCALHOST,STANDARD_PORT,testSocketFactory);
        }

        [TestCase("1 ")]
        public void ClientPutTest(String expected)
        {
            testSocket.SetTestProtokoll("ClientPutTest");
            
            var actual = sut.Action(COMMAND_PUT, COMMAND_GET, VALUE);
            Assert.AreEqual(expected, actual);

        }

        [TestCase("1 GetValue")]
        public void ClientGetTest(String expected)
        {
            testSocket.SetTestProtokoll("ClientGetTest");

            var actual = sut.Action(COMMAND_GET, COMMAND_GET);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1 DelValue")]
        public void ClientDelTest(String expected)
        {
            testSocket.SetTestProtokoll("ClientDelTest");

            var actual = sut.Action(COMMAND_DEL, COMMAND_DEL);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void UnkownCommandTest()
        {
            sut.Action(COMMAND_UNKNOWN, KEY_UNKNOWN);

            //Assert.True(sut.LastCommandUnkown);
        }

        [TestCase]
        public void IPTest()
        {
            var expected = IPAddress.Parse(BACK_LOOP);
            var client = new NameClient(BACK_LOOP, STANDARD_PORT, testSocketFactory);
            client.Action(COMMAND_PUT, VALUE, BACK_LOOP);
            var actual = TestSocket.ServerIP;

            Assert.AreEqual(expected,actual);
        }


    }
}
