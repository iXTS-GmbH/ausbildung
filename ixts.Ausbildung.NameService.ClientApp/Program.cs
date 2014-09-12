using System;

namespace ixts.Ausbildung.NameService.ClientApp
{
    class Program
    {
        private const String LOCALHOST = "localhost";
        private const int STANDARDPORT = 2000;
        private const char WHITE_SPACE = ' ';
        private const String COMMAND_STOP = "STOP";

        static void Main(String[] args)
        {
            var host = args.Length > 0 ? args[0] : LOCALHOST;
            var port = args.Length > 1 ? Int32.Parse(args[1]) : STANDARDPORT;

            var nc = new NameClient(host, port);

            var run = true;

            while(run)
            {
                var line = Console.ReadLine();

                if (line != null)
                {
                    var parameters = line.Split(WHITE_SPACE);
                    parameters = ParameterHandler.Normalize(parameters);

                    var key = parameters[0] ==  COMMAND_STOP ? null : parameters[1];

                    
                    var value = parameters.Length > 2 ? parameters[2] : null;
                    

                    var answer = nc.Action(parameters[0], key, value);

                    if (answer != null)
                    {
                        Console.WriteLine(answer);
                    }
                    

                    if(parameters[0] == COMMAND_STOP)
                    {
                        run = false;
                    }
                }
            }
        }
    }
}
