using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ixts.Ausbildung.NameService
{

    public class NameServer
    {

        private Dictionary<string, string> store = new Dictionary<String, String>();
        private readonly int port;
        private static String data;
        private readonly ISocketFactory sFactory;
        private readonly IStream stream;
        private const String SERVERFILENAME = "nameservermap.ser";
        public ISocket ConSocket;

        public NameServer(int p, ISocketFactory socketFactory = null, IStreamFactory streamFactory = null)
        {
            streamFactory = streamFactory ?? new StreamFactory();
            sFactory = socketFactory ?? new SocketFactory();

            stream = streamFactory.Make(SERVERFILENAME);
            port = p;
            
        }

        public void Loop()
        {

            store = stream.Exists(SERVERFILENAME) ? stream.LoadMap() : new Dictionary<String, String>();

            var ss = sFactory.Make(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ss.Bind(port,false);
            ss.Listen(10);
            var run = true;

            Console.WriteLine("Server started on Port:{0}",port);

            ConSocket = ss.Accept();

            while (run)
            {

                //var a = "Hello";
                //var b = "Hello";

                //if (a.Equals(b,StringComparison.InvariantCultureIgnoreCase))
                //{

                //}

                var receive = true;
                while (receive)
                {
                    data += ConSocket.Receive();

                    if (data.IndexOf("\r\n", StringComparison.Ordinal) > -1)
                    {
                        receive = false;
                    }
                }

                Console.WriteLine(data);

                RefinereData();

                var request = data.Split(new[] { ' ' });
                var command = request[0];
                var key = request.Length > 1 ? request[1] : null;
                var contain = false;
                var oldvalue = "";

                if (key != null)
                {
                    contain = store.ContainsKey(key);
                    oldvalue = contain ? store[key] : "";
                }

                if ("PUT".Equals(command, StringComparison.InvariantCultureIgnoreCase))
                {
                    Put(contain, request[2], key);
                    Send(oldvalue);

                }
                else if ("GET".Equals(command, StringComparison.InvariantCultureIgnoreCase))
                {
                    Send(contain ? store[key] : null);

                }
                else if ("DEL".Equals(command, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (key != null)
                    {
                        store.Remove(key);
                        Send(oldvalue);
                    }

                }
                else if ("STOP".Equals(command, StringComparison.InvariantCultureIgnoreCase))
                {
                    Send("");
                    run = false;
                }
                else
                {
                    Console.WriteLine("Illegal Command recived: {0}", command);
                    ConSocket.Send(Encoding.ASCII.GetBytes(string.Format("Illegal Command: {0}", command)));
                }

                data = "";
            }

            ss.Close();
        }

        private void Send(String value)
        {
            String answer = value == null ? "0" : string.Format("\r\n1 {0}\r\n", value);

            stream.SaveMap(store);

            byte[] msg = Encoding.ASCII.GetBytes(answer);
            ConSocket.Send(msg);
        }


        private void Put(Boolean contain,String newValue, String key)
        {
            if (contain)
            {
                store[key] = newValue;
            }
            else
            {
                store.Add(key, newValue);
            }
        }

        private void RefinereData()
        {
            data = data.Replace("\r\n", "");

            while (data.IndexOf("\b", StringComparison.Ordinal) > -1)
            {
                data = data.Remove(data.IndexOf("\b", StringComparison.Ordinal) - 1, 2);
            }
        }
    }
}


// command = command.ToUpper();
//
//switch (command) //Protokolverarbeitung als Switch
//{
//    case "PUT":

//        Put(contain, request[2], key);
//        Send(oldvalue);

//        break;

//    case "GET":

//        Send(contain ? store[key] : null);

//        break;

//    case "DEL":
//        if (key != null)
//        {
//            store.Remove(key);
//            Send(oldvalue);
//        }

//        break;

//    case "STOP":
//        Send("");
//        run = false;

//        break;

//    default:

//        Console.WriteLine("Illegal Command recived: {0}", command);
//        ConSocket.Send(Encoding.ASCII.GetBytes(string.Format("Illegal Command: {0}", command)));

//        break;
//}