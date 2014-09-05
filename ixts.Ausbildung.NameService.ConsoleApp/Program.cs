using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.NameService.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            int port = args.Length == 0 ? 2000 : Int32.Parse(args[0]);
            new NameServer(port).Loop();
        }
    }
}
