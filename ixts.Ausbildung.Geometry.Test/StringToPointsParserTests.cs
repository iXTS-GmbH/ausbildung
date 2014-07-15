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
            Assert.AreEqual(expected[0].X, actual[0].X);
            Assert.AreEqual(expected[0].Y, actual[0].Y);
            Assert.AreEqual(expected[1].X, actual[1].X);
            Assert.AreEqual(expected[1].Y, actual[1].Y);
            Assert.AreEqual(expected[2].X, actual[2].X);
            Assert.AreEqual(expected[2].Y, actual[2].Y);
        }

        [TestCase("20/20 40/20 40/40 20/40")]
        [TestCase("20/20;40/20;40/40;20/40")]
        public void QuadliteralParseTest(string pointstring)
        {
            var expected = new[] { new Point(20, 20), new Point(40, 20), new Point(40, 40), new Point(20, 40) };
            var actual = StringToPointsParser.Parse(pointstring);
            Assert.AreEqual(expected[0].X, actual[0].X);
            Assert.AreEqual(expected[0].Y, actual[0].Y);
            Assert.AreEqual(expected[1].X, actual[1].X);
            Assert.AreEqual(expected[1].Y, actual[1].Y);
            Assert.AreEqual(expected[2].X, actual[2].X);
            Assert.AreEqual(expected[2].Y, actual[2].Y);
            Assert.AreEqual(expected[3].X, actual[3].X);
            Assert.AreEqual(expected[3].Y, actual[3].Y);
        }
    }
}
