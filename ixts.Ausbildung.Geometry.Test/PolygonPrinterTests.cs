using System;
using System.Drawing;
using NUnit.Framework;

namespace ixts.Ausbildung.Geometry.Test
{
    [TestFixture]
    class PolygonPrinterTests
    {
        private PolygonPrinter sut;
        [SetUp]
        public void SetUp()
        {
            sut = new PolygonPrinter();
        }

        [TestCase]
        public void TriangleCreateTest()
        {
            var expected = new Triangle(new[] { new Point(20, 20), new Point(40, 20), new Point(30, 40)});
            var actual = sut.Create(new Point(20, 20), new Point(40, 20), new Point(30, 40));
            Assert.AreEqual(expected,sut.polygons[actual]);
        }

        [TestCase]
        public void QuadliteralCreateTest()
        {
            var expected = new Quadrilateral(new[] {new Point(20, 20), new Point(40, 20), new Point(40, 40), new Point(20, 40)});
            var actual = sut.Create(new Point(20, 20), new Point(40, 20), new Point(40, 40), new Point(20, 40));
            Assert.AreEqual(expected,sut.polygons[actual]);
        }

        [TestCase("Triangle1")]
        public void MoveTest(string formname)
        {
            sut.Create(new Point(20, 20), new Point(40, 20), new Point(30, 40));
            var expected = new Triangle(new[] {new Point(30, 20), new Point(50, 20), new Point(40, 40)});
            sut.MovePolygon(formname,10,0);
            Assert.AreEqual(expected,sut.polygons[formname]);
        }

        [TestCase("Triangle1")]
        public void ZoomTest(string formname)
        {
            sut.Create(new Point(20, 20), new Point(40, 20), new Point(30, 40));
            var expected = new Triangle(new[] {new Point(10, 10), new Point(50, 10), new Point(30, 50)});
            sut.ZoomPolygon(formname,2);
            Assert.AreEqual(expected,sut.polygons[formname]);
        }



        [TestCase()]
        public void PrintTest()
        {
            var path = string.Format("{0}/testTriangle.png", AppDomain.CurrentDomain.BaseDirectory);
            sut.Create(new Point(1,1),new Point(3,1),new Point(2,2));

            var expected = new Bitmap(path);
            var actual = sut.Print();

            for (int i = 0; i < expected.Height; i++)
            {
                for (int j = 0; j < expected.Width; j++)
                {
                    Assert.AreEqual(expected.GetPixel(j,i),actual.GetPixel(j,i));
                }
            }
        }

        [TestCase(500,400)]
        public void SpezificPrintTest(int height,int width)
        {
            var expected = new Bitmap(width,height);
            var actual = sut.Print(height, width);
            Assert.AreEqual(expected.Size,actual.Size);
        }

        [TestCase(0)]
        public void ClearTest(double expected)
        {
            sut.Create(new Point(20, 20), new Point(40, 20), new Point(30, 40));
            sut.Create(new Point(20, 20), new Point(40, 20), new Point(40, 40), new Point(20, 40));
            sut.Clear();
            Assert.AreEqual(expected,sut.polygons.Count);

        }
    }
}
