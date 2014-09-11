
using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.NameService
{
    public interface IMap
    {
        Dictionary<String, String> GetStore();
        void SetStore(Dictionary<String,String> newStore); 
    }
}
