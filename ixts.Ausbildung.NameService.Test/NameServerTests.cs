﻿using System;
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
            sut = new NameServer(Constants.STANDARD_PORT,testSocketFactory);
            testSocket = new TestSocket();
        }

        [TestCase]
        public void PutTest()
        {
            TestSocket.Output = new List<String>();

            var expected = new List<String>
                {
                    string.Format("{0}{1}{0}",Environment.NewLine,Constants.SEND_SUCCEESS),
                    string.Format("{0}{1}firstValue{0}",Environment.NewLine,Constants.SEND_SUCCEESS),
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
                    string.Format("{0}{1}{0}",Environment.NewLine,Constants.SEND_SUCCEESS),
                    string.Format("{0}{1}firstValue{0}",Environment.NewLine,Constants.SEND_SUCCEESS),
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
                    string.Format("{0}{1}{0}",Environment.NewLine,Constants.SEND_SUCCEESS),
                    string.Format("{0}{1}firstValue{0}",Environment.NewLine,Constants.SEND_SUCCEESS),
                    string.Format("{0}{1}{0}",Environment.NewLine,Constants.SEND_FAILED),
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
            testSocket.SetTestProtokoll("StopTest");
            sut.Loop();
            
            Assert.IsFalse(TestSocket.Status);
        }

        [TestCase]
        public void IllegalCommandTest()
        {

            var expected = new List<String>
                {
                    string.Format("{0}Illegal Command: NOTACOMMAND{0}",Environment.NewLine),
                };
            testSocket.SetTestProtokoll("IllegalCommandTest");
            sut.Loop();
            var actual = TestSocket.Output;
            TestSocket.Output = new List<String>();

            Assert.AreEqual(expected,actual);

        }

        [TestCase]
        public void NormalizeDataTest()
        {

            var expected = new Dictionary<String, String>
                {
                    {"NormalizedKey","NormalizedValue"}
                };

            testSocket.SetTestProtokoll("NormalizeDataTest");

            var server = new PersistentNameServer(Constants.STANDARD_PORT, new TestSocketFactory(), new TestMapParser());
            server.Loop();

            var actual = TestMapParser.Store;

            Assert.AreEqual(expected,actual);
        }

        [TestCase]
        public void NullDelTest()
        {
            var expected = new List<String>
                {
                    string.Format("{1}{0}{1}",Constants.SEND_FAILED,Environment.NewLine)
                };

            testSocket.SetTestProtokoll("NullDelTest");
            TestSocket.Output = new List<String>();

            sut.Loop();

            var actual = TestSocket.Output;
            TestSocket.Output = new List<String>();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void PersistentNullDelTest()
        {
            var expected = new List<String>
                {
                    string.Format("{1}{0}{1}",Constants.SEND_FAILED,Environment.NewLine)
                };

            testSocket.SetTestProtokoll("NullDelTest");
            TestSocket.Output = new List<String>();
            TestMapParser.Store = new Dictionary<String, String>();

            var server = new PersistentNameServer(Constants.STANDARD_PORT, new TestSocketFactory(), new TestMapParser());
            server.Loop();

            var actual = TestSocket.Output;
            TestSocket.Output = new List<String>();

            Assert.AreEqual(expected, actual);
        }
    }
}
