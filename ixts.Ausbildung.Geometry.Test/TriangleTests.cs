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

        [TestCase(4.8284271247461898)]
        public void PerimeterTest(double expected)
        {
            var actual = sut.Perimeter();
            Assert.AreEqual(expected,actual);
        }

        [TestCase(1)]
        public void AreaTest(double expected)
        {
            var actual = sut.Area();
            Assert.AreEqual(expected, actual);
        }

    }
}
