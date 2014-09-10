using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.NameService.ClientApp
{
    class Program
    {
        static void Main(String[] args)
        {
            String host = args.Length > 0 ? args[0] : "localhost";
            int port = args.Length > 1 ? Int32.Parse(args[1]) : 2000;

            NameClient nc = new NameClient(host, port);

            Boolean run = true;

            while(run)
            {
                String line = Console.ReadLine();
                if (line != null)
                {
                    String[] parameters = line.Split(' ');
                    parameters = ParameterHandler.Normalize(parameters);
                    parameters = ParameterHandler.ParseParametersToSendable(parameters);

                    String key = parameters[0] == "STOP" ? null : parameters[1];

                    
                    String value = parameters.Length > 2 ? parameters[2] : null;
                    

                    String answer = nc.Action(parameters[0], key, value);

                    if (answer != null)
                    {
                        answer = answer.Replace("ue-", "ü").Replace("oe-", "ö").Replace("ae-", "ä");
                        answer = answer.Replace("Ue-", "Ü").Replace("Oe-", "Ö").Replace("Ae-", "Ä").Replace("ss-", "ß");
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
