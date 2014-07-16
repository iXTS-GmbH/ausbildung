using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using NUnit.Framework;

namespace ixts.Ausbildung.Geometry.Test
{
    [TestFixture]//TODO Doppelte Equals entfernen
    class ScriptInterpreterTests
    {
        private ScriptInterpreter sut;

        [SetUp]
        public void SetUp()
        {
            sut = new ScriptInterpreter();
        }

        [TestCase("draw Triangle 20/20 40/20 30/40","Triangle1")]
        public void EvalDrawTest(string script, string expected)
        {
            sut.Eval(script);
            Assert.AreEqual(expected,sut.lastPolygonName);
        }

        [TestCase("draw Triangle 20/20 40/20 30/40","move north 10","Triangle1")]
        public void EvalMoveTest(string script, string script2, string formname)
        {
            var expected = new Triangle(new[] {new Point(20, 30), new Point(40, 30), new Point(30, 50)});
            sut.Eval(script);
            sut.Eval(script2);
            Assert.AreEqual(true,expected.Equals(sut.polygonPrinter.polygons[formname])); 
        }

        [TestCase("draw Triangle 20/20 40/20 30/40", "zoom 2","Triangle1")]
        public void EvalZoomTest(string script, string script2, string formname)
        {
            var expected = new Triangle(new[] {new Point(10, 10), new Point(50, 10), new Point(30, 50)});
            sut.Eval(script);
            sut.Eval(script2);
            Assert.AreEqual(expected,sut.polygonPrinter.polygons[formname]);
        }

        [TestCase("draw Triangle 20/20 40/20 30/40", "print")]
        public void PrintTest(string script, string print)
        {
            var path = string.Format("{0}/bTestTriangle.png", AppDomain.CurrentDomain.BaseDirectory);
            var controlpath = string.Format("{0}/bTestTriangleV.png",AppDomain.CurrentDomain.BaseDirectory); 
            var expected = new Bitmap(controlpath);
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