using System;
using System.Net.Sockets;

namespace ixts.Ausbildung.NameService
{
    public interface ISocket
    {
        void Bind(int port);
        void Listen(int backlog);
        ISocket Accept();
        String Receive();
        void Send(Byte[] msg);
        void Close();

    }
}
