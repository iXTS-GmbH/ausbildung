using System;
using NUnit.Framework;

namespace ixts.Ausbildung.Geometry.Test
{
    [TestFixture]
    class QuadritateralTests
    {
        private Quadrilateral sut;

        [SetUp]
        public void SetUp()
        {
            var a = new Point(1,2);
            var b = new Point(3,2);
            var c = new Point(3,4);
            var d = new Point(1,4);
            sut = new Quadrilateral(new []{a,b,c,d});
        }

       
        [TestCase]
        public void PerimeterTest()
        {
            var expected = 8;
            var actual = sut.Perimeter();
            Assert.AreEqual(expected,actual);
        }

        [TestCase]
        public void AreaTest()
        {
            var expected = 4;
            var actual = sut.Area();
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestCase]
        public void LowerLeftTest()
        {
            var expected = new Point(1, 2);
            var actual = sut.LowerLeft();
            Assert.AreEqual(actual,expected);
        }

        [TestCase]
        public void UpperRightTest()
        {
            var expected = new Point(3, 4);
            var actual = sut.UpperRight();
            Assert.AreEqual(actual,expected);
        }

        [TestCaseSource("IsSameTestSource")]
        public void IsSameTest(Quadrilateral quad, double within, Boolean expected)
        {
            var actual = sut.IsSame(quad, within);
            Assert.AreEqual(expected,actual);
        }

        public static readonly object[] IsSameTestSource =
            {
                new object[]{new Quadrilateral(new []{new Point(1,2),new Point(3,2),new Point(2,3), new Point(1,4)}), 1, true}, //innerhalb des Rahmens

                new object[]{new Quadrilateral(new []{new Point(1,0),new Point(3,2),new Point(2,3), new Point(1,4)}), 1, false}, //außerhalb des Rahmens 1 Wert  (aY)
                new object[]{new Quadrilateral(new []{new Point(1,0),new Point(3,0),new Point(2,3), new Point(1,4)}), 1, false}, //außerhalb des Rahmens 2 Werte (aY,bY)
                new object[]{new Quadrilateral(new []{new Point(1,0),new Point(3,0),new Point(0,3), new Point(1,4)}), 1, false}, //außerhalb des Rahmens 3 Werte (aY,bY,cX)
                new object[]{new Quadrilateral(new []{new Point(1,0),new Point(3,0),new Point(0,3), new Point(1,2)}), 1, false}, //außerhalb des Rahmens 4 Werte (aY,bY,cX,dY)
                new object[]{new Quadrilateral(new []{new Point(1,0),new Point(1,0),new Point(0,3), new Point(1,2)}), 1, false}, //außerhalb des Rahmens 5 Werte (aY,B,cX,dY)
                new object[]{new Quadrilateral(new []{new Point(1,0),new Point(1,0),new Point(0,1), new Point(1,2)}), 1, false}, //außerhalb des Rahmens 6 Werte (aY,B,C,dY)
                new object[]{new Quadrilateral(new []{new Point(-1,0),new Point(1,0),new Point(0,1), new Point(1,2)}), 1, false}, //außerhalb des Rahmens 7 Werte (A,B,C,dY)
                new object[]{new Quadrilateral(new []{new Point(-1,0),new Point(1,0),new Point(0,1), new Point(-1,2)}), 1, false} //außerhalb des Rahmens 8 Werte (A,B,C,d)
            };

        [TestCaseSource("MovedTestSource")]
        public void MovedTest(double dx, double dy, Quadrilateral expected)
        {
            var actual = sut.Moved(dx, dy);
            Assert.AreEqual(expected, actual);
        }

        public static readonly object[] MovedTestSource =
            {
                new object[]{0,1,new Quadrilateral(new []{new Point(1,3), new Point(3,3), new Point(3,5), new Point(1,5)})},//Nach oben verschieben
                new object[]{0,-1,new Quadrilateral(new []{new Point(1,1), new Point(3,1), new Point(3,3), new Point(1,3)})},//Nach unten verschieben
                new object[]{-1,0,new Quadrilateral(new []{new Point(0,2), new Point(2,2), new Point(2,4), new Point(0,4)})},//Nach links verschieben
                new object[]{1,0,new Quadrilateral(new []{new Point(2,2), new Point(4,2), new Point(4,4), new Point(2,4)})},//Nach rechts verschieben
                new object[]{-1,1,new Quadrilateral(new []{new Point(0,3), new Point(2,3), new Point(2,5), new Point(0,5)})},//Nach obenlinks verschieben
                new object[]{1,1,new Quadrilateral(new []{new Point(2,3), new Point(4,3), new Point(4,5), new Point(2,5)})},//Nach obenrechts verschieben
                new object[]{1,-1,new Quadrilateral(new []{new Point(2,1), new Point(4,1), new Point(4,3), new Point(2,3)})},//Nach untenrechts verschieben
                new object[]{-1,-1,new Quadrilateral(new []{new Point(0,1), new Point(2,1), new Point(2,3), new Point(0,3)})}//Nach untenLinks verschieben
            };

        [TestCaseSource("ZoomedTestSource")]
        public void ZoomedTest(double f, Quadrilateral expected)
        {
            var actual = sut.Zoomed(f);
            Assert.AreEqual(expected, actual);
        }

        public static readonly object[] ZoomedTestSource =
            {
                
                new object[]{0, new Quadrilateral(new []{new Point(0,0),new Point(0,0),new Point(0,0),new Point(0,0)})},//f = 0
                new object[]{0.5,new Quadrilateral(new []{new Point(0.5,1),new Point(1.5,1),new Point(1.5,2),new Point(0.5,2)})},//1 > f > 0
                new object[]{1,new Quadrilateral(new []{new Point(1,2),new Point(3,2),new Point(3,4),new Point(1,4)})},//f = 1
                new object[]{2,new Quadrilateral(new []{new Point(2,4),new Point(6,4),new Point(6,8),new Point(2,8)})}//f > 1
            };
        [TestCase()]
        public void RotateTest()
        {
            var angle = 360;
            var actual = sut.Rotate(angle);
            Assert.AreEqual(sut, actual);

        }
        [TestCase()]
        public void PointRotareTest()
        {
            var angle = 360;
            var point = sut.Middle();
            var actual = sut.Rotate(point, angle);
            Assert.AreEqual(sut, actual);
        }
        [TestCase]
        public void MiddleTest()
        {
            var expected = new Point(2, 2);
            var actual = sut.Middle();
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource("QuadratTestSource")]
        public void QuadratTest(Boolean expected, Quadrilateral quad)
        {
            var actual = quad.Quadrat();
            Assert.AreEqual(expected, actual);
        }

        public static readonly object[] QuadratTestSource =
            {
                new object[]{true, new Quadrilateral(new []{new Point(1,1),new Point(1,5),new Point(5,5), new Point(5,1)})},
                new object[]{false,new Quadrilateral(new []{new Point(1,1),new Point(1,5),new Point(5,5), new Point(5,2)})}
            };

        [TestCaseSource("QuadratTestSource")]
        public void ParallelogrammTest(Boolean expected, Quadrilateral quad)
        {
            var actual = quad.Parallelogram();
            Assert.AreEqual(expected, actual);
        }
    }
}
