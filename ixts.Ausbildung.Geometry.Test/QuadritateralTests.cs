using System;
using NUnit.Framework;

namespace ixts.Ausbildung.Geometry.Test
{
    [TestFixture]
    class QuadritateralTests
    {
        private Quadritateral sut;

        [SetUp]
        public void SetUp()
        {
            var a = new Point(1,2);
            var b = new Point(3,2);
            var c = new Point(3,4);
            var d = new Point(1,4);
            sut = new Quadritateral(a,b,c,d);
        }

        [TestCaseSource("ConstruktorTestSource")]
        public void ConstruktorTest(Point a, Point b, Point c, Point d, Point eA, Point eB, Point eC, Point eD)
        {
            var actual = new Quadritateral(a, b, c, d);
            Assert.AreEqual(actual.A.X, eA.X);
            Assert.AreEqual(actual.A.Y, eA.Y);
            Assert.AreEqual(actual.B.X, eB.X);
            Assert.AreEqual(actual.B.Y, eB.Y);
            Assert.AreEqual(actual.C.X, eC.X);
            Assert.AreEqual(actual.C.Y, eC.Y);
            Assert.AreEqual(actual.D.X, eD.X);
            Assert.AreEqual(actual.D.Y, eD.Y);
        }
        public static readonly object[] ConstruktorTestSource =
            {
                new object[]{new Point(1,2), new Point(3,2), new Point(3,4), new Point(1,4), new Point(1,2), new Point(3,2), new Point(3,4), new Point(1,4)}
            };

        [TestCase(8)]
        public void PerimeterTest(double expected)
        {
            var actual = sut.Perimeter();
            Assert.AreEqual(expected,actual);
        }

        [TestCaseSource("AreaTestSource")]
        public void AreaTest(Quadritateral quad, double expected)
        {
            var actual = quad.Area();
            Assert.AreEqual(expected,actual,0.01);
        }

        public static readonly object[] AreaTestSource =
            {
                new object[]{new Quadritateral(new Point(1,1),new Point(1,1),new Point(1,1), new Point(1,1)),0},//Area = 0
                new object[]{new Quadritateral(new Point(1,2),new Point(3,2),new Point(3,4), new Point(1,4)),4}//Area != 0
            };

        [TestCaseSource("LowerLeftTestSource")]
        public void LowerLeftTest(Quadritateral quad,Point expected)
        {
            var actual = quad.LowerLeft();
            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
        }

        public static readonly object[] LowerLeftTestSource =
            {
                new object[]{new Quadritateral(new Point(1,2), new Point(3,2), new Point(3,4), new Point(1,4)), new Point(1,2)},
            };

        [TestCaseSource("UpperRightTestSource")]
        public void UpperRightTest(Quadritateral quad, Point expected)
        {
            var actual = quad.UpperRight();
            Assert.AreEqual(expected.X,actual.X);
            Assert.AreEqual(expected.Y,actual.Y);
        }

        public static readonly object[] UpperRightTestSource =
            {
                new object[]{new Quadritateral(new Point(1,2), new Point(3,2), new Point(3,4), new Point(1,4)), new Point(3,4)}
            };
        [TestCaseSource("IsSameTestSource")]
        public void IsSameTest(Quadritateral quad, double within, Boolean expected)
        {
            var actual = sut.IsSame(quad, within);
            Assert.AreEqual(expected,actual);
        }

        public static readonly object[] IsSameTestSource =
            {
                new object[]{new Quadritateral(new Point(1,2),new Point(3,2),new Point(2,3), new Point(1,4)), 1, true}, //innerhalb des Rahmens

                new object[]{new Quadritateral(new Point(1,0),new Point(3,2),new Point(2,3), new Point(1,4)), 1, false}, //außerhalb des Rahmens 1 Wert  (aY)
                new object[]{new Quadritateral(new Point(1,0),new Point(3,0),new Point(2,3), new Point(1,4)), 1, false}, //außerhalb des Rahmens 2 Werte (aY,bY)
                new object[]{new Quadritateral(new Point(1,0),new Point(3,0),new Point(0,3), new Point(1,4)), 1, false}, //außerhalb des Rahmens 3 Werte (aY,bY,cX)
                new object[]{new Quadritateral(new Point(1,0),new Point(3,0),new Point(0,3), new Point(1,2)), 1, false}, //außerhalb des Rahmens 4 Werte (aY,bY,cX,dY)
                new object[]{new Quadritateral(new Point(1,0),new Point(1,0),new Point(0,3), new Point(1,2)), 1, false}, //außerhalb des Rahmens 5 Werte (aY,b,cX,dY)
                new object[]{new Quadritateral(new Point(1,0),new Point(1,0),new Point(0,1), new Point(1,2)), 1, false}, //außerhalb des Rahmens 6 Werte (aY,b,c,dY)
                new object[]{new Quadritateral(new Point(-1,0),new Point(1,0),new Point(0,1), new Point(1,2)), 1, false}, //außerhalb des Rahmens 7 Werte (a,b,c,dY)
                new object[]{new Quadritateral(new Point(-1,0),new Point(1,0),new Point(0,1), new Point(-1,2)), 1, false} //außerhalb des Rahmens 8 Werte (a,b,c,d)
            };
    }
}
