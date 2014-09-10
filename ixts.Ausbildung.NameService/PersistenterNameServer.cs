﻿using System;
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

                    String[] parameters = data.Split(new[] { ' ' });

                    parameters = NormalizeParameters.Normalize(parameters);

                    String command = parameters[0];
                    String key = parameters.Length > 1 ? parameters[1] : null;

                    run = HandleCommands(command, key, parameters[2]);

                    stream.SaveMap(Store);

            }

            Socket.Close();
        }
    }
}
