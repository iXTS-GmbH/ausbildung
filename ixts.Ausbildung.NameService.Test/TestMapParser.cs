using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.NameService.Test
{
    public class TestMapParser:IMapParser
    {
        public static Dictionary<String, String> Store = new Dictionary<String, String>();

        public Dictionary<String, String> LoadMap()
        {
            return Store;
        }

        public void SaveMap(Dictionary<String, String> map)
        {
            Store = map;
        }
    }
}
