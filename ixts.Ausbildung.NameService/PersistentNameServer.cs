using System;

namespace ixts.Ausbildung.NameService
{
    public class PersistentNameServer:NameServer
    {

        private const String SERVER_FILENAME = "nameservermap.ser";
        private MapParser mapParser;
        private Map map;

        public PersistentNameServer(int port, ISocketFactory socketFactory = null):base(port,socketFactory)
        {
            mapParser = new MapParser(SERVER_FILENAME);
            map = mapParser.LoadMap();
            Store = map.Store;
        }


        public new void Loop()
        {
            StartSocket();

            var run = true;

            while (run)
            {
                var data = GetData();

                data = NormalizeData(data);

                var parameters = data.Split(new[] { ' ' });

                parameters = ParameterHandler.Normalize(parameters);

                var command = parameters[0];
                var key = parameters.Length > 1 ? parameters[1] : null;
                var value = parameters.Length > 2 ? parameters[2] : null;

                if (command.Equals(COMMAND_PUT,StringComparison.InvariantCultureIgnoreCase) || command.Equals(COMMAND_DEL,StringComparison.InvariantCultureIgnoreCase))
                {
                    map.Store = Store;
                    mapParser.SaveMap(map);
                }
                run = HandleCommands(command, key, value);
            }

            Socket.Close();
        }

    }
}
