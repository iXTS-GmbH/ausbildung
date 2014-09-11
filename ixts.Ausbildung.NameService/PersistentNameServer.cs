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

    }
}
