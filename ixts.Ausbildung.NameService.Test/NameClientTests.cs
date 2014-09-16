using System;
using System.Collections.Generic;
using System.Net;
using NUnit.Framework;

namespace ixts.Ausbildung.NameService.Test
{
    [TestFixture]
    public class NameClientTests//TODO Alle Tests auf Loop umschreiben und den Input als switch in TestConsole
    {
        private NameClient sut;
        private readonly TestSocketFactory testSocketFactory = new TestSocketFactory();
        private readonly TestSocket testSocket = new TestSocket();
        
        [SetUp]
        public void SetUp()
        {
            sut = new NameClient(Constants.LOOPBACK, Constants.STANDARD_PORT, testSocketFactory,new TestConsole());
        }

        [TestCase("1 ")]
        public void ClientPutTest(String expected)
        {
            testSocket.SetTestProtokoll("ClientPutTest");
            TestConsole.SetTestProtokoll("ClientPutTest");

            TestConsole.WriteList = new List<String>();
            sut.Loop();
            var actual = TestConsole.WriteList[0];
            Assert.AreEqual(expected, actual);

        }

        [TestCase("1 GetValue")]
        public void ClientGetTest(String expected)
        {
            testSocket.SetTestProtokoll("ClientGetTest");
            TestConsole.SetTestProtokoll("ClientGetTest");

            TestConsole.WriteList = new List<String>();
            sut.Loop();
            var actual = TestConsole.WriteList[0];

            Assert.AreEqual(expected, actual);
        }

        [TestCase("1 DelValue")]
        public void ClientDelTest(String expected)
        {
            testSocket.SetTestProtokoll("ClientDelTest");
            TestConsole.SetTestProtokoll("ClientDelTest");

            TestConsole.WriteList = new List<String>();
            sut.Loop();
            var actual = TestConsole.WriteList[0];

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void UnkownCommandTest()
        {
            TestConsole.SetTestProtokoll("UnkownCommandTest");

            var expected = string.Format("UnkownCommand ist kein gültiger Befehl{0}",Environment.NewLine);

            TestConsole.WriteList = new List<String>();
            sut.Loop();
            var actual = TestConsole.WriteList[0];

            Assert.AreEqual(expected,actual);
        }

        [TestCase]
        public void IPTest()
        {
            TestConsole.SetTestProtokoll("IPTest");
            var expected = IPAddress.Parse(Constants.LOOPBACK);
            var client = new NameClient(Constants.LOOPBACK, Constants.STANDARD_PORT, testSocketFactory,new TestConsole());
            TestConsole.WriteList = new List<String>();

            client.Loop();

            var actual = TestSocket.ServerIP;

            Assert.AreEqual(expected,actual);
        }
    }
}
