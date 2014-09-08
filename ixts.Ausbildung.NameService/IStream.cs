using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.NameService
{
    public interface IStream
    {
        Dictionary<String, String> LoadMap();
        void SaveMap(Dictionary<String,String> map );
    }
}
