﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ixts.Ausbildung.NameService
{
    public class SocketImpl:ISocket
    {
        private readonly Socket socket;

        public SocketImpl(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
        {
            socket = new Socket(addressFamily,socketType,protocolType);
        }

        public SocketImpl(Socket s)
        {
            socket = s;
        }

        public void Bind(int port, IPAddress ip = null)
        {
            if (ip == null)
            {
            var ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ip = ipHostInfo.AddressList[0];
            }
            
            var localEndPoint = new IPEndPoint(ip, port);
            socket.Bind(localEndPoint);
        }

        public void Listen(int backlog)
        {
            socket.Listen(backlog);
        }

        public ISocket Accept()
        {
            Socket s = socket.Accept();
            return new SocketImpl(s);
        }

        public String Receive()
        {
            byte[] bytes = new byte[1024];
            int bytesRec = socket.Receive(bytes);
            return Encoding.ASCII.GetString(bytes, 0, bytesRec);
             
        }

        public void Send(byte[] msg)
        {
            socket.Send(msg);
        }


        public void Close()
        {
            socket.Close();
        }
    }
}
