using System;
using System.Collections.Generic;
using System.IO;

namespace ixts.Ausbildung.NameService
{
    public class StreamImpl:IStream
    {
        private readonly String serverFileName;

        public StreamImpl(String fileName)
        {
            serverFileName = fileName;
        }

        public Dictionary<String, String> LoadMap()
        {
            var map = new Dictionary<String, String>();
            var allLines = File.ReadAllLines(serverFileName);
            foreach (var line in allLines)
            {
                var parameters = line.Split(' ');
                map.Add(parameters[0], parameters[1]);
            }
            return map;
        }

        public void SaveMap(Dictionary<string, string> store)
        {
            var map = new List<String>();
            foreach (var pair in store)
            {
                map.Add(string.Format("{0} {1}", pair.Key, pair.Value));
            }
            File.WriteAllLines(serverFileName, map.ToArray());
        }


        public bool Exists(string fileName)
        {
            return File.Exists(fileName);
        }
    }
}
