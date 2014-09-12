﻿using System;
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
                var data = GetData();

                data = NormalizeData(data);

                var parameters = data.Split(new[] { ' ' });

                parameters = ParameterHandler.Normalize(parameters);

                var command = parameters[0];
                var key = parameters.Length > 1 ? parameters[1] : null;
                var value = parameters.Length > 2 ? parameters[2] : null;

                run = HandleCommands(command, key, value);
            }

            Socket.Close();
        }

        protected void Send(String msg, Boolean check = false)//TODO Send in Snedsuccess und sendFailed aufspalten
        {
            if (!check)
            {
               msg = msg == null ? string.Format("{0}0{0}",Environment.NewLine) : string.Format("{1}1 {0}{1}", msg,Environment.NewLine);
            }

            ConSocket.Send(msg);
        }


        protected virtual String Put(String newValue, String key)
        {
            var oldvalue = "";

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
            Console.WriteLine("Illegal Command recived: {0}", command);

            return string.Format("{1}Illegal Command: {0}{1}", command, Environment.NewLine);
        }

        protected String NormalizeData(String data)
        {
            data = data.Replace(Environment.NewLine, "");

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
            var receive = true;
            var data = "";

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
                Send(IllegalCommand(command),true);
            }
            return true;
        }
    }
}