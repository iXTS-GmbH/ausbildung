using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace ixts.Ausbildung.Geometry.Test
{
    [TestFixture]
    class ScriptInterpreterTests
    {
        private ScriptInterpreter sut;
        [SetUp]
        public void SetUp()
        {
            sut = new ScriptInterpreter();
        }

        [TestCase("draw Triangle 20/20 40/20 30/40")]

        public void EvalDrawTest(string script)
        {
            var expected = "Triangle1";
            sut.Eval(script);
            Assert.AreEqual(expected,sut.listOfForms[0]);
        }

        [TestCase("draw Triangle 20/20 40/20 30/40","move north 10")]
        public void EvalMoveTest(string script, string script2)
        {
            var expected = new Dictionary<string, Polygon>();
            expected.Add("Triangle1", new Triangle(new[] { new Point(20, 30), new Point(40, 30), new Point(30, 50) }));
            sut.Eval(script);
            sut.Eval(script2);
            Assert.AreEqual(expected["Triangle1"].Points[0].X, sut.polygonPrinter.polygons["Triangle1"].Points[0].X);
            Assert.AreEqual(expected["Triangle1"].Points[0].Y, sut.polygonPrinter.polygons["Triangle1"].Points[0].Y);
            Assert.AreEqual(expected["Triangle1"].Points[1].X, sut.polygonPrinter.polygons["Triangle1"].Points[1].X);
            Assert.AreEqual(expected["Triangle1"].Points[1].Y, sut.polygonPrinter.polygons["Triangle1"].Points[1].Y);
            Assert.AreEqual(expected["Triangle1"].Points[2].X, sut.polygonPrinter.polygons["Triangle1"].Points[2].X);
            Assert.AreEqual(expected["Triangle1"].Points[2].Y, sut.polygonPrinter.polygons["Triangle1"].Points[2].Y);
        }

        [TestCase("draw Triangle 20/20 40/20 30/40", "zoom 2")]
        public void EvalZoomTest(string script, string script2)
        {
            var expected = new Dictionary<string, Polygon>();
            expected.Add("Triangle1", new Triangle(new[] { new Point(10, 10), new Point(50, 10), new Point(30, 50) }));
            sut.Eval(script);
            sut.Eval(script2);
            Assert.AreEqual(expected["Triangle1"].Points[0].X, sut.polygonPrinter.polygons["Triangle1"].Points[0].X);
            Assert.AreEqual(expected["Triangle1"].Points[0].Y, sut.polygonPrinter.polygons["Triangle1"].Points[0].Y);
            Assert.AreEqual(expected["Triangle1"].Points[1].X, sut.polygonPrinter.polygons["Triangle1"].Points[1].X);
            Assert.AreEqual(expected["Triangle1"].Points[1].Y, sut.polygonPrinter.polygons["Triangle1"].Points[1].Y);
            Assert.AreEqual(expected["Triangle1"].Points[2].X, sut.polygonPrinter.polygons["Triangle1"].Points[2].X);
            Assert.AreEqual(expected["Triangle1"].Points[2].Y, sut.polygonPrinter.polygons["Triangle1"].Points[2].Y);
        }

        [TestCase("draw Triangle 20/20 40/20 30/40", "print" ,"C:/Users/mkaestl.IXTS/Projekte/Ausbildung/ausbildung/bTestTriangleV.png")]
        public void PrintTest(string script, string print, string path)
        {
            var expected = File.ReadAllBytes("C:/Users/mkaestl.IXTS/Projekte/Ausbildung/ausbildung/bTestTriangle.png");
            sut.Eval(script);
            sut.Eval(print + path);
            var actual = File.ReadAllBytes(path);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i],actual[i]);
            }
        }
    }
}