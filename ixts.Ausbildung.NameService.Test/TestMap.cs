﻿using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.NameService.Test
{
    public class TestMap:IMap
    {
        public static Dictionary<String, String> Store;

        public TestMap(Dictionary<String,String> map )
        {
            Store = map;
        }

        public Dictionary<string, string> GetStore()
        {
            return Store;
        }
    }
}