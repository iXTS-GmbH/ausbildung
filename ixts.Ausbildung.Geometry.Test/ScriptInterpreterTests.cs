using System.Collections.Generic;
using System.Drawing;
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
            Assert.AreEqual(true, expected["Triangle1"].IsSame(sut.polygonPrinter.polygons["Triangle1"],0.001));
        }

        [TestCase("draw Triangle 20/20 40/20 30/40", "zoom 2")]
        public void EvalZoomTest(string script, string script2)
        {
            var expected = new Dictionary<string, Polygon>();
            expected.Add("Triangle1", new Triangle(new[] { new Point(10, 10), new Point(50, 10), new Point(30, 50) }));
            sut.Eval(script);
            sut.Eval(script2);
            Assert.AreEqual(true, expected["Triangle1"].IsSame(sut.polygonPrinter.polygons["Triangle1"], 0.001));
        }

        [TestCase("draw Triangle 20/20 40/20 30/40", "print" ,"C:/Users/mkaestl.IXTS/Projekte/Ausbildung/ausbildung/bTestTriangleV.png")]
        public void PrintTest(string script, string print, string path)
        {
            var expected = new Bitmap("C:/Users/mkaestl.IXTS/Projekte/Ausbildung/ausbildung/bTestTriangle.png");
            sut.Eval(script);
            sut.Eval(print + path);
            var actual = new Bitmap(path);
            for (int i = 0; i < expected.Height; i++)
            {
                for (int j = 0; j < expected.Width; j++)
                {
                    Assert.AreEqual(expected.GetPixel(j,i),actual.GetPixel(j,i));
                }
            }
        }
    }
}