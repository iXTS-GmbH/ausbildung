using System;
using System.Net;
using System.Net.Sockets;

namespace ixts.Ausbildung.NameService
{
    public class NameClient
    {
        private readonly IPAddress ip;
        private readonly int port;
        private readonly ISocketFactory socketFactory;
        private readonly ISocket s;
        private const String COMMAND_ILLEGAL = "ist kein gültiger Befehl";
        private readonly IConsole console;

        public NameClient(String serverIP, int serverPort,ISocketFactory sFactory = null, IConsole console = null)
        {
            socketFactory = sFactory ?? new SocketFactory();
            this.console = console ?? new ConsoleImpl();

            ip = IPAddress.Parse(serverIP);

            port = serverPort;

            s = socketFactory.Make(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            s.Bind(port, true, ip);IPAddress.Parse(serverIP);

        }

        public void Loop()
        {
            for (; ; )
            {
                var line = console.Readline();

                if (!string.IsNullOrEmpty(line))
                {
                    var parameters = ParameterHandler.Normalize(line.Split(Constants.PARAMETER_DELIMITER));
                    var response = HandleCommand(parameters);

                    console.WriteLine(response);

                    if (parameters[0] == Constants.COMMAND_STOP)
                    {
                        return;
                    }
                }
            }
        }


        public String HandleCommand(String[] parameters)
        {
            var command = parameters[0];
            var key = parameters[1];
            var value = parameters[2];

            var valid = ValidateCommand(command);

            if (valid && command != Constants.COMMAND_STOP)
            {
               var response = Send(string.Format("{0} {1} {2}{3}", command, key, value, Environment.NewLine));

               return response.Replace(Environment.NewLine,string.Empty);
            }
            if (command != Constants.COMMAND_STOP)
            {
                console.WriteLine(string.Format("{0} {1}{2}",command,COMMAND_ILLEGAL,Environment.NewLine));  
            }
            return null;
        }

        private String Send(String command)
        {
            s.Send(command);

            return s.Receive();
        }

        private Boolean ValidateCommand(String command)
        {
            return (Constants.COMMAND_PUT.Equals(command, StringComparison.InvariantCultureIgnoreCase) ||
                    Constants.COMMAND_GET.Equals(command, StringComparison.InvariantCultureIgnoreCase) ||
                    Constants.COMMAND_DEL.Equals(command, StringComparison.InvariantCultureIgnoreCase) ||
                    Constants.COMMAND_STOP.Equals(command, StringComparison.InvariantCultureIgnoreCase));
        }

    }
}
