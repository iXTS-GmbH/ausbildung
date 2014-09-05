using System;
using System.Net.Sockets;

namespace ixts.Ausbildung.NameService
{
    public interface ISocket
    {
        void Bind(int port);
        void Listen(int backlog);
        ISocket Accept();
        int Receive(Byte[] bytes);//Gibt die Anzahl der zu Decodierenden Bytes an
        void Send(Byte[] msg);
        void Close();

    }
}
