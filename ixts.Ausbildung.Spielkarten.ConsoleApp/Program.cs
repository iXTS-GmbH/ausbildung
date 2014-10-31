using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.Spielkarten.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine(Enum.GetName(typeof (Suit), 1));
        }
    }
}
