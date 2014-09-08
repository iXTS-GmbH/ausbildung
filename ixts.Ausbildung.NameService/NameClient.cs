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

        public NameClient(String serverIP, int serverPort,ISocketFactory sFactory = null)
        {
            socketFactory = sFactory ?? new SocketFactory();

            if (serverIP == "localhost")
            {
                ip = null;
            }
            else
            {
                ip = IPAddress.Parse(serverIP);
            }

            port = serverPort;
        }

        public String Action(String command,String key,String value = null)
        {
            String result = null;
            String answer;

            command = command.ToUpper();

            switch (command)
            {
                case "PUT":
                    answer = Send(string.Format("PUT {0} {1}",key,value));

                    if (answer.StartsWith("1"))
                    {
                        result = answer.Substring(1).Trim();
                    }
                     
                    break;

                case "GET":

                    answer = Send(string.Format("GET {0}",key));

                    if (answer.StartsWith("1"))
                    {
                        result = answer.Substring(1).Trim();
                    }

                    break;

                case "DEL":

                    answer = Send(string.Format("DEL {0}",key));

                    if (answer.StartsWith("1"))
                    {
                        result = answer.Substring(1).Trim();
                    }

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
