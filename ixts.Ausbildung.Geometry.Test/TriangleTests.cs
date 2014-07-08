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
                new object[]{new Triangle(new Point(1,2),new Point(3,2),new Point(2,3)), 1, true},
                new object[]{new Triangle(new Point(1,1),new Point(1,1),new Point(1,1)), 1, false}
            };
    }
}
