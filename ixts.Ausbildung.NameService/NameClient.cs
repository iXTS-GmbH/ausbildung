using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ixts.Ausbildung.NameService
{
    public class NameClient
    {
        private readonly IPAddress ip;
        private readonly int port;
        private readonly ISocketFactory socketFactory;
        private readonly ISocket s;
        public Boolean LastCommandUnkown;

        public NameClient(String serverIP, int serverPort,ISocketFactory sFactory = null)
        {
            socketFactory = sFactory ?? new SocketFactory();

            ip = serverIP == "localhost" ? IPAddress.Parse("127.0.0.1") : IPAddress.Parse(serverIP);

            port = serverPort;

            s = socketFactory.Make(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            s.Bind(port, true, ip);
        }

        public String Action(String command,String key,String value = null)
        {
            var result = "";

            var valid = ValidateCommand(command);

            if (valid)
            {
                LastCommandUnkown = false;

                var answer = Send(string.Format("{0} {1} {2}{3}", command, key, value, Environment.NewLine));

                result = answer.Replace(Environment.NewLine,"");
            }
            else
            {
                LastCommandUnkown = true;

                Console.WriteLine("{0} ist kein gültiger Befehl{1}",command,Environment.NewLine);
                result = "0";

            }

            return result == "0" ? null : result;
        }

        private String Send(String command)
        {
            var msg = Encoding.UTF8.GetBytes(command);

            s.Send(msg);

            var answer = s.Receive();

            return answer;
        }

        private Boolean ValidateCommand(String command)
        {
            if ("PUT".Equals(command, StringComparison.InvariantCultureIgnoreCase) ||
                "GET".Equals(command, StringComparison.InvariantCultureIgnoreCase) ||
                "DEL".Equals(command, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }

            return false;
        }

    }
}
