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
        private Boolean lastCommandUnkown;//TODO Andere methode überelgen
        private const String COMMAND_ILLEGAL = "ist kein gültiger Befehl";

        public NameClient(String serverIP, int serverPort,ISocketFactory sFactory = null)
        {
            socketFactory = sFactory ?? new SocketFactory();

            ip = serverIP.ToUpper() == Constants.LOCALHOST.ToUpper() ? IPAddress.Parse(Constants.BACK_LOOP) : IPAddress.Parse(serverIP);

            port = serverPort;

            s = socketFactory.Make(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            s.Bind(port, true, ip);
        }

        public String Action(String command,String key,String value = null)//TODO Muss umbenannt werden
        {

            var valid = ValidateCommand(command);

            if (valid)
            {
                lastCommandUnkown = false;

                var response = Send(string.Format("{0} {1} {2}{3}", command, key, value, Environment.NewLine));

               return response.Replace(Environment.NewLine,string.Empty);
            }
            lastCommandUnkown = true;

            Console.WriteLine("{0} {1}{2}",command,COMMAND_ILLEGAL,Environment.NewLine);

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
                    Constants.COMMAND_DEL.Equals(command, StringComparison.InvariantCultureIgnoreCase));
        }

    }
}
