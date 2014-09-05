using System.Net.Sockets;

namespace ixts.Ausbildung.NameService
{
    public class TestSocketFaktory:ISocketFactory
    {
        public ISocket Make(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
        {
            return new TestSocket();
        }
    }
}
