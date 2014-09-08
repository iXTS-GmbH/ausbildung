using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.NameService.NameClient.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            String host = args.Length > 0 ? args[0] : "localhost";
            int port = args.Length > 1 ? Int32.Parse(args[1]) : 2000;
            NameClient a = new NameClient();
        }
    }
}
