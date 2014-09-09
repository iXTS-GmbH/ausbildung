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
                
                var receive = true;
                while (receive)
                {
                    data += ConSocket.Receive();

                    if (data.IndexOf("---") > -1)
                    {
                        receive = false;
                    }
                }//Ich muss also auch enters rausschneiden

                receive = true;
                Console.WriteLine(data);
                data = data.Replace("\r\n", "");

                //while(data.IndexOf("\b") > -1) //Ich muss es hinkriegen das die löschzeichen und der gelöscht wert entfernt werden
                //{
                //    data = data.Remove(data.IndexOf("\b") - 1, data.IndexOf("\b"));
                //}

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
                        data = "";
                        break;

                    case "GET":

                        Send(contain ? store[key] : null);
                        data = "";
                        break;

                    case "DEL":

                        store.Remove(key);
                        Send(oldvalue);
                        data = "";
                        break;

                    case "STOP":
                        Send("");
                        run = false;
                        data = "";
                        break;

                    default:

                        Console.WriteLine("Illegal Command recived: {0}", command);
                        ConSocket.Send(Encoding.ASCII.GetBytes(string.Format("Illegal Command: {0}", command)));

                        break;
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
    }
}
