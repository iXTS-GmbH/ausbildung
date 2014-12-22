using System;

namespace ixts.Ausbildung.Geometry.PrinterConsole
{
    class Program
    {
        private static ScriptInterpreter scriptInterpreter = new ScriptInterpreter();
        static void Main()
        {
            try
            {
            var script = Console.In.ReadToEnd();
            scriptInterpreter.Eval(script);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
