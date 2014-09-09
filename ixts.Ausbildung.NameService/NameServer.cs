using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ixts.Ausbildung.NameService
{

    public class NameServer
    {

        private readonly Dictionary<string, string> store = new Dictionary<String, String>();
        private readonly int port;
        private readonly IStream stream;
        private readonly ISocket socket;
        private const String SERVER_FILENAME = "nameservermap.ser";
        private ISocket conSocket;

        public NameServer(int port, ISocketFactory socketFactory = null, IStreamFactory streamFactory = null)
        {
            this.port = port;

            streamFactory = streamFactory ?? new StreamFactory();
            socketFactory = socketFactory ?? new SocketFactory();

            stream = streamFactory.Make(SERVER_FILENAME);

            store = stream.Exists(SERVER_FILENAME) ? stream.LoadMap() : new Dictionary<String, String>();

            socket = socketFactory.Make(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Bind(port,false);

        }

        public void Loop()
        {
            StartSocket();

            Boolean run = true;

            while (run)
            {
                String data = GetData();

                data = NormalizeData(data);

                String[] request = data.Split(new[] { ' ' });
                String command = request[0];
                String key = request.Length > 1 ? request[1] : null;

                run = HandleCommands(command, request, key);
            }

            socket.Close();
        }

        private void Send(String value)
        {
            String answer = value == null ? "0\r\n" : string.Format("\r\n1 {0}\r\n", value);

            stream.SaveMap(store);

            byte[] msg = Encoding.ASCII.GetBytes(answer);
            conSocket.Send(msg);
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

        private String NormalizeData(String data)
        {
            data = data.Replace("\r\n", "");

            while (data.IndexOf("\b", StringComparison.Ordinal) > -1)
            {
                data = data.Remove(data.IndexOf("\b", StringComparison.Ordinal) - 1, 2);
            }
            return data;
        }

        private void StartSocket()
        {
            socket.Listen(10);

            Console.WriteLine("Server started on Port: {0}", port);

            conSocket = socket.Accept();
        }

        private String GetData()
        {
            Boolean receive = true;
            String data = "";

            while (receive)
            {
                data += conSocket.Receive();

                if (data.Contains(Environment.NewLine))
                {
                    receive = false;
                }
            }

            Console.WriteLine(data);
            return data;
        }

        private Boolean HandleCommands(String command,String[]request,String key)
        {
            if ("PUT".Equals(command, StringComparison.InvariantCultureIgnoreCase))
            {
                Boolean contain = store.ContainsKey(key);
                Put(contain, request[2], key);
                Send(contain ? store[key] : "");

            }
            else if ("GET".Equals(command, StringComparison.InvariantCultureIgnoreCase))
            {
                Send(store.ContainsKey(key) ? store[key] : null);

            }
            else if ("DEL".Equals(command, StringComparison.InvariantCultureIgnoreCase))
            {
                if (key != null)
                {
                    String oldvalue = store[key];
                    store.Remove(key);
                    Send(oldvalue);
                }

            }
            else if ("STOP".Equals(command, StringComparison.InvariantCultureIgnoreCase))
            {
                Send("");
                return false;
            }
            else
            {
                Console.WriteLine("Illegal Command recived: {0}", command);
                conSocket.Send(Encoding.ASCII.GetBytes(string.Format("Illegal Command: {0}", command)));
            }
            return true;
        }
    }
}