using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.NameService
{
    public class PersistentNameServer:NameServer
    {

        private const String SERVER_FILENAME = "nameservermap.ser";
        private readonly IMapParser mapParser;
        private readonly Map map;

        public PersistentNameServer(int port, ISocketFactory socketFactory = null, IMapParser mapParser = null):base(port,socketFactory)
        {
            this.mapParser = mapParser ?? new MapParser(SERVER_FILENAME);
            map = this.mapParser.LoadMap();

            if (map.GetStore() == null)
            {
                map.SetStore(new Dictionary<String, String>());
            }

            Store = map.GetStore();
        }

        //Zeilen zum speichern:
        //map.SetStore(Store);
        //mapParser.SaveMap(map);

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

            map.SetStore(Store);
            mapParser.SaveMap(map);

            return oldvalue;
        }

        protected override String Del(String key)
        {
            if (key != null)
            {
                var oldvalue = Store[key];
                Store.Remove(key);

                map.SetStore(Store);
                mapParser.SaveMap(map);

                return oldvalue;
            }

            return null;
        }

    }
}
