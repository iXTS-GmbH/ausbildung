﻿using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.NameService.Test
{
    public class TestMapParser:IMapParser
    {
        public static Dictionary<String, String> Store; 

        public IMap LoadMap()
        {
            return new Map(Store);
        }

        public void SaveMap(IMap map)
        {
            Store = map.GetStore();
        }
    }
}