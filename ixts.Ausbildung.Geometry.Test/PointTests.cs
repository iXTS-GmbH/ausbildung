using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ixts.Ausbildung.Geometry.Test
{
    [TestFixture]
    public class PointTests
    {
        private Point sut;

        [TestCase(1.0,2.0,1.0,2.0)]
        public void KonstruktorTest(double expectedX,double expectedY, double x, double y)
        {

            var actual = new Point(x, y);
            Assert.AreEqual(expectedX, actual.x);
            Assert.AreEqual(expectedY, actual.y);
        }
    }
}
