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
    }
}
