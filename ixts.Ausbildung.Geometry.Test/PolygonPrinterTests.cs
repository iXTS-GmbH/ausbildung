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
            Assert.AreEqual(expected,sut.Polygons[actual]);
        }

        [TestCase]
        public void QuadliteralCreateTest()
        {
            var expected = new Quadliteral(new[] {new Point(20, 20), new Point(40, 20), new Point(40, 40), new Point(20, 40)});
            var actual = sut.Create(new Point(20, 20), new Point(40, 20), new Point(40, 40), new Point(20, 40));
            Assert.AreEqual(expected,sut.Polygons[actual]);
        }

        [TestCase]
        public void NegativCreateTest()
        {
            var expected = new Quadliteral(new[] {new Point(10, 0), new Point(50, 0), new Point(50, 50), new Point(10, 50)});
            sut.Create(new Point(10,-10),new Point(50,-10),new Point(50,40),new Point(10,40));
            Assert.AreEqual(expected, sut.Polygons["Quadliteral1"]);
        }

        [TestCase]
        public void MoveTest()
        {
            const string formname = "Triangle1";
            sut.Create(new Point(20, 20), new Point(40, 20), new Point(30, 40));
            var expected = new Triangle(new[] {new Point(30, 20), new Point(50, 20), new Point(40, 40)});
            sut.MovePolygon(formname,10,0);
            Assert.AreEqual(expected,sut.Polygons[formname]);
        }

        [TestCase]
        public void NegativMoveTest()
        {
            const string formname = "Quadliteral1";
            sut.Create(new Point(10, 0), new Point(60, 0), new Point(60, 50), new Point(10, 50));
            var expected = new Quadliteral(new[] { new Point(10, 0), new Point(60, 0), new Point(60, 50), new Point(10, 50) });
            sut.MovePolygon(formname, 0, -10);
            Assert.AreEqual(expected, sut.Polygons[formname]);
        }

        [TestCase]
        public void ZoomTest()
        {
            const string formname = "Triangle1";
            sut.Create(new Point(20, 20), new Point(40, 20), new Point(30, 40));
            var expected = new Triangle(new[] {new Point(10, 10), new Point(50, 10), new Point(30, 50)});
            sut.ZoomPolygon(formname,2);
            Assert.AreEqual(expected,sut.Polygons[formname]);
        }

        [TestCase]
        public void NegativZoomTest()
        {
            const string formname = "Quadliteral1";
            sut.Create(new Point(10, 50), new Point(60, 50), new Point(60, 80),new Point(10,80));
            var expected = new Quadliteral(new[] { new Point(0, 35), new Point(100, 35), new Point(100, 95),new Point(0,95)});
            sut.ZoomPolygon(formname, 2);
            Assert.AreEqual(expected.Points[0].X, sut.Polygons[formname].Points[0].X);
            Assert.AreEqual(expected.Points[1].X, sut.Polygons[formname].Points[1].X);
            Assert.AreEqual(expected.Points[2].X, sut.Polygons[formname].Points[2].X);
            Assert.AreEqual(expected.Points[3].X, sut.Polygons[formname].Points[3].X);
        }

        [TestCase]
        public void PrintTest()
        {
            sut.Create(new Point(1,1),new Point(3,1),new Point(2,2));
            var expected = new Bitmap(Resources.testTriangle);
            var actual = sut.Print();
            for (int i = 0; i < expected.Height; i++)
            {
                for (int j = 0; j < expected.Width; j++)
                {
                    Assert.AreEqual(expected.GetPixel(j,i),actual.GetPixel(j,i));
                }
            }
        }

        [TestCase]
        public void SpezificPrintTest()
        {
            const int height = 500;
            const int width = 400;
            var expected = new Bitmap(width,height);
            var actual = sut.Print(width, height);
            Assert.AreEqual(expected.Size,actual.Size);
        }

        [TestCase]
        public void ClearTest()
        {
            const int expected = 0;
            sut.Create(new Point(20, 20), new Point(40, 20), new Point(30, 40));
            sut.Create(new Point(20, 20), new Point(40, 20), new Point(40, 40), new Point(20, 40));
            sut.Clear();
            Assert.AreEqual(expected,sut.Polygons.Count);

        }
    }
}
