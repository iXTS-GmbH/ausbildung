using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.Kommentar_Zapper.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader(args[0]);
            var writer = new StreamWriter(args[1]);

            reader.ReadLine();
        }
    }
}
