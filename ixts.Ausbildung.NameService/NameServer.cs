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
        protected const int MAX_WORKABLE_CLIENTS = 10;
        private Boolean run = true;

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

            while (run)
            {
                var parameters = ParameterHandler.GetParameters(ConSocket);

                run = HandleCommands(parameters);
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

        protected Boolean HandleStop()
        {
            return false;
        }

        protected String HandleIllegalCommand(String command)
        {
            var response = string.Concat(COMMAND_ILLEGAL, command);

            Console.WriteLine(response);

            return response;
        }

        protected void StartSocket()
        {
            Socket.Listen(MAX_WORKABLE_CLIENTS);

            Console.WriteLine("{0}{1}", SERVER_STARTED_MESSAGE,Port);

            ConSocket = Socket.Accept();
        }

        protected Boolean HandleCommands(String[] parameters)
        {
            var command = parameters[0];
            var key = parameters[1];
            var value = parameters[2];

            command = command.ToUpper();

            switch (command)
            {
                case Constants.COMMAND_PUT:
                    Send(Put(key, value));
                    break;

                case Constants.COMMAND_GET:
                    Send(Get(key));
                    break;

                case Constants.COMMAND_DEL:
                    Send(Del(key));
                    break;

                case Constants.COMMAND_STOP:
                    return HandleStop();

                default:
                    Send(HandleIllegalCommand(command));
                    break;
            }
            return true;
        }

        public void Stop()
        {
            run = false;
            Socket.Close();
        }
    }
}