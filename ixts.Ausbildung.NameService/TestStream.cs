using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.NameService
{
    public class TestStream:IStream
    {
        private String serverFileName;

        private Dictionary<String, String> map = new Dictionary<String, String>
            {
                {"firstKey","firstValue"},
                {"secondKey","secondValue"},
                {"thirdKey","thirdValue"},
                {"fourdKey","fourdValue"}
            }; 

        public TestStream(String fileName)
        {
            serverFileName = fileName;
        }

        public Dictionary<String, String> LoadMap()
        {
            return map;
        }

        public void SaveMap(Dictionary<String, String> store)
        {
            map = store;
        }


        public Boolean Exists(string fileName)
        {
            return true;
        }
    }
}
