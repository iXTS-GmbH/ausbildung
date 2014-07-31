using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.Roman
{
    public class Roman
    {
        private const int I = 1;
        private const int V = 5;
        private const int X = 10;
        private const int L = 50;
        private const int C = 100;
        private const int D = 500;
        private const int M = 1000;
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
            if (numericNumber >= 0)
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
                throw new ArgumentException("Übergebener String ist leer");
            }
            int parsedNumber = 0;
            int lastvalue = 0;

            for ( var i = 0;i < rNumber.Length;i++)
            {
                if (i == 0 || lastvalue > RomaNumberValue(rNumber[i]))//Addieren
                {
                    parsedNumber += RomaNumberValue(rNumber[i]);
                    lastvalue += RomaNumberValue(rNumber[i]);

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
                    return I;
                case 'V':
                    return V;
                case 'X':
                    return X;
                case 'L':
                    return L;
                case 'C':
                    return C;
                case 'D':
                    return D;
                case 'M':
                    return M;
                default:
                    throw new ArgumentException(string.Format("{0} ist kein gültiges Zeichen für eine Römische Zahl",romaNumber));
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
                    toParseNumber -= (V - I);
                    parsedNumber.Add('I');
                    parsedNumber.Add('V');
                }
                else
                {
                    if (toParseNumber >= 1 && toParseNumber < 5)//I == 1
                    {
                        toParseNumber -= I;
                        parsedNumber.Add('I');
                    }
                }
                if (toParseNumber == 9)//IX == 9
                {
                    toParseNumber -= (X-I);
                    parsedNumber.Add('I');
                    parsedNumber.Add('X');
                }
                else
                {
                    if (toParseNumber >= 5 && toParseNumber < 10)//V == 5
                    {
                        toParseNumber -= V;
                        parsedNumber.Add('V');
                    }
                }
                if (toParseNumber >= 40 && toParseNumber < 50)//XL == 40
                {
                    toParseNumber -= (L - X);
                    parsedNumber.Add('X');
                    parsedNumber.Add('L');
                }
                else
                {
                    if (toParseNumber >= 10 && toParseNumber < 50)//X == 10
                    {
                        toParseNumber -= X;
                        parsedNumber.Add('X');
                    }  
                }
                if (toParseNumber >= 90 && toParseNumber < 100)// XC == 90
                {
                    toParseNumber -= (C - X);
                    parsedNumber.Add('X');
                    parsedNumber.Add('C');
                }
                else
                {
                    if (toParseNumber >= 50 && toParseNumber < 100) //L == 50
                    {
                        toParseNumber -= L;
                        parsedNumber.Add('L');
                    }
                }
                if (toParseNumber >= 400 && toParseNumber < 500) // CD == 400
                {
                    toParseNumber -= (D - C);
                    parsedNumber.Add('C');
                    parsedNumber.Add('D');
                }
                else
                {
                    if (toParseNumber >= 100 && toParseNumber < 500) //C == 100
                    {
                        toParseNumber -= C;
                        parsedNumber.Add('C');
                    } 
                }
                if (toParseNumber >= 900 && toParseNumber < 1000) //CM == 900
                {
                    toParseNumber -= (M - C);
                    parsedNumber.Add('C');
                    parsedNumber.Add('M');
                }
                else
                {
                    if (toParseNumber >= 500 && toParseNumber < 1000) //D == 500
                    {
                        toParseNumber -= D;
                        parsedNumber.Add('D');
                    }
                }

                if (toParseNumber < 1000)//M == 100
                {
                    toParseNumber -= M;
                    parsedNumber.Add('M');
                }
            }


            return parsedNumber.ToString();
        }

    }
}

//Umrechnungsregeln:

//1. Steht ein niedrigerer Wert vor einem Höheren wird Subtrahiert zb. IV = 1 5, 1<5, 5-1 = 4, IV = 4
//2. Andersherum wird Addiert zb. VI = 5 1, 5>1, 5+1 = 6, VI = 6