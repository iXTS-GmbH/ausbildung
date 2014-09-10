using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.NameService
{
    public class PersistenterNameServer:NameServer
    {

        private const String SERVER_FILENAME = "nameservermap.ser";
        private readonly IStream stream;

        public PersistenterNameServer(int port, ISocketFactory socketFactory = null,IStreamFactory streamFactory = null):base(port,socketFactory)
        {
            streamFactory = streamFactory ?? new StreamFactory();
            stream = streamFactory.Make(SERVER_FILENAME);
            Store = stream.Exists(SERVER_FILENAME) ? stream.LoadMap() : new Dictionary<String, String>();
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

                run = HandleCommands(command, key, value);

                stream.SaveMap(Store);

            }

            Socket.Close();
        }
    }
}
