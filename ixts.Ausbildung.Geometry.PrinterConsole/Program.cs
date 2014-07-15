using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;

namespace ixts.Ausbildung.Geometry.PrinterConsole
{
    class Program
    {
        private static ScriptInterpreter scriptInterpreter = new ScriptInterpreter();
        private static List<Polygon> listOfForms = new List<Polygon>(); 
        static void Main(string[] args)
        {
            var script = Console.In.ReadToEnd();
            scriptInterpreter.Eval(script);
        }
    }
}
