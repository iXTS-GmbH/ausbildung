using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.Spielkarten
{
    public class Kind
    {
        private const int ACE = 14;
        private const int KING = 13;
        private const int QUEEN = 12;
        private const int JACK = 11;
        private const int NUM10 = 10;
        private const int NUM9 = 9;
        private const int NUM8 = 8;
        private const int NUM7 = 7;
        private const int NUM6 = 6;
        private const int NUM5 = 5;
        private const int NUM4 = 4;
        private const int NUM3 = 3;
        private const int NUM2 = 2;

        public static readonly Dictionary<int,String> ValueString = new Dictionary<int,String>
            {
                {14,"A"},
                {13,"K"},
                {12,"Q"},
                {11,"J"},
                {10,"N10"},
                {9,"N9"},
                {8,"N8"},
                {7,"N7"},
                {6,"N6"},
                {5,"N5"},
                {4,"N4"},
                {3,"N3"},
                {2,"N2"}
            };

        public static int A { get { return ACE; } }
        public static int K { get { return KING; } }
        public static int Q { get { return QUEEN; } }
        public static int J { get { return JACK; } }
        public static int N10 { get { return NUM10; } }
        public static int N9 { get { return NUM9; } }
        public static int N8 { get { return NUM8; } }
        public static int N7 { get { return NUM7; } }
        public static int N6 { get { return NUM6; } }
        public static int N5 { get { return NUM5; } }
        public static int N4 { get { return NUM4; } }
        public static int N3 { get { return NUM3; } }
        public static int N2 { get { return NUM2; } }
    }
}
