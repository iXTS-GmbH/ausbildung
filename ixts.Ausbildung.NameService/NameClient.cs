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
        private ISocketFactory socketFactory;

        public NameClient(String serverIP, int serverPort,ISocketFactory sFactory = null)
        {
            socketFactory = sFactory ?? new SocketFactory();
            ip = IPAddress.Parse(serverIP);
            port = serverPort;
        }

        public String Action(String command,String key,String value)
        {
            String result = null;

            command = command.ToUpper();

            switch (command)
            {
                case "PUT":
                    result = Send(string.Format("PUT"));
                    break;
                case "GET":
                    result = Send(string.Format("GET"));
                    break;
                case "DEL":
                   result = Send(string.Format("DEL"));
                    break;
                default:
                    Console.WriteLine("{0} ist kein gültiger Befehl",command);
                    break;
            }

            return result;
        }



        private String Send(String command)
        {
            ISocket s = socketFactory.Make(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Bind(port,ip);

            var msg = Encoding.ASCII.GetBytes(command);

            s.Send(msg);

            var answer = s.Receive();

            s.Close();

            return answer;

        }

    }
}
