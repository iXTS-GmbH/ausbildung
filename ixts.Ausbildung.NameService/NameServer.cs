using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace ixts.Ausbildung.NameService
{

    public class NameServer
    {

        protected Dictionary<String, String> Store = new Dictionary<String, String>();
        protected readonly int Port;
        protected readonly ISocket Socket;
        protected ISocket ConSocket;
        protected const String COMMAND_PUT = "PUT";
        protected const String COMMAND_GET = "GET";
        protected const String COMMAND_DEL = "DEL";
        protected const String COMMAND_STOP = "STOP";
        protected const String COMMAND_ILLEGAL = "Illegal Command: ";
        protected const String SEND_SUCCEESS = "1 ";
        protected const String SEND_FAILED = "0";
        protected const String SERVER_STARTED_MESSAGE = "Server started on Port: ";
        protected const String DELETED_CHAR_MARKER = "\b";
        protected const char PARAMETER_DELIMITER = ' ';

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

            var run = true;

            while (run)
            {
                var parameters = GetParameters();

                run = HandleCommands(parameters[0],parameters[1],parameters[2]);//TODO Gleich ganzes array übergeben
            }

            Socket.Close();
        }

        protected void Send(String msg)
        {
            if (msg == null )
            {
                SendFailed();
            }
            else
            {
                SendSuccess(msg);
            }
        }

        protected void SendSuccess(String msg)
        {
            ConSocket.Send(msg.Contains(COMMAND_ILLEGAL)? string.Format("{1}{0}{1}", msg, Environment.NewLine): string.Format("{1}{2}{0}{1}", msg, Environment.NewLine, SEND_SUCCEESS));                     
        }

        protected void SendFailed()
        {
            ConSocket.Send(string.Format("{0}{1}{0}",Environment.NewLine,SEND_FAILED));
        }

        protected virtual String Put(String newValue, String key)
        {
            var oldvalue = string.Empty;

            if (Store.ContainsKey(key))
            {
                oldvalue = Store[key];
                Store[key] = newValue;
            }
            else
            {
                Store.Add(key, newValue);
            }

            return oldvalue;
        }

        protected virtual String Del(String key)
        {
            if (key != null)
            {
                var oldvalue = Store[key];
                Store.Remove(key);
                return oldvalue;
            }

            return null;
        }

        protected String Get(String key)
        {
            return Store.ContainsKey(key) ? Store[key] : null;
        }

        protected Boolean Stop()
        {
            return false;
        }

        protected String IllegalCommand(String command)
        {
            Console.WriteLine("{1}{0}", command,COMMAND_ILLEGAL);

            return string.Format("{1}{0}", command,COMMAND_ILLEGAL);
        }

        protected String NormalizeData(String data)
        {
            data = data.Replace(Environment.NewLine, String.Empty);

            while (data.Contains(DELETED_CHAR_MARKER))
            {
                data = data.Remove(data.IndexOf(DELETED_CHAR_MARKER, StringComparison.CurrentCulture) - 1, 2);
            }

            return data;
        }

        protected void StartSocket()
        {
            Socket.Listen(10);//TODO Magic Number

            Console.WriteLine("{0}{1}", SERVER_STARTED_MESSAGE,Port);

            ConSocket = Socket.Accept();
        }

        protected String[] GetParameters()//TODO GETParameter in Parameterhandler zusammenfügen
        {
            var data = string.Empty;

            for (;;)
            {
                data += ConSocket.Receive();

                if (data.Contains(Environment.NewLine))
                {
                    Console.WriteLine(data);

                    return ParameterHandler.Normalize(NormalizeData(data).Split(new[] {PARAMETER_DELIMITER}));//TODO Normalisieren zusammenfügen
                }
            }
        }

        protected Boolean HandleCommands(String command,String key, String value)
        {
            if (COMMAND_PUT.Equals(command, StringComparison.InvariantCultureIgnoreCase))
            {                
                Send(Put(value, key));
            }
            else if (COMMAND_GET.Equals(command, StringComparison.InvariantCultureIgnoreCase))
            {
                Send(Get(key));
            }
            else if (COMMAND_DEL.Equals(command, StringComparison.InvariantCultureIgnoreCase))
            {
                Send(Del(key));
            }
            else if (COMMAND_STOP.Equals(command, StringComparison.InvariantCultureIgnoreCase))
            {
                return Stop();
            }
            else
            {
                Send(IllegalCommand(command));
            }
            return true;
        }
    }
}