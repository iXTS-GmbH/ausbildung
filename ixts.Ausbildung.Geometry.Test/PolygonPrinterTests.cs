using System.Collections.Generic;
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
        public void TriangleCreateTest()//Geht
        {
            var expected = new Dictionary<string, Polygon>();
            expected.Add("Triangle1", new Triangle(new []{new Point(20,20),new Point(40,20),new Point(30,40)}));
            var actual = sut.Create(new Point(20, 20), new Point(40, 20), new Point(30, 40));//Ein Triangle ist erstellt
            Assert.AreEqual(true, expected["Triangle1"].IsSame(sut.polygons[actual], 0.001));
        }

        [TestCase]
        public void QuadliteralCreateTest()
        {
            var expected = new Dictionary<string, Polygon>();
            expected.Add("Quadliteral1", new Quadrilateral(new []{new Point(20,20),new Point(40,20),new Point(40,40),new Point(20,40)}));
            var actual = sut.Create(new Point(20, 20), new Point(40, 20), new Point(40, 40), new Point(20, 40));
            Assert.AreEqual(true, expected["Quadliteral1"].IsSame(sut.polygons[actual], 0.001));
        }
        [TestCase]
        public void MoveTest()
        {
            sut.Create(new Point(20, 20), new Point(40, 20), new Point(30, 40));
            var expected = new Dictionary<string, Polygon>();
            expected.Add("Triangle1", new Triangle(new[] { new Point(30, 20), new Point(50, 20), new Point(40, 40) }));
            sut.MovePolygon("Triangle1",10,0);
            Assert.AreEqual(true, expected["Triangle1"].IsSame(sut.polygons["Triangle1"], 0.001));

        }

        [TestCase]
        public void ZoomTest()
        {
            sut.Create(new Point(20, 20), new Point(40, 20), new Point(30, 40));
            var expected = new Dictionary<string, Polygon>();
            expected.Add("Triangle1", new Triangle(new []{new Point(10,10),new Point(50,10),new Point(30,50)}));
            sut.ZoomPolygon("Triangle1",2);
            Assert.AreEqual(true, expected["Triangle1"].IsSame(sut.polygons["Triangle1"], 0.001));
        }



        [TestCase]
        public void PrintTest()
        {
            sut.Create(new Point(1,1),new Point(3,1),new Point(2,2));
            var expected = new Bitmap("C:/Users/mkaestl.IXTS/Projekte/Ausbildung/ausbildung/testTriangle.png");
            var actual = sut.Print();
            for (int i = 0; i < expected.Height; i++)
            {
                for (int j = 0; j < expected.Width; j++)
                {
                    Assert.AreEqual(expected.GetPixel(j,i),actual.GetPixel(j,i));
                }
            }
        }

        [TestCase(500,500)]
        public void SpezificPrintTest(int height,int width)
        {
            var expected = new Bitmap(width,height);
            var actual = sut.Print(height, width);
            Assert.AreEqual(expected.Height,actual.Height);
            Assert.AreEqual(expected.Width, actual.Width);
        }

        [TestCase]
        public void ClearTest()
        {
            sut.Create(new Point(20, 20), new Point(40, 20), new Point(30, 40));
            sut.Create(new Point(20, 20), new Point(40, 20), new Point(40, 40), new Point(20, 40));
            var expected = new Dictionary<string, Polygon>();
            sut.Clear();
            Assert.AreEqual(expected.Count,sut.polygons.Count);

        }
    }
}
