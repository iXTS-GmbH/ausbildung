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
        protected const String COMMAND_ILLEGAL = "Illegal Command: ";
        protected const String SERVER_STARTED_MESSAGE = "Server started on Port: ";

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

                run = HandleCommands(parameters);//TODO Gleich ganzes array übergeben
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
            ConSocket.Send(msg.Contains(COMMAND_ILLEGAL) ? string.Format("{1}{0}{1}", msg, Environment.NewLine) : string.Format("{1}{2}{0}{1}", msg, Environment.NewLine, Constants.SEND_SUCCEESS));                     
        }

        protected void SendFailed()
        {
            ConSocket.Send(string.Format("{0}{1}{0}", Environment.NewLine, Constants.SEND_FAILED));
        }

        protected virtual String Put(String key, String newValue)
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

            while (data.Contains(Constants.DELETED_CHAR_MARKER))
            {
                data = data.Remove(data.IndexOf(Constants.DELETED_CHAR_MARKER, StringComparison.CurrentCulture) - 1, 2);
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

                    return ParameterHandler.Normalize(NormalizeData(data).Split(new[] {Constants.PARAMETER_DELIMITER}));//TODO Normalisieren zusammenfügen
                }
            }
        }

        protected Boolean HandleCommands(String[] parameters)
        {
            var command = parameters[0];
            var key = parameters[1];
            var value = parameters[2];

            if (Constants.COMMAND_PUT.Equals(command, StringComparison.InvariantCultureIgnoreCase))
            {                
                Send(Put(key, value));
            }
            else if (Constants.COMMAND_GET.Equals(command, StringComparison.InvariantCultureIgnoreCase))
            {
                Send(Get(key));
            }
            else if (Constants.COMMAND_DEL.Equals(command, StringComparison.InvariantCultureIgnoreCase))
            {
                Send(Del(key));
            }
            else if (Constants.COMMAND_STOP.Equals(command, StringComparison.InvariantCultureIgnoreCase))
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