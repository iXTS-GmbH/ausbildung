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
            ss.Bind(port);
            ss.Listen(10);
            var run = true;

            Console.WriteLine("Server started on Port:{0}",port);

            while (run)
            {
                ConSocket = ss.Accept();
                data += ConSocket.Receive();

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


                switch (command)
                {
                    case "PUT":

                        Put(contain, request[2], key);
                        Send(oldvalue);

                        break;

                    case "GET":

                        Send(contain ? store[key] : null);

                        break;

                    case "DEL":

                        store.Remove(key);
                        Send(oldvalue);
                        
                        break;

                    case "STOP":
                        Send("");
                        run = false;
                        break;

                    default:

                        Console.WriteLine("Illegal Command recived: {0}", command);
                        ConSocket.Send(Encoding.ASCII.GetBytes(string.Format("Illegal Command: {0}",command)));

                        break;
                }

                data = "";
            }
            stream.SaveMap(store);
            ss.Close();
        }

        private void Send(String value)
        {
            String answer = value == null ? "0" : string.Format("1 {0}", value);

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
    }
}
