using System.Net.Sockets;

namespace ixts.Ausbildung.NameService
{
    public class SocketFactory:ISocketFactory
    {
        public ISocket Make(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
        {
            return new SocketImpl(addressFamily,socketType,protocolType);
        }
    }
}
