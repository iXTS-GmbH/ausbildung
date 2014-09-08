using System;

namespace ixts.Ausbildung.NameService.ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            String host = args.Length > 0 ? args[0] : "localhost";
            int port = args.Length > 1 ? Int32.Parse(args[1]) : 2000;
            NameClient nc = new NameClient(host, port);
            Console.WriteLine(nc.Action("PUT", "Inge", "localhost"));
            Console.WriteLine(nc.Action("PUT", "Inge", "127.0.0.1"));
            Console.WriteLine(nc.Action("GET", "Inge", "null"));
            Console.WriteLine(nc.Action("DEL", "Inge", "null"));
            Console.WriteLine(nc.Action("GET", "Inge", "null"));
            //Hierhin kommen die Aktionen im Format:
            //Console.WriteLine(nc.Aktion("BEFEHL","Key","Value||null"));

        }
    }
}
