using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ixts.Ausbildung.NameService
{
    public class MapParser:IMapParser
    {
        private readonly BinaryFormatter formatter = new BinaryFormatter();
        private readonly String filename;

        public MapParser(String filename)
        {
            this.filename = filename;
        }

        public Dictionary<String,String> LoadMap()
        {
            if (File.Exists(filename))
            {
                var fstream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                var map = formatter.Deserialize(fstream);
                fstream.Close();

                return (Dictionary<String, String>) map;
            }

            return new Dictionary<String,String>();
        }

        public void SaveMap(Dictionary<String,String> map)
        {
            var fstream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            formatter.Serialize(fstream,map);
            fstream.Close();
        }
    }
}