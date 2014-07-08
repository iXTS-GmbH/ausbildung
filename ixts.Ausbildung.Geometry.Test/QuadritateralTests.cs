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
    }
}
