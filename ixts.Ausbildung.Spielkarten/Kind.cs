using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.Spielkarten
{
    public class Kind
    {
        private static readonly Dictionary<String,int> keyValue = new Dictionary<string, int>
            {
                {"A",14},
                {"K",13},
                {"Q",12},
                {"J",11},
                {"N10",10},
                {"N9",9},
                {"N8",8},
                {"N7",7},
                {"N6",6},
                {"N5",5},
                {"N4",4},
                {"N3",3},
                {"N2",2}
            };

        public static int A { get { return keyValue["A"]; } }
        public static int K { get { return keyValue["K"]; } }
        public static int Q { get { return keyValue["Q"]; } }
        public static int J { get { return keyValue["J"]; } }
        public static int N10 { get { return keyValue["N10"]; } }
        public static int N9 { get { return keyValue["N9"]; } }
        public static int N8 { get { return keyValue["N8"]; } }
        public static int N7 { get { return keyValue["N7"]; } }
        public static int N6 { get { return keyValue["N6"]; } }
        public static int N5 { get { return keyValue["N5"]; } }
        public static int N4 { get { return keyValue["N4"]; } }
        public static int N3 { get { return keyValue["N3"]; } }
        public static int N2 { get { return keyValue["N2"]; } }
    }
}
