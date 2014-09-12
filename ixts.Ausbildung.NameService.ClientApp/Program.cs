﻿using System;

namespace ixts.Ausbildung.NameService.ClientApp
{
    class Program
    {
        private const String LOCALHOST = "localhost";
        private const int STANDARD_PORT = 2000;
        private const char WHITE_SPACE = ' ';
        private const String COMMAND_STOP = "STOP";

        static void Main(String[] args)
        {
            var host = args.Length > 0 ? args[0] : LOCALHOST;
            var port = args.Length > 1 ? Int32.Parse(args[1]) : STANDARD_PORT;

            var nc = new NameClient(host, port);

            var run = true;

            while(run)
            {
                var line = Console.ReadLine();

                if (line != null)
                {
                    var parameters = ParameterHandler.Normalize(line.Split(WHITE_SPACE));

                    var answer = nc.Action(parameters[0], parameters[1], parameters[2]);

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
