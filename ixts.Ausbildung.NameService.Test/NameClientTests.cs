using System;
using System.Collections.Generic;
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
        private const String VALUE = "VALUE";
        private const String COMMAND_UNKNOWN = "UnkownCommand";
        private const String KEY_UNKNOWN = "UnkownKey";
        
        [SetUp]
        public void SetUp()
        {
            sut = new NameClient(Constants.LOCALHOST, Constants.STANDARD_PORT, testSocketFactory);
        }

        [TestCase("1 ")]
        public void ClientPutTest(String expected)
        {
            testSocket.SetTestProtokoll("ClientPutTest");

            var actual = sut.HandleCommand(Constants.COMMAND_PUT, Constants.COMMAND_GET, VALUE);
            Assert.AreEqual(expected, actual);

        }

        [TestCase("1 GetValue")]
        public void ClientGetTest(String expected)
        {
            testSocket.SetTestProtokoll("ClientGetTest");

            var actual = sut.HandleCommand(Constants.COMMAND_GET, Constants.COMMAND_GET);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1 DelValue")]
        public void ClientDelTest(String expected)
        {
            testSocket.SetTestProtokoll("ClientDelTest");

            var actual = sut.HandleCommand(Constants.COMMAND_DEL, Constants.COMMAND_DEL);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void UnkownCommandTest()
        {
            var expected = new List<String>();

            TestSocket.Output = new List<String>();

            sut.HandleCommand(COMMAND_UNKNOWN, KEY_UNKNOWN);

            var actual = TestSocket.Output;

            Assert.AreEqual(expected,actual);
        }

        [TestCase]
        public void IPTest()
        {
            var expected = IPAddress.Parse(Constants.BACK_LOOP);
            var client = new NameClient(Constants.BACK_LOOP, Constants.STANDARD_PORT, testSocketFactory);
            client.HandleCommand(Constants.COMMAND_PUT, VALUE, Constants.BACK_LOOP);
            var actual = TestSocket.ServerIP;

            Assert.AreEqual(expected,actual);
        }
    }
}
