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

        //[TestCase]
        //public void SaveTest()
        //{
        //    TestStream.Map = new Dictionary<string, string>
        //        {
        //            {"firstKey","firstValue"},
        //            {"secondKey","secondValue"},
        //            {"thirdKey","thirdValue"},
        //            {"fourdKey","fourdValue"}
        //        };

        //    var expected = new Dictionary<String, String>
        //        {
        //            {"firstKey","firstValue"},
        //            {"fiftKey","fiftValue"},
        //            {"thirdKey","thirdValue"},
        //            {"fourdKey","newfourdValue"}
                    
        //        };

        //    testSocket.SetTestProtokoll("SaveTest");
        //    var server = new PersistentNameServer(2000, new TestSocketFactory(), new TestStreamFactory());

        //    server.Loop();
        //    var actual = TestStream.ServerFile;

        //    TestStream.ServerFile = new Dictionary<String, String>();

        //    Assert.AreEqual(expected, actual);
        //}

        //[TestCase]
        //public void NoFileTest()
        //{
        //    TestStream.Exist = false;
        //    var expected = new Dictionary<String, String>();
        //    testSocket.SetTestProtokoll("NoFileTest");

        //    var server = new PersistentNameServer(2000, new TestSocketFactory(), new TestStreamFactory());
        //    server.Loop();

        //    var actual = TestStream.ServerFile;

        //    TestStream.Exist = true;
        //    TestSocket.Output = new List<String>();

        //    Assert.AreEqual(expected, actual);
        //}

    }
}
