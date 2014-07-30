using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.Roman
{
    public class Roman
    {
        internal readonly String rNumber;

        public Roman(String romaNumber)
        {
            rNumber = romaNumber;
        }

        public override String ToString()
        {
            return rNumber;
        }

        public int Numeral()
        {
            if (rNumber == "")
            {
                return 0;
            }
            int parsedNumber = 0;
            int lastvalue = 0;

            for ( var i = 0;i < rNumber.Length;i++)
            {
                if (RomaNumberValue(rNumber[i]) == 0)
                {
                    return 0;
                }
                if (i == 0 || lastvalue > RomaNumberValue(rNumber[i]))//Addieren
                {
                    parsedNumber = parsedNumber + RomaNumberValue(rNumber[i]);
                    lastvalue = RomaNumberValue(rNumber[i]);

                }
                else//Subtrahieren
                {
                    parsedNumber = parsedNumber - lastvalue;
                    parsedNumber = parsedNumber + RomaNumberValue(rNumber[i]) - lastvalue;
                    lastvalue = RomaNumberValue(rNumber[i]);
                }
            }

            return parsedNumber;
        }

        private int RomaNumberValue(char romaNumber)
        {
            switch (romaNumber)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    return 0;

            }

        }

    }
}

//Umrechnungsregeln:

//1. Steht ein niedrigerer Wert vor einem Höheren wird Subtrahiert zb. IV = 1 5, 1<5, 5-1 = 4, IV = 4
//2. Andersherum wird Addiert zb. VI = 5 1, 5>1, 5+1 = 6, VI = 6