using System;

namespace ixts.Ausbildung.NameService.ClientApp
{
    class Program
    {

        static void Main(String[] args)
        {
            var host = args.Length > 0 ? args[0] : "localhost";
            var port = args.Length > 1 ? Int32.Parse(args[1]) : 2000;

            var nc = new NameClient(host, port);

            var run = true;

            while(run)
            {
                var line = Console.ReadLine();

                if (line != null)
                {
                    var parameters = line.Split(' ');
                    parameters = ParameterHandler.Normalize(parameters);

                    var key = parameters[0] == "STOP" ? null : parameters[1];

                    
                    var value = parameters.Length > 2 ? parameters[2] : null;
                    

                    var answer = nc.Action(parameters[0], key, value);

                    if (answer != null)
                    {
                        Console.WriteLine(answer);
                    }
                    

                    if(parameters[0] == "STOP")
                    {
                        run = false;
                    }
                }
            }
        }
    }
}
