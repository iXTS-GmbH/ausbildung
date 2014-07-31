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
        public static IComparer<Roman> LengthComparator = new LengthComparator();//sortiert Collection nach Länge der Romastrings
        public static IComparer<Roman> LexicalComparator = new LexicalComparator();//sortiert Collection nach Alphabet der Romastrings

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
                rNumber = ToLiteral(nNumber);
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

        private static String ToLiteral(int numericNumber)
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
            var sum = nNumber + toAddNumeric;
            if (sum > 3999)
            {
                throw new ArgumentException("Die Summe der zu Addierenden Zahlen darf 3999 nicht überschreiten");
            }
            return ToLiteral(sum);
        }

        public String Subtract(Roman toSubtract)
        {
            var toSubtractNumeric = toSubtract.Numeral();
            var dif = nNumber - toSubtractNumeric;
            if (dif <= 0)
            {
                throw new ArgumentException("Die Differenz der zu Subtrahierenden Zahlen darf nicht 0 oder negativ sein");
            }
            return ToLiteral(dif);
        }

        public String Multiply(Roman toMultiply)
        {
            var toMultiplyNumeric = toMultiply.Numeral();
            var multi = nNumber*toMultiplyNumeric;
            if (multi > 3999)
            {
                throw new ArgumentException("Das Produkt der zu Multiplizierenden Zahlen darf 3999 nicht überschreiten");
            }
            return ToLiteral(multi);
        }

        public String Divide(Roman toDivide)
        {
            double toDivideNumeric = toDivide.Numeral();
            var divide = nNumber/toDivideNumeric;
            if (divide < 1)
            {
                throw new ArgumentException("Der Quotient der zu Dividierenden Zahlen darf nicht kleiner als 1 sein");
            }
            if (divide - (int)divide > 0)
            {
                throw new ArgumentException("Der Quotient der zu Dividierenden Zahlen muss Ganzzahlig sein");
            }
            return ToLiteral((int)divide);
        }

        public override Boolean Equals(object other)
        {
            var otherRoman = other as Roman;
            if (otherRoman == null)
            {
                throw new ArgumentException("Übergebener Wert ist Null");
            }
            return nNumber == otherRoman.Numeral();
        }

        public override int GetHashCode() //von 0001.1000 - 3999.9993
        {
            var numberString = nNumber.ToString();
            var reverseNumberString = ReverseString(numberString);
            if (reverseNumberString.Length < 4)
            {
                for (int i = 1; i < 4; i++)
                {
                    if (reverseNumberString.Length == i)
                    {
                        reverseNumberString = string.Format("{0}0", reverseNumberString);
                    }
                }
            }

            return Convert.ToInt32(string.Format("{0}{1}",numberString,reverseNumberString));
        }

        private String ReverseString(String s)
        {
            char[] chars = s.ToCharArray();
			Array.Reverse(chars);
			return new string(chars);
        }
    }
}