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
        private ISocketFactory sFactory;
        private IStream stream;
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

            if (stream.Exists(SERVERFILENAME))
            {
                store = stream.LoadMap();
            }
            else
            {
                store = new Dictionary<String, String>();
            }

            var ss = sFactory.Make(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ss.Bind(port);
            ss.Listen(10);
            Boolean run = true;

            Console.WriteLine("Server started on Port:{0}",port);

            while (run)
            {
                ConSocket = ss.Accept();
                data += ConSocket.Receive();

                String[] request = data.Split(new[] { ' ' });
                String command = request[0];
                String key = request.Length > 1 ? request[1] : null;
                Boolean contain = false;
                String oldvalue = "";

                if (key != null)
                {
                    contain = store.ContainsKey(key);
                    oldvalue = contain ? store[key] : "";
                }


                switch (command)
                {
                    case "PUT":

                        Put(contain, request[2], key,oldvalue,ConSocket);
                        break;

                    case "GET":

                        Get(contain, key,ConSocket);
                        break;

                    case "DEL":

                        Del(contain, key,oldvalue,ConSocket);
                        break;

                    case "STOP":

                        run = Stop(ConSocket);
                        break;

                    default:

                        Console.WriteLine("Illegal Command recived: {0}", command);
                        ConSocket.Send(Encoding.ASCII.GetBytes(string.Format("Illegal Command: {0}",command)));

                        break;
                }

                data = "";
            }
            ss.Close();
        }

        private void Send(String value, ISocket socket)
        {
            String answer = value == null ? "0" : string.Format("1 {0}", value);

            byte[] msg = Encoding.ASCII.GetBytes(answer);
            socket.Send(msg);
        }


        private void Put(Boolean contain,String newValue, String key,String oldvalue, ISocket socket)
        {
            if (contain)
            {
                store[key] = newValue;
            }
            else
            {
                store.Add(key, newValue);
            }
            Send(oldvalue,socket);
        }

        private void Get(Boolean contain, String key, ISocket socket)
        {
            var value = contain ? store[key] : null;
            Send(value,socket);
        }

        private void Del(Boolean contain, String key, String oldvalue, ISocket socket)
        {
            store.Remove(key);
            var value = contain ? oldvalue : null;
            Send(value,socket);
        }

        private Boolean Stop(ISocket socket)
        {
            stream.SaveMap(store);

            Send("",socket);
            return false;
        }
    }
}
