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
        public Boolean LastCommandUnkown;
        private const String LOCALHOST = "localhost";
        private const String BACK_LOOP = "127.0.0.1";
        private const String COMMAND_ILLEGAL = "ist kein gültiger Befehl";
        private const String COMMAND_PUT = "PUT";
        private const String COMMAND_GET = "GET";
        private const String COMMAND_DEL = "DEL";

        public NameClient(String serverIP, int serverPort,ISocketFactory sFactory = null)
        {
            socketFactory = sFactory ?? new SocketFactory();

            ip = serverIP == LOCALHOST ? IPAddress.Parse(BACK_LOOP) : IPAddress.Parse(serverIP);

            port = serverPort;

            s = socketFactory.Make(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            s.Bind(port, true, ip);
        }

        public String Action(String command,String key,String value = null)
        {

            var valid = ValidateCommand(command);

            if (valid)
            {
                LastCommandUnkown = false;

                var answer = Send(string.Format("{0} {1} {2}{3}", command, key, value, Environment.NewLine));

               return answer.Replace(Environment.NewLine,string.Empty);
            }
            LastCommandUnkown = true;

            Console.WriteLine("{0} {2}{1}",command,Environment.NewLine,COMMAND_ILLEGAL);

            return null;
        }

        private String Send(String command)
        {
            s.Send(command);

            var answer = s.Receive();

            return answer;
        }

        private Boolean ValidateCommand(String command)
        {
            if (COMMAND_PUT.Equals(command, StringComparison.InvariantCultureIgnoreCase) ||
                COMMAND_GET.Equals(command, StringComparison.InvariantCultureIgnoreCase) ||
                COMMAND_DEL.Equals(command, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }

            return false;
        }

    }
}
