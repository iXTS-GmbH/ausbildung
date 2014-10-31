using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.Spielkarten
{
    public class Suit
    {
        private static readonly Dictionary<String,int> keyValue = new Dictionary<string, int>
            {
                {"Spade",4},
                {"Heart",3},
                {"Diamond",2},
                {"Leaf",1}
            };

        public static int Spade{get { return keyValue["Spade"]; }}
        public static int Heart{get { return keyValue["Heart"]; }}
        public static int Diamond{get { return keyValue["Diamond"]; }}
        public static int Leaf{get { return keyValue["Leaf"]; }}
    }
}
