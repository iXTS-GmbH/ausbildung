using System;
using System.Net;

namespace ixts.Ausbildung.NameService
{
    public interface ISocket
    {
        void Bind(int port, IPAddress ip = null);
        void Listen(int backlog);
        ISocket Accept();
        String Receive();
        void Send(Byte[] msg);
        void Close();

    }
}
