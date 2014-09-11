using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ixts.Ausbildung.NameService
{
    public class MapParser
    {
        private readonly BinaryFormatter formatter = new BinaryFormatter();
        private readonly String filename;

        public MapParser(String filename)
        {
            this.filename = filename;
        }

        public Map LoadMap()
        {
            var map = new object();
            if (Exists(filename))
            {
                var fstream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                map = formatter.Deserialize(fstream);
            }
            else
            {
                return new Map(new Dictionary<String,String>());
            }
            return (Map)map;
        }

        public void SaveMap(Map map)
        {
            var fstream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            formatter.Serialize(fstream,map);
            fstream.Close();
        }

        public static Boolean Exists(String filename)
        {
            return File.Exists(filename);
        }

    }
}