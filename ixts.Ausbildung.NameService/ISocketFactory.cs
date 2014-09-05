using System.Net.Sockets;

namespace ixts.Ausbildung.NameService
{
    public interface ISocketFactory
    {
        ISocket Make(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType);
    }
}
