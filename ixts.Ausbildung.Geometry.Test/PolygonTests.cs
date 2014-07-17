using System;
using NUnit.Framework;

namespace ixts.Ausbildung.Geometry.Test
{
    [TestFixture]
    class PolygonTests
    {
        [TestCaseSource("EqualsTestSource")]
        public void EqualsTest(Boolean expected, Polygon polygon, Polygon otherPolygon)
        {
            var actual = polygon.Equals(otherPolygon);
            Assert.AreEqual(expected,actual);
        }

        public static readonly object[] EqualsTestSource =
            {
                //other == null
                new object[]{false,new Polygon(new []{new Point(20,20),new Point(40,20),new Point(30,40)}),null},
                //other.points.length != points.length
                new object[]{false,new Polygon(new []{new Point(20,20),new Point(40,20),new Point(30,40)}),new Polygon(new []{new Point(20,20),new Point(40,20),new Point(30,40), new Point(20,40)})},
                // this und other sind gleich
                new object[]{true,new Polygon(new []{new Point(20,20),new Point(40,20),new Point(30,40)}),new Polygon(new []{new Point(20,20),new Point(40,20),new Point(30,40)})},
                // this und other sind verschieden
                new object[]{false,new Polygon(new []{new Point(20,20),new Point(40,20),new Point(30,40)}),new Polygon(new []{new Point(20,20),new Point(40,20),new Point(30,50)})},
                // this und other sind gleich aber nicht gleiche reihenfolge
                new object[]{true,new Polygon(new []{new Point(20,20),new Point(40,20),new Point(30,40)}),new Polygon(new []{new Point(30,40),new Point(20,20),new Point(40,20)})}
            };
    }
}
