using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.Spielkarten
{
    public class Suit
    {
        private const int SPADE = 4;
        private const int HEART = 3;
        private const int DIAMOND = 2;
        private const int LEAF = 1;

        public static readonly Dictionary<int,String> ValueString = new Dictionary<int,String>
            {
                {SPADE,"Spade"},
                {HEART,"Heart"},
                {DIAMOND,"Diamond"},
                {LEAF,"Leaf"}
            };


        public static int Spade{get { return SPADE; }}
        public static int Heart{get { return HEART; }}
        public static int Diamond{get { return DIAMOND; }}
        public static int Leaf{get { return LEAF; }}
    }
}
