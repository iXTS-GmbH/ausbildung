using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ixts.Ausbildung.Geometry.Test
{
    [TestFixture]
    class ScriptInterpreterTests
    {

        [TestCase("draw 20/20 40/20 30/40")]
        [TestCase("move north 10")]
        [TestCase("zoom 2")]
        [TestCase("print C:/Users/mkaestl.IXTS/Desktop/test.png")]
        public void EvalTest(string script)
        {
            //wie soll ich das Testen?
        }
    }
}
