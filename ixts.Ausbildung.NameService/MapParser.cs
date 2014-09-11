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

        public IMap LoadMap()
        {
            var map = new object();

            if (File.Exists(filename))
            {
                var fstream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                map = formatter.Deserialize(fstream);
            }
            else
            {
                map = new Map(new Dictionary<String,String>());
            }

            return (Map)map;
        }

        public void SaveMap(IMap map)
        {
            var fstream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            formatter.Serialize(fstream,map);
            fstream.Close();
        }
    }
}