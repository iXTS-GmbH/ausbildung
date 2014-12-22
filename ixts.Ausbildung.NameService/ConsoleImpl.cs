using System;

namespace ixts.Ausbildung.NameService
{
    public class ConsoleImpl:IConsole
    {

        public String Readline()
        {
           return Console.ReadLine();
        }

        public void WriteLine(String line)
        {
            Console.WriteLine(line);
        }
    }
}
