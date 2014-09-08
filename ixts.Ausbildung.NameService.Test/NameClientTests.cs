using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
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

        }


    }
}
