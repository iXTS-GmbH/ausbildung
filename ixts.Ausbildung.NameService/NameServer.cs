﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ixts.Ausbildung.NameService
{

    public class NameServer
    {

        private readonly Dictionary<string, string> store = new Dictionary<String, String>();
        private readonly int port;
        private static String data;
        private ISocketFactory sFactory;
        public ISocket ConSocket;

        public NameServer(int p, ISocketFactory socketFactory = null)
        {
            sFactory = socketFactory ?? new SocketFactory();
            store = new Dictionary<string, string>();
            port = p;
            
        }

        public void Loop()
        {
            var ss = sFactory.Make(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ss.Bind(port);
            ss.Listen(10);
            Boolean run = true;

            Console.WriteLine("Server started on Port:{0}",port);

            while (run)
            {
                ConSocket = ss.Accept();
                byte[] bytes = new byte[1024];
                int bytesRec = ConSocket.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);//Das müssten die Daten sein

                String[] request = data.Split(new[] { ' ' });
                String command = request[0];
                String key = request.Length > 1 ? request[1] : null;

                if (key != null)
                {

                    Boolean contain = store.ContainsKey(key);
                    String oldvalue = contain ? store[key] : "";

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

                            Console.WriteLine("Illegal command recived: {0}",command);

                            break;
                    }
                }
                else
                {
                    throw new Exception("No Key Found");
                }

            }
            ss.Close();
        }

        public void Send(String value, ISocket socket)
        {
            String answer = value == null ? "0" : string.Format("1 {0}", value);

            byte[] msg = Encoding.ASCII.GetBytes(answer);
            socket.Send(msg);
        }


        public void Put(Boolean contain,String newValue, String key,String oldvalue, ISocket socket)
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

        public void Get(Boolean contain, String key, ISocket socket)
        {
            var value = contain ? store[key] : null;
            Send(value,socket);
        }

        public void Del(Boolean contain, String key, String oldvalue, ISocket socket)
        {
            store.Remove(key);
            var value = contain ? oldvalue : null;
            Send(value,socket);
        }

        public Boolean Stop(ISocket socket)
        {
            Send("",socket);
            return false;
        }

    }
}
