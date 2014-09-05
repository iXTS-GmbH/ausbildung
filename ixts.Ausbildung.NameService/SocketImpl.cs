using System.Net;
using System.Net.Sockets;

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

        public void Bind(int port)
        {
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);
            socket.Bind(localEndPoint);
        }

        public void Listen(int backlog)
        {
            socket.Listen(backlog);
        }

        public ISocket Accept()//TODO Herausfinden was die Methode überhaupt macht
        {
            Socket s = socket.Accept();
            return new SocketImpl(s);
        }

        public int Receive(byte[] bytes)
        {
            return socket.Receive(bytes);
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
