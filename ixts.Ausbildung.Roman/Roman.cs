using System;
using System.Collections.Generic;
using System.Text;

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
        private readonly String rNumber;
        private readonly int nNumber;

        public Roman(String romaNumber)
        {
            if (romaNumber.Length == 0)
            {
                throw new ArgumentException("Leerer String ist nicht zulässig");
            }
            rNumber = romaNumber;
            nNumber = Numeral();
        }

        public Roman(int numericNumber)
        {
            if (numericNumber > 3999)
            {
                throw new ArgumentException("Wert darf nicht größer als 3999 sein");
            }
            if (numericNumber > 0)
            {
                nNumber = numericNumber;
                rNumber = ToLiteral();
            }
            else
            {
                throw new ArgumentException("Parameter darf nicht 0 oder negativ sein");
            }
            
        }

        public override String ToString()
        {
            return rNumber;
        }

        public int Numeral()
        {
            int parsedNumber = 0;
            int lastvalue = 0;

            for ( var i = 0;i < rNumber.Length;i++)
            {
                if (i == 0 || lastvalue >= RomaNumberValue(rNumber[i]))//Addieren
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
            return ToLiteral(nNumber);
        }

        public String ToLiteral(int numericNumber)
        {
            var toParseNumber = numericNumber;
            var parsedNumber = new StringBuilder();
            int[] romaValues = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
            string[] romanCharakter = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
            while (toParseNumber > 0)
            {
                for (int i = romaValues.Length - 1; i >= 0; i--)
                    if (toParseNumber >= romaValues[i])
                    {
                        toParseNumber -= romaValues[i];
                        parsedNumber.Append(romanCharakter[i]);
                        break;
                    }
            }
            return parsedNumber.ToString();
            
        }

        public String Add(Roman toAdd)
        {
            var toAddNumeric = toAdd.Numeral();
            var sum = toAddNumeric + nNumber;
            if (sum > 3999)
            {
                throw new ArgumentException("Summe der zu Addierenden Zahlen darf 3999 nicht überschreiten");
            }
            return ToLiteral(sum);
        }


    }
}