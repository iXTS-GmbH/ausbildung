using System;

namespace ixts.Ausbildung.NameService.ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = args.Length > 0 ? args[0] : "localhost";
            var port = args.Length > 1 ? Int32.Parse(args[1]) : 2000;

            var nc = new NameClient(host, port);

            var run = true;

            while(run)
            {
                String line = Console.ReadLine();
                if (line != null)
                {
                    String[] parameters = line.Split(' ');
                    var value = parameters.Length > 2 ? parameters[2] : null;
                    Console.WriteLine(nc.Action(parameters[0], parameters[1], value));
                    if(parameters[0] == "STOP")
                    {
                        run = false;
                    }
                }
            }
        }
    }
}
