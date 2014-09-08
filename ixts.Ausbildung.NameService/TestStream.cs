using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.NameService
{
    public class TestStream:IStream
    {
        public static Dictionary<String,String> ServerFile = new Dictionary<String, String>(); 
        private String serverFileName;
        public static Dictionary<String, String> Map = new Dictionary<String, String>(); 

        public TestStream(String fileName)
        {
            serverFileName = fileName;
        }

        public Dictionary<String, String> LoadMap()
        {
            return Map;
        }

        public void SaveMap(Dictionary<String, String> store)
        {
            ServerFile = store;
        }


        public Boolean Exists(string fileName)
        {
            return true;
        }
    }
}
