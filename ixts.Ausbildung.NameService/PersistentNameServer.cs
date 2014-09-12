using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.NameService
{
    public class PersistentNameServer:NameServer
    {

        private const String SERVER_FILENAME = "nameservermap.ser";
        private readonly IMapParser mapParser;

        public PersistentNameServer(int port, ISocketFactory socketFactory = null, IMapParser mapParser = null):base(port,socketFactory)
        {
            this.mapParser = mapParser ?? new MapParser(SERVER_FILENAME);
           Dictionary<String,String> map = this.mapParser.LoadMap();

            if (map != null)
            {
                Store = map;
            }
        }

        protected override String Put(String newValue, String key)
        {
            var oldvalue = "";

            if (Store.ContainsKey(key))
            {
                oldvalue = Store[key];
                Store[key] = newValue;
            }
            else
            {
                Store.Add(key, newValue);
            }

            mapParser.SaveMap(Store);

            return oldvalue;
        }

        protected override String Del(String key)
        {
            if (key != null)
            {
                var oldvalue = Store[key];
                Store.Remove(key);

                mapParser.SaveMap(Store);

                return oldvalue;
            }

            return null;
        }

    }
}
