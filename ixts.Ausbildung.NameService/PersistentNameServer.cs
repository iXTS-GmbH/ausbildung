using System;

namespace ixts.Ausbildung.NameService
{
    public class PersistentNameServer:NameServer
    {

        private const String SERVER_FILENAME = "nameservermap.ser";

        public PersistentNameServer(int port, ISocketFactory socketFactory = null):base(port,socketFactory)
        {
            var mparser = new MapParser(SERVER_FILENAME);
            Store = mparser.LoadMap().Store;
        }
    }
}
