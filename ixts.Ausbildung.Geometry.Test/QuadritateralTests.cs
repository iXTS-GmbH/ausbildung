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

        [TestCaseSource("MovedTestSource")]
        public void MovedTest(double dx, double dy, Quadritateral expected)
        {
            var actual = sut.Moved(dx,dy);
            Assert.AreEqual(expected.A.X, actual.A.X);
            Assert.AreEqual(expected.A.Y, actual.A.Y);
            Assert.AreEqual(expected.B.X, actual.B.X);
            Assert.AreEqual(expected.B.Y, actual.B.Y);
            Assert.AreEqual(expected.C.X, actual.C.X);
            Assert.AreEqual(expected.C.Y, actual.C.Y);
            Assert.AreEqual(expected.D.X, actual.D.X);
            Assert.AreEqual(expected.D.Y, actual.D.Y);
        }

        public static readonly object[] MovedTestSource =
            {
                new object[]{0,1,new Quadritateral(new Point(1,3), new Point(3,3), new Point(3,5), new Point(1,5))},//Nach oben verschieben
                new object[]{0,-1,new Quadritateral(new Point(1,1), new Point(3,1), new Point(3,3), new Point(1,3))},//Nach unten verschieben
                new object[]{-1,0,new Quadritateral(new Point(0,2), new Point(2,2), new Point(2,4), new Point(0,4))},//Nach links verschieben
                new object[]{1,0,new Quadritateral(new Point(2,2), new Point(4,2), new Point(4,4), new Point(2,4))},//Nach rechts verschieben

                new object[]{-1,1,new Quadritateral(new Point(0,3), new Point(2,3), new Point(2,5), new Point(0,5))},//Nach obenlinks verschieben
                new object[]{1,1,new Quadritateral(new Point(2,3), new Point(4,3), new Point(4,5), new Point(2,5))},//Nach obenrechts verschieben
                new object[]{1,-1,new Quadritateral(new Point(2,1), new Point(4,1), new Point(4,3), new Point(2,3))},//Nach untenrechts verschieben
                new object[]{-1,-1,new Quadritateral(new Point(0,1), new Point(2,1), new Point(2,3), new Point(0,3))},//Nach untenLinks verschieben
            };
    }
}
