using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ixts.Ausbildung.NameService.Test
{
    [TestFixture]
    public class MapParserTests
    {
        private TestSocket sut;

        [SetUp]
        public void SetUp()
        {
            sut = new TestSocket();
        }


        //[TestCase]
        //public void LoadTest()
        //{
        //    TestStream.Map = new Dictionary<String, String>
        //        {
        //            {"firstKey","firstValue"},
        //            {"secondKey","secondValue"},
        //            {"thirdKey","thirdValue"},
        //            {"fourdKey","fourdValue"}
        //        };

        //    var expected = new List<String>
        //        {
        //            string.Format("{0}1 firstValue{0}",Environment.NewLine),
        //            string.Format("{0}1 secondValue{0}",Environment.NewLine),
        //            string.Format("{0}1 thirdValue{0}",Environment.NewLine),
        //            string.Format("{0}1 fourdValue{0}",Environment.NewLine),
        //            string.Format("{0}1 {0}",Environment.NewLine)
        //        };
        //    testSocket.SetTestProtokoll("LoadTest");
        //    var server = new PersistentNameServer(2000, new TestSocketFactory(), new TestStreamFactory());
        //    server.Loop();
        //    var actual = TestSocket.Output;
        //    TestSocket.Output = new List<String>();

        //    Assert.AreEqual(expected, actual);
        //}

        [TestCase]
        public void SaveTest()
        {
            TestMapParser.Store = new Dictionary<String, String>
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

            sut.SetTestProtokoll("SaveTest");
            var server = new PersistentNameServer(2000, new TestSocketFactory(), new TestMapParser());

            server.Loop();
            var actual = TestMapParser.Store;

            TestMapParser.Store = new Dictionary<String, String>();

            Assert.AreEqual(expected, actual);
        }
    }
}
