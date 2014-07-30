using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.Roman
{
    public class Roman
    {
        internal readonly String rNumber;
        internal readonly int nNumber;
        //toLiteral macht aus numerischen Zahlen römische
        // 4 Methoden für +,-,x,/
        public Roman(String romaNumber)
        {
            rNumber = romaNumber;
            nNumber = Numeral();
        }

        public Roman(int numericNumber)
        {
            if (numericNumber > 0)
            {
                nNumber = numericNumber;
            }
            else
            {
                throw new ArgumentException("Parameter darf nicht negativ sein");
            }
            
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

        public String ToLiteral()
        {
            List<char> parsedNumber = new List<char>();
            int toParseNumber = nNumber;
            while (toParseNumber > 0)
            {
                if (toParseNumber == 4) //IV
                {
                    toParseNumber = toParseNumber - 4;
                    parsedNumber.Add('I');
                    parsedNumber.Add('V');
                }
                else
                {
                    if (toParseNumber >= 1 && toParseNumber < 5)//I == 1
                    {
                        toParseNumber = toParseNumber - 1;
                        parsedNumber.Add('I');
                    }
                }
                if (toParseNumber == 9)//IX == 9
                {
                }
                else
                {
                    if (toParseNumber >= 5 && toParseNumber < 10)//V == 5
                    {
                    }
                }
                if (toParseNumber >= 40 && toParseNumber < 50)//XL == 40
                {
                }
                else
                {
                    if (toParseNumber >= 10 && toParseNumber < 50)//X == 10
                    {
                    }  
                }
                if (toParseNumber >= 90 && toParseNumber < 100)// XC == 90
                {
                }
                else
                {
                    if (toParseNumber >= 50 && toParseNumber < 100) //L == 50
                    {
                    }
                }
                if (toParseNumber >= 400 && toParseNumber < 500) // CD == 400
                {
                }
                else
                {
                    if (toParseNumber >= 100 && toParseNumber < 500) //C == 100
                    {
                    } 
                }
                if (toParseNumber >= 900 && toParseNumber < 1000) //CM == 900
                {
                }
                if (toParseNumber >= 500 && toParseNumber < 1000) //D == 500
                {
                }
                if (toParseNumber < 1000)//M == 100
                {
                }
            }


            return "";
        }

    }
}

//Umrechnungsregeln:

//1. Steht ein niedrigerer Wert vor einem Höheren wird Subtrahiert zb. IV = 1 5, 1<5, 5-1 = 4, IV = 4
//2. Andersherum wird Addiert zb. VI = 5 1, 5>1, 5+1 = 6, VI = 6