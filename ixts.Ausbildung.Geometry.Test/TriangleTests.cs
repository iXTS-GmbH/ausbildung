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
            sut = new Triangle(new []{a, b, c});
        }

        [TestCase] 
        public void PerimeterTest()
        {
            var expected = 4.8284271247461898;//2 + sqrt(2) + sqrt(2)
            var actual = sut.Perimeter();
            Assert.AreEqual(expected,actual);
        }

        [TestCase]
        public void AreaTest()
        {
            var expected = 1;
            var actual = sut.Area();
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestCase]
        public void LowerLeftTest()
        {
            var expected = new Point(1, 2);
            var actual = sut.LowerLeft();
            Assert.AreEqual(actual,expected);
        }

        [TestCase]
        public void UpperRightTest()
        {
            var expected = new Point(3, 3);
            var actual = sut.UpperRight();
            Assert.AreEqual(actual,expected);
        }

        [TestCaseSource("IsSameTestSource")]
        public void IsSameTest(Triangle triangle, double within, Boolean expected)
        {
            var actual = sut.IsSame(triangle, within);
            Assert.AreEqual(expected, actual);
        }

        public static readonly object[] IsSameTestSource =
            {
                new object[]{new Triangle(new []{new Point(1,2),new Point(3,2),new Point(2,3)}), 1, true},  //innerhalb des Rahmens
                new object[]{new Triangle(new []{new Point(1,1),new Point(1,1),new Point(1,3)}), 1, false}, //außerhalb des Rahmens 1 Wert (bX)
                new object[]{new Triangle(new []{new Point(1,1),new Point(1,1),new Point(1,1)}), 1, false}, //außerhalb des Rahmens 2 Werte (bX,cY)
                new object[]{new Triangle(new []{new Point(1,0),new Point(1,1),new Point(1,1)}), 1, false}, //außerhalb des Rahmens 3 Werte (aY,bX,cY)
                new object[]{new Triangle(new []{new Point(1,0),new Point(1,0),new Point(1,1)}), 1, false}, //außerhalb des Rahmens 4 Werte (aY,B,cY)
                new object[]{new Triangle(new []{new Point(1,0),new Point(1,0),new Point(0,1)}), 1, false}, //außerhalb des Rahmens 5 Werte (aY,B,C)
                new object[]{new Triangle(new []{new Point(-1,0),new Point(1,0),new Point(0,1)}), 1, false} //außerhalb des Rahmens 6 Werte (A,B,C)
            };

        [TestCaseSource("MovedTestSource")]
        public void MovedTest(double dx, double dy, Triangle expected)
        {
            var actual = sut.Moved(dx, dy);
            Assert.AreEqual(expected, actual);
        }

        public static readonly object[] MovedTestSource =
            {
                new object[]{1,0,new Triangle(new []{new Point(2,2),new Point(4,2),new Point(3,3)})},  //Nach oben verschieben
                new object[]{-1,0,new Triangle(new []{new Point(0,2),new Point(2,2),new Point(1,3)})}, //Nach unten verschieben
                new object[]{0,-1,new Triangle(new []{new Point(1,1),new Point(3,1),new Point(2,2)})}, //Nach links verschieben
                new object[]{0,1,new Triangle(new []{new Point(1,3),new Point(3,3),new Point(2,4)})},  //Nach rechts verschieben
                new object[]{1,-1,new Triangle(new []{new Point(2,1),new Point(4,1),new Point(3,2)})}, //Nach obenlinks verschieben
                new object[]{1,1,new Triangle(new []{new Point(2,3),new Point(4,3),new Point(3,4)})},  //Nach obenrechts verschieben
                new object[]{-1,1,new Triangle(new []{new Point(0,3),new Point(2,3),new Point(1,4)})}, //Nach untenrechts verschieben
                new object[]{-1,-1,new Triangle(new []{new Point(0,1),new Point(2,1),new Point(1,2)})} //Nuch untenlinks verschieben
            };
        [TestCaseSource("ZoomedTestSource")]
        public void ZoomedTest(double f, Triangle expected)
        {
            var actual = sut.Zoomed(f);
            Assert.AreEqual(expected, actual);
        }

        public static readonly object[] ZoomedTestSource =
            {
                new object[]{2, new Triangle(new []{new Point(2,4),new Point(6,4),new Point(4,6)})},               //f > 1
                new object[]{1, new Triangle(new []{new Point(1,2),new Point(3,2),new Point(2,3)})},               //f = 1
                new object[]{0.5,new Triangle(new []{new Point(0.5,1),new Point(1.5,1),new Point(1,1.5)})},        //0 < f < 1
                new object[]{0, new Triangle(new []{new Point(0,0),new Point(0,0),new Point(0,0)})},               //f = 0
                new object[]{-0.5, new Triangle(new []{new Point(-0.5,-1),new Point(-1.5,-1),new Point(-1,-1.5)})},//-1 < f < 0
                new object[]{-1, new Triangle(new []{new Point(-1,-2),new Point(-3,-2),new Point(-2,-3)})}         //f = -1
                

            };

        [TestCaseSource("PointZoomedTestSource")]
        public void PointZoomedTest(Point p, double f, Triangle expected)
        {
            var actual = sut.Zoomed(p, f);
            Assert.AreEqual(expected, actual);
        }

        public static readonly object[] PointZoomedTestSource =
            {
                new object[]{new Point(1,1),2, new Triangle(new []{new Point(1,3),new Point(5,3),new Point(3,5)})},             //f > 1
                new object[]{new Point(1,1),1, new Triangle(new []{new Point(1,2),new Point(3,2),new Point(2,3)})},             //f = 1
                new object[]{new Point(1,1),0.5,new Triangle(new []{new Point(1,1.5),new Point(2,1.5),new Point(1.5,2)})},      //0 < f < 1
                new object[]{new Point(1,1),0, new Triangle(new []{new Point(1,1),new Point(1,1),new Point(1,1)})},             //f = 0
                new object[]{new Point(1,1),-0.5,new Triangle(new []{new Point(1,0.5),new Point(0,0.5),new Point(0.5,0)})},     //-1 < f < 0 
                new object[]{new Point(1,1),-1, new Triangle(new []{new Point(1,0),new Point(-1,0),new Point(0,-1)})}           //f = -1     
            };
        [TestCase]
        public void RotateTest()
        {
            var angle = 360;
            var actual = sut.Rotate(angle);
            Assert.AreEqual(sut, actual);
        }
        [TestCase]
        public void PointRotateTest()
        {
            var angle = 360;
            var point = sut.Middle();
            var actual = sut.Rotate(point, angle);
            Assert.AreEqual(sut, actual);
        }
        [TestCase]
        public void MiddleTest()
        {
            var triangle = new Triangle(new []{new Point(1,1),new Point(3,1),new Point(2,3)});
            var expected = new Point(2,2);
            var actual = triangle.Middle();
            Assert.AreEqual(actual,expected);
        }

        [TestCaseSource("EquilateralTestSource")]//Gleichseitig
        public void EquilateralTest(Boolean expected, Triangle triangle)
        {
            var actual = triangle.Equilateral();
            Assert.AreEqual(expected,actual);
        }

        public static readonly object[] EquilateralTestSource =
            {
                new object[]{true, new Triangle(new []{new Point(1,1),new Point(5,1), new Point(3,4.464)})},
                new object[]{false, new Triangle(new []{new Point(1,2),new Point(3,2), new Point(2,3)})}
            };

        [TestCaseSource("IsoscelesTestSource")]//Gleichschenklig
        public void IsoscelesTest(Boolean expected, Triangle triangle)
        {
            var actual = triangle.Isosceles();
            Assert.AreEqual(expected,actual);
        }

        public static readonly object[] IsoscelesTestSource =
            {
                new object[]{false, new Triangle(new []{new Point(1,1),new Point(5,1), new Point(4,5)})},
                new object[]{true, new Triangle(new []{new Point(1,2),new Point(3,2), new Point(2,3)})}
            };
    }
}