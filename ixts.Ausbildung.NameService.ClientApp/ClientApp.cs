using System;

namespace ixts.Ausbildung.NameService.ClientApp
{
    class ClientApp
    {

        static void Main(String[] args)
        {
            var host = args.Length > 0 ? args[0] : Constants.LOCALHOST;
            var port = args.Length > 1 ? Int32.Parse(args[1]) : Constants.STANDARD_PORT;

            var nc = new NameClient(host, port);

            for (;;)
            {
                var line = Console.ReadLine();

                if (line != null)
                {
                    var parameters = ParameterHandler.Normalize(line.Split(Constants.PARAMETER_DELIMITER));

                    var response = nc.HandleCommand(parameters[0], parameters[1], parameters[2]);

                    Console.WriteLine(response);

                    if (parameters[0] == Constants.COMMAND_STOP)
                    {
                        return;
                    }
                }
            }
        }
    }
}
