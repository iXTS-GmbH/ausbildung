using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.NameService
{
    [Serializable]
    public class Map
    {
        public Dictionary<String, String> Store;

        public Map(Dictionary<String,String> map )
        {
            Store = map;
        }

    }
}
