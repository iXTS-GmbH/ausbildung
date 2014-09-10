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

            Boolean run = true;

            while (run)
            {
                String data = GetData();

                data = NormalizeData(data);

                String[] request = data.Split(new[] { ' ' });
                String command = request[0];
                String key = request.Length > 1 ? request[1] : null;

                run = HandleCommands(command, request, key);

                stream.SaveMap(Store);
            }

            Socket.Close();
        }
    }
}
