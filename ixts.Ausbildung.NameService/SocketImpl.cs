using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ixts.Ausbildung.NameService
{
    public class SocketImpl:ISocket
    {
        private readonly Socket socket;
        private const int BUFFER_SIZE = 1024;

        public SocketImpl(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
        {
            socket = new Socket(addressFamily,socketType,protocolType);
        }

        public SocketImpl(Socket s)
        {
            socket = s;
        }

        public void Bind(int port,Boolean client, IPAddress ip = null)
        {

            if (ip == null)
            {
                ip = IPAddress.Any;
            }

            var endPoints = new IPEndPoint(ip, port);

            if (client)
            {
                socket.Connect(endPoints);
            }
            else
            {
                socket.Bind(endPoints);
            }
        }

        public void Listen(int backlog)
        {
            socket.Listen(backlog);
        }

        public ISocket Accept()
        {
            return new SocketImpl(socket.Accept());
        }

        public String Receive()
        {
            var bytes = new byte[BUFFER_SIZE];
            var bytesRec = socket.Receive(bytes);

            return Encoding.UTF8.GetString(bytes, 0, bytesRec);
        }

        public void Send(String msg)
        {
            socket.Send(Encoding.UTF8.GetBytes(msg));
        }


        public void Close()
        {
            socket.Close();
        }
    }
}
