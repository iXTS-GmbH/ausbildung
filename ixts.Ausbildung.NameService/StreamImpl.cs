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
            Dictionary<String,String> map = new Dictionary<String, String>();
            String[] allLines = File.ReadAllLines(serverFileName);
            foreach (String line in allLines)
            {
                String[] parameters = line.Split(' ');
                map.Add(parameters[0], parameters[1]);
            }
            return map;
        }

        public void SaveMap(Dictionary<String, String> store)
        {
            List<String> map = new List<String>();

            foreach (KeyValuePair<String, String> pair in store)
            {
                map.Add(string.Format("{0} {1}", pair.Key, pair.Value));
            }

            File.WriteAllLines(serverFileName, map.ToArray());
        }


        public bool Exists(String fileName)
        {
            return File.Exists(fileName);
        }
    }
}
