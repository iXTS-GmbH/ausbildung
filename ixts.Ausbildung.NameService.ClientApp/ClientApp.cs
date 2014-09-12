using System;

namespace ixts.Ausbildung.NameService.ClientApp
{
    class ClientApp
    {
        private static NameClient nc;

        static void Main(String[] args)
        {
            var host = args.Length > 0 ? args[0] : Constants.LOCALHOST;
            var port = args.Length > 1 ? Int32.Parse(args[1]) : Constants.STANDARD_PORT;

            nc = new NameClient(host, port);

            Loop();

        }

        private static void Loop()
        {
            for (; ; )
            {
                var line = Console.ReadLine();

                if (line != string.Empty)
                {
                    var parameters = ParameterHandler.Normalize(line.Split(Constants.PARAMETER_DELIMITER));
                    var response = nc.HandleCommand(parameters);

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
