using System;
using NUnit.Framework;

namespace ixts.Ausbildung.Geometry.Test
{
    [TestFixture]
    class TriangleTests
    {

        [TestCase(1,2,3,1,2,3)]
        public void ConstrukterTest(double expectedA, double expectedB, double expectedC, double a, double b, double c)
        {
            var actual = new Triangle(a,b,c);
            Assert.AreEqual(expectedA, actual.A);
            Assert.AreEqual(expectedB, actual.B);
            Assert.AreEqual(expectedC, actual.C);
        }
    }
}
