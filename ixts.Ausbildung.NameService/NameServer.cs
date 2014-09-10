using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ixts.Ausbildung.NameService
{

    public class NameServer
    {

        protected Dictionary<string, string> Store = new Dictionary<String, String>();
        protected readonly int Port;
        protected readonly ISocket Socket;
        protected ISocket ConSocket;

        public NameServer(int port, ISocketFactory socketFactory = null)
        {
            Port = port;

            socketFactory = socketFactory ?? new SocketFactory();

            Socket = socketFactory.Make(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Socket.Bind(port,false);

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

            Socket.Close();
        }

        protected void Send(String value)
        {
            String answer = value == null ? "0\r\n" : string.Format("\r\n1 {0}\r\n", value);

            byte[] msg = Encoding.ASCII.GetBytes(answer);
            ConSocket.Send(msg);
        }


        protected void Put(Boolean contain,String newValue, String key)
        {
            if (contain)
            {
                Store[key] = newValue;
            }
            else
            {
                Store.Add(key, newValue);
            }
        }

        protected String NormalizeData(String data)
        {
            data = data.Replace("\r\n", "");

            while (data.IndexOf("\b", StringComparison.Ordinal) > -1)
            {
                data = data.Remove(data.IndexOf("\b", StringComparison.Ordinal) - 1, 2);
            }
            return data;
        }

        protected void StartSocket()
        {
            Socket.Listen(10);

            Console.WriteLine("Server started on Port: {0}", Port);

            ConSocket = Socket.Accept();
        }

        protected String GetData()
        {
            Boolean receive = true;
            String data = "";

            while (receive)
            {
                data += ConSocket.Receive();

                if (data.Contains(Environment.NewLine))
                {
                    receive = false;
                }
            }

            Console.WriteLine(data);
            return data;
        }

        protected Boolean HandleCommands(String command,String[]request,String key)
        {
            if ("PUT".Equals(command, StringComparison.InvariantCultureIgnoreCase))
            {
                Boolean contain = Store.ContainsKey(key);
                Put(contain, request[2], key);
                Send(contain ? Store[key] : "");

            }
            else if ("GET".Equals(command, StringComparison.InvariantCultureIgnoreCase))
            {
                Send(Store.ContainsKey(key) ? Store[key] : null);

            }
            else if ("DEL".Equals(command, StringComparison.InvariantCultureIgnoreCase))
            {
                if (key != null)
                {
                    String oldvalue = Store[key];
                    Store.Remove(key);
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
                ConSocket.Send(Encoding.ASCII.GetBytes(string.Format("Illegal Command: {0}", command)));
            }
            return true;
        }
    }
}