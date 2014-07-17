using System;
using NUnit.Framework;

namespace ixts.Ausbildung.Geometry.Test
{
    [TestFixture]
    public class PointTests
    {
        [TestCase]
        public void XTest()
        {
            var expected = 4;
            var x = 4;
            var actual = new Point(x, 0.0);
            Assert.AreEqual(expected, actual.X);
        }
        [TestCase]
        public void YTest()
        {
            var expected = 4;
            var y = 4;
            var actual = new Point(0.0, y);
            Assert.AreEqual(expected, actual.Y);
        }

        [TestCase(0,1,0,2,1)]// X-Verschieden
        [TestCase(1,0,2,0,1)]// Y-Verschieden
        [TestCase(1, 2, 2, 1, 1.4142135623730951)]// Beide Verschieden
        public void DistanceTest(double pointX, double pointY, double nPointX, double nPointY, double expected)
        {
            var point = new Point(pointX, pointY);
            var nPoint = new Point(nPointX, nPointY);
            var actual = point.Distance(nPoint);
            Assert.AreEqual(expected,actual);
        }

        [TestCase(1,1,1,1,1,true)]  // NPoint == Point 
        [TestCase(0,1,0,2,2,true)]  // NPoint innerhalb within X-Verschieden
        [TestCase(1,0,2,0,2,true)]  // NPoint innerhalb within Y-Verschieden
        [TestCase(1,1,2,2,2,true)]  // NPoint innerhalb within Beide Verschieden
        [TestCase(1,0,3,0,1,false)] // NPoint ausserhalb within X-Verschieden
        [TestCase(0,1,0,3,1,false)] // NPoint ausserhalb within Y-Verschieden
        [TestCase(1,1,2,2,1,false)] // NPoint ausserhalb within Beide Verschieden
        public void IsSameTest(double pointX, double pointY, double nPointX, double nPointY,double within , Boolean expected)
        {
            var point = new Point(pointX, pointY);
            var nPoint = new Point(nPointX, nPointY);
            var actual = point.IsSame(nPoint, within);
            Assert.AreEqual(expected,actual);
        }

        [TestCase(1,1,1,0,2,1)] //Auf X-Achse verschieben
        [TestCase(1,1,0,1,1,2)] //Auf Y-Achse verschieden
        [TestCase(1,1,1,1,2,2)] //Auf Beiden Achsen verschieben
        public void MovedTest(double pointX, double pointY, double moveX, double moveY, double expectedX, double expectedY)
        {
            var point = new Point(pointX, pointY);
            var expected = new Point(expectedX, expectedY);
            var actual = point.Moved(moveX, moveY);
            Assert.AreEqual(expected.X,actual.X);
            Assert.AreEqual(expected.Y,actual.Y);
        }

        [TestCase(true, 0, 0, 0, 0)]                        //0
        [TestCase(true, 3, 3, 3, 3)]                        //Ganzzahl > 0
        [TestCase(false, 3, 3, 3, 4)]                       //Ganzzahl > 0 False
        [TestCase(true, -3, -3, -3, -3)]                    //Ganzzahl < 0
        [TestCase(false, -3, -3, -3, -4)]                   //Ganzzahl < 0 False
        [TestCase(true, 3.333, 3.333, 3.333, 3.333)]        //Kommazahl Im Delta > 0
        [TestCase(false, 3.333, 3.333, 3.333, 3.334)]       //Kommazahl Im Delta > 0 False
        [TestCase(true, -3.333, -3.333, -3.333, -3.333)]    //Kommazahl Im Delta < 0
        [TestCase(false, -3.333, -3.333, -3.333, -3.334)]   //Kommazahl Im Delta < 0 False
        [TestCase(true, 3.3333, 3.3333, 3.3333, 3.3334)]    //Kommazahl Auserhalb Delta > 0
        [TestCase(true, -3.3333, -3.3333, -3.3333, -3.3334)]//Kommazahl Auserhalb Delta < 0
        [TestCase(false, 3.333,3.333,3.338,3.338)]          //Unterschied negativ
        public void EqualsTest(Boolean expected,double x, double y, double otherX, double otherY)
        {
            var point = new Point(x, y);
            var otherpoint = new Point(x, y);
            Assert.AreEqual(true,point.Equals(otherpoint));
        }
    }
}
