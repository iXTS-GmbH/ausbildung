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

        public NameClient(String serverIP, int serverPort,ISocketFactory sFactory = null)
        {
            socketFactory = sFactory ?? new SocketFactory();

            ip = serverIP == "localhost" ? null : IPAddress.Parse(serverIP);

            port = serverPort;

            s = socketFactory.Make(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Bind(port, true, ip);
        }

        public String Action(String command,String key,String value = null)
        {
            String result = null;
            String answer;

            command = command.ToUpper();

            switch (command)
            {
                case "PUT":
                    answer = Send(string.Format("PUT {0} {1}\r\n",key,value));

                    answer = answer.Replace("\r\n", "");

                    if (answer.StartsWith("1"))
                    {
                        result = answer.Substring(1).Trim();
                    }
                    else
                    {
                        result = "0";
                    }
                     
                    break;

                case "GET":

                    answer = Send(string.Format("GET {0}\r\n",key));

                    answer = answer.Replace("\r\n", "");

                    if (answer.StartsWith("1"))
                    {
                        result = answer.Substring(1).Trim();
                    }
                    else
                    {
                        result = "0";
                    }

                    break;

                case "DEL":

                    answer = Send(string.Format("DEL {0}\r\n",key));

                    answer = answer.Replace("\r\n", "");

                    if (answer.StartsWith("1"))
                    {
                        result = answer.Substring(1).Trim();
                    }
                    else
                    {
                        result = "0";
                    }

                    break;

                default:

                    throw new Exception(string.Format("{0} ist kein gültiger Befehl",command));
            }
            return result == "0" ? null : result;
        }

        private String Send(String command)
        {

            Byte[] msg = Encoding.ASCII.GetBytes(command);

            s.Send(msg);

            String answer = s.Receive();

            return answer;

        }
    }
}
