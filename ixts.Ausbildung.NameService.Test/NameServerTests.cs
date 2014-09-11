using System;
using System.Collections.Generic;
using System.Text;
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
            sut = new NameServer(2000,testSocketFactory);
            testSocket = new TestSocket();
        }

        [TestCase]
        public void PutTest()
        {
            TestStream.Map = new Dictionary<String, String>();
            TestSocket.Output = new List<String>();

            var expected = new List<String>
                {
                    string.Format("{0}1 {0}",Environment.NewLine),
                    string.Format("{0}1 firstValue{0}",Environment.NewLine),
                    string.Format("{0}1 {0}",Environment.NewLine)
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
                    string.Format("{0}1 {0}",Environment.NewLine),
                    string.Format("{0}1 firstValue{0}",Environment.NewLine),
                    string.Format("{0}1 {0}",Environment.NewLine)
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
                    string.Format("{0}1 {0}",Environment.NewLine),
                    string.Format("{0}1 firstValue{0}",Environment.NewLine),
                    string.Format("{0}0{0}",Environment.NewLine),
                    string.Format("{0}1 {0}",Environment.NewLine)
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
                    string.Format("{0}Illegal Command: NotACommand{0}",Environment.NewLine),
                    string.Format("{0}1 {0}",Environment.NewLine)
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
            TestStream.Map = new Dictionary<String, String>
                {
                    {"firstKey","firstValue"},
                    {"secondKey","secondValue"},
                    {"thirdKey","thirdValue"},
                    {"fourdKey","fourdValue"}
                };

            var expected = new List<String>
                {
                    string.Format("{0}1 firstValue{0}",Environment.NewLine),
                    string.Format("{0}1 secondValue{0}",Environment.NewLine),
                    string.Format("{0}1 thirdValue{0}",Environment.NewLine),
                    string.Format("{0}1 fourdValue{0}",Environment.NewLine),
                    string.Format("{0}1 {0}",Environment.NewLine)
                };
            testSocket.SetTestProtokoll("LoadTest");
            var server = new PersistentNameServer(2000,new TestSocketFactory(),new TestStreamFactory());
            server.Loop();
            var actual = TestSocket.Output;
            TestSocket.Output = new List<String>();

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
            var server = new PersistentNameServer(2000,new TestSocketFactory(),new TestStreamFactory());

            server.Loop();
            var actual = TestStream.ServerFile;

            TestStream.ServerFile = new Dictionary<String, String>();

            Assert.AreEqual(expected,actual);
        }

        [TestCase]
        public void NoFileTest()
        {
            TestStream.Exist = false;
            var expected = new Dictionary<String, String>();
            testSocket.SetTestProtokoll("NoFileTest");

            var server = new PersistentNameServer(2000, new TestSocketFactory(),new TestStreamFactory());
            server.Loop();

            var actual = TestStream.ServerFile;

            TestStream.Exist = true;
            TestSocket.Output = new List<String>();

            Assert.AreEqual(expected,actual);
        }

        [TestCase]
        public void NormalizeDataTest()
        {
            TestStream.Map = new Dictionary<String, String>();

            var expected = new Dictionary<String, String>
                {
                    {"NormalizedKey","NormalizedValue"}
                };

            testSocket.SetTestProtokoll("NormalizeDataTest");
            

            var server = new PersistentNameServer(2000,new TestSocketFactory(),new TestStreamFactory());
            server.Loop();

            var actual = TestStream.ServerFile;

            Assert.AreEqual(expected,actual);
        }
    }
}
