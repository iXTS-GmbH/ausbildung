using NUnit.Framework;

namespace ixts.Ausbildung.Geometry.Test
{
    [TestFixture]
    class StringToPointsParserTests
    {
        [TestCase("20/20;40/20;30/40")]
        [TestCase("20/20 40/20 30/40")]
        public void TriangleParseTest(string pointstring)
        {
            var expected = new [] {new Point(20,20),new Point(40,20),new Point(30,40)};
            var actual = StringToPointsParser.Parse(pointstring);
            Assert.AreEqual(expected,actual);
        }

        [TestCase("20/20 40/20 40/40 20/40")]
        [TestCase("20/20;40/20;40/40;20/40")]
        public void QuadliteralParseTest(string pointstring)
        {
            var expected = new[] { new Point(20, 20), new Point(40, 20), new Point(40, 40), new Point(20, 40)};
            var actual = StringToPointsParser.Parse(pointstring);
            Assert.AreEqual(expected, actual);
        }
    }
}
