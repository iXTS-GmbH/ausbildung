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
        [TestCase("draw Quadliteral 20/20 40/20 40/40 40/20","Quadliteral1")]
        [TestCase("draw Triangle 20/20 40/20 30/40","Triangle1")]
        public void EvalDrawTest(string script, string expected)
        {
            sut.Eval(script);
            Assert.AreEqual(expected,sut.LastPolygonName);
        }



        [TestCaseSource("EvalMoveTestSource")]
        public void EvalMoveTest(string script, string script2, string formname, Triangle expected)
        {
            sut.Eval(script);
            sut.Eval(script2);
            Assert.AreEqual(expected,sut.PolygonPrinter.Polygons[formname]); 
        }

        public static readonly object[] EvalMoveTestSource =
            {
                new object[] {"draw Triangle 20/20 40/20 30/40","move north 10","Triangle1",new Triangle(new[] {new Point(20, 30), new Point(40, 30), new Point(30, 50)})},
                new object[] {"draw Triangle 20/20 40/20 30/40","move east 10","Triangle1",new Triangle(new[] {new Point(30, 20), new Point(50, 20), new Point(40, 40)})},
                new object[] {"draw Triangle 20/20 40/20 30/40","move south 10","Triangle1",new Triangle(new[] {new Point(20, 10), new Point(40, 10), new Point(30, 30)})},
                new object[] {"draw Triangle 20/20 40/20 30/40","move west 10","Triangle1",new Triangle(new[] {new Point(10, 20), new Point(30, 20), new Point(20, 40)})}
            };

        [TestCase]
        public void EvalZoomTest()
        {
            
            var expected = new Triangle(new[] {new Point(10, 10), new Point(50, 10), new Point(30, 50)});
            sut.Eval("draw Triangle 20/20 40/20 30/40");
            sut.Eval("zoom 2");
            Assert.AreEqual(expected,sut.PolygonPrinter.Polygons["Triangle1"]);
        }

        [TestCase]
        public void PrintTest()
        {
            var expected = new Bitmap(Resources.bTestTriangleV);
            sut.Eval("draw Triangle 20/20 40/20 30/40");
            var filename = Path.GetTempFileName();
            sut.Eval(string.Format("print {0}",filename));
            var actual = new Bitmap(filename);
            for (int i = 0; i < expected.Height; i++)
            {
                for (int j = 0; j < expected.Width; j++)
                {
                    Assert.AreEqual(expected.GetPixel(j, i), actual.GetPixel(j, i));
                }
            }
        }
    }
}