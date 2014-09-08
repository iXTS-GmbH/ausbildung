using System.Net.Sockets;

namespace ixts.Ausbildung.NameService
{
    public class TestSocketFactory:ISocketFactory
    {
        public ISocket Make(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
        {
            return new TestSocket();
        }
    }
}
