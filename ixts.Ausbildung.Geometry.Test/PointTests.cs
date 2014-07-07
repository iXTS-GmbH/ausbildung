using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ixts.Ausbildung.Geometry.Test
{
    [TestFixture]
    public class PointTests
    {
        [TestCase(1,2,1,2)]
        public void KonstruktorTest(double expectedX,double expectedY, double x, double y)
        {

            var actual = new Point(x, y);
            Assert.AreEqual(expectedX, actual.X());
            Assert.AreEqual(expectedY, actual.Y());
        }
        [TestCase(4,4)]
        public void XTest(double expected, double x)
        {
            var actual = new Point(x, 0.0);
            Assert.AreEqual(expected, actual.X());
        }
        [TestCase(4,4)]
        public void YTest(double expected, double y)
        {
            var actual = new Point(0.0, y);
            Assert.AreEqual(expected, actual.Y());
        }

        [TestCase(0,1,0,2,1)]// X-Verschieden
        [TestCase(1,0,2,0,1)]// Y-Verschieden
        [TestCase(1, 2, 2, 1, 1.4142135623730951)]// Beide Verschieden
        public void DistanceTest(double PointX, double PointY, double NPointX, double NPointY, double expected)
        {
            var Point = new Point(PointX, PointY);
            var NPoint = new Point(NPointX, NPointY);
            var actual = Point.Distance(NPoint);
            Assert.AreEqual(expected,actual);
        }
    }
}
