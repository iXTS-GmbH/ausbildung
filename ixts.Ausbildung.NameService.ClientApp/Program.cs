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
            String line;
            String value;
            Boolean run = true;

            while(run)
            {
                line = Console.ReadLine();
                String[] parameters = line.Split(' ');
                value = parameters.Length > 2 ? parameters[2]: null
                Console.WriteLine(nc.Action(parameters[0],parameters[1],value))
                if(parameters[0] == "STOP")
                {
                    run = false;
                }
            }
        }
    }
}
