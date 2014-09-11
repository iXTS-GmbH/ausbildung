using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.NameService
{
    [Serializable]
    public class Map:IMap
    {
        private Dictionary<String, String> store;

        public Map(Dictionary<String,String> map )
        {
            store = map;
        }

        public Dictionary<String,String> GetStore()
        {
            return store;
        }

        public void SetStore(Dictionary<string, string> newStore)
        {
            store = newStore;
        }
    }
}
