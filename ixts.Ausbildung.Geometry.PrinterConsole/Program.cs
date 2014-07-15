using System;

namespace ixts.Ausbildung.Geometry.PrinterConsole
{
    class Program
    {
        private static ScriptInterpreter scriptInterpreter = new ScriptInterpreter();
        static void Main()
        {
            var script = Console.In.ReadToEnd();
            scriptInterpreter.Eval(script);
        }
    }
}
