using System;

namespace ixts.Ausbildung.NameService
{
    public class PersistentNameServer:NameServer
    {

        private const String SERVER_FILENAME = "nameservermap.ser";
        private readonly IMapParser mapParser;

        public PersistentNameServer(int port, ISocketFactory socketFactory = null, IMapParser mapParser = null):base(port,socketFactory)
        {
            this.mapParser = mapParser ?? new MapParser(SERVER_FILENAME);
            var map = this.mapParser.LoadMap();

            if (map != null)
            {
                Store = map;
            }
        }

        protected override String Put(String newValue, String key)
        {
            var oldvalue = base.Put(newValue, key);

            mapParser.SaveMap(Store);

            return oldvalue;
        }

        protected override String Del(String key)
        {
           var value = base.Del(key);
           mapParser.SaveMap(Store);
           return value;
        }

    }
}
