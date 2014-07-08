using System;
using NUnit.Framework;

namespace ixts.Ausbildung.Geometry.Test
{
    [TestFixture]
    class TriangleTests
    {
        private Triangle sut;

        [SetUp]
        public void SetUp()
        {
            var a = new Point(1, 2);
            var b = new Point(3, 2);
            var c = new Point(2, 3);
            sut = new Triangle(a, b, c);
        }

        [TestCaseSource("ConstruktorTestSource")]
        public void ConstrukterTest(Point a,Point b, Point c, Point eA, Point eB, Point eC)
        {
            var actual = new Triangle(a,b,c);
            Assert.AreEqual(actual.A.X, eA.X);
            Assert.AreEqual(actual.A.Y, eA.Y);
            Assert.AreEqual(actual.B.X, eB.X);
            Assert.AreEqual(actual.B.Y, eB.Y);
            Assert.AreEqual(actual.C.X, eC.X);
            Assert.AreEqual(actual.C.Y, eC.Y);
            
        }

        public static readonly object[] ConstruktorTestSource =
            {
                new object[]{new Point(1,2), new Point(3,2), new Point(2,3), new Point(1,2), new Point(3,2), new Point(2,3)}
            };

        [TestCase(4.8284271247461898)] //2 + sqrt(2) + sqrt(2)
        public void PerimeterTest(double expected)
        {
            var actual = sut.Perimeter();
            Assert.AreEqual(expected,actual);
        }

        [TestCaseSource("AreaTestSource")]
        public void AreaTest(Point a, Point b, Point c,double expected)
        {
            var triangle = new Triangle(a, b, c);
            var actual = triangle.Area();
            Assert.AreEqual(expected, actual,0.001);
        }

        public static readonly object[] AreaTestSource =
            {
                new object[]{new Point(1,2), new Point(3,2), new Point(2,3), 1},
                new object[]{new Point(1,2), new Point(1,2), new Point(1,2), 0},

            };

        [TestCaseSource("LowerLeftTestSource")]
        public void LowerLeftTest(Triangle triangle ,Point expected)
        {
            var actual = triangle.LowerLeft();
            Assert.AreEqual(expected.X,actual.X);
            Assert.AreEqual(expected.Y,expected.Y);
        }

        public static readonly object[] LowerLeftTestSource =
            {
                new object[]{new Triangle(new Point(1,2),new Point(3,2),new Point(2,3)), new Point(1,2)},
                new object[]{new Triangle(new Point(1,1),new Point(1,1),new Point(1,1)), new Point(1,1)}
            };
        [TestCase(1,2,3,1)]
        public void LowestValueTest(double a,double b, double c,double expected)
        {
            var actual = sut.LowestValue(a, b, c);
            Assert.AreEqual(expected,actual);
        }

        [TestCaseSource("UpperRightTestSource")]
        public void UpperRightTest(Triangle triangle, Point expected)
        {
            var actual = triangle.UpperRight();
            Assert.AreEqual(expected.X,actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
        }

        public static readonly object[] UpperRightTestSource =
            {
                new object[]{new Triangle(new Point(1,2),new Point(3,2),new Point(2,3)), new Point(3,3)},
                new object[]{new Triangle(new Point(1,1),new Point(1,1),new Point(1,1)), new Point(1,1)}
            };

        [TestCase(1, 2, 3, 3)]
        public void HighestValueTest(double a, double b, double c, double expected)
        {
            var actual = sut.HighestValue(a, b, c);
            Assert.AreEqual(expected,actual);
        }

        [TestCaseSource("IsSameTestSource")]
        public void IsSameTest(Triangle triangle, double within, Boolean expected)
        {
            var actual = sut.IsSame(triangle, within);
            Assert.AreEqual(expected, actual);
        }

        public static readonly object[] IsSameTestSource =
            {
                new object[]{new Triangle(new Point(1,2),new Point(3,2),new Point(2,3)), 1, true}, //innerhalb des Rahmens

                new object[]{new Triangle(new Point(1,1),new Point(1,1),new Point(1,3)), 1, false}, //außerhalb des Rahmens 1 Wert (bX)
                new object[]{new Triangle(new Point(1,1),new Point(1,1),new Point(1,1)), 1, false}, //außerhalb des Rahmens 2 Werte (bX,cY)
                new object[]{new Triangle(new Point(1,0),new Point(1,1),new Point(1,1)), 1, false}, //außerhalb des Rahmens 3 Werte (aY,bX,cY)
                new object[]{new Triangle(new Point(1,0),new Point(1,0),new Point(1,1)), 1, false}, //außerhalb des Rahmens 4 Werte (aY,b,cY)
                new object[]{new Triangle(new Point(1,0),new Point(1,0),new Point(0,1)), 1, false}, //außerhalb des Rahmens 5 Werte (aY,b,c)
                new object[]{new Triangle(new Point(-1,0),new Point(1,0),new Point(0,1)), 1, false} //außerhalb des Rahmens 6 Werte (a,b,c)
            };

        [TestCaseSource("MovedTestSource")]
        public void MovedTest(double dx , double dy, Triangle expected)
        {
            var actual = sut.Moved(dx, dy);
            Assert.AreEqual(expected.A.X,actual.A.X);
            Assert.AreEqual(expected.A.Y,actual.A.Y);
            Assert.AreEqual(expected.B.X,actual.B.X);
            Assert.AreEqual(expected.B.Y,actual.B.Y);
            Assert.AreEqual(expected.C.X,actual.C.X);
            Assert.AreEqual(expected.C.Y,actual.C.Y);
        }

        public static readonly object[] MovedTestSource =
            {
                new object[]{1,0,new Triangle(new Point(2,2),new Point(4,2),new Point(3,3))}, //Nach oben verschieben
                new object[]{-1,0,new Triangle(new Point(0,2),new Point(2,2),new Point(1,3))}, //Nach unten verschieben
                new object[]{0,-1,new Triangle(new Point(1,1),new Point(3,1),new Point(2,2))}, //Nach links verschieben
                new object[]{0,1,new Triangle(new Point(1,3),new Point(3,3),new Point(2,4))}, //Nach rechts verschieben
                new object[]{1,-1,new Triangle(new Point(2,1),new Point(4,1),new Point(3,2))}, //Nach obenlinks verschieben
                new object[]{1,1,new Triangle(new Point(2,3),new Point(4,3),new Point(3,4))}, //Nach obenrechts verschieben
                new object[]{-1,1,new Triangle(new Point(0,3),new Point(2,3),new Point(1,4))}, //Nach untenrechts verschieben
                new object[]{-1,-1,new Triangle(new Point(0,1),new Point(2,1),new Point(1,2))}  //Nuch untenlinks verschieben
            };
    }
}