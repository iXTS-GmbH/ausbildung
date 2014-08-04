using System;
using System.Collections.Generic;
using System.Text;

namespace ixts.Ausbildung.Roman
{
    public class Roman
    {
        private static readonly Dictionary<String, int> Romans = new Dictionary<String, int> { { "M", 1000 }, { "CM", 900 }, { "D", 500 }, { "CD", 400 }, { "C", 100 }, { "XC", 90 }, { "L", 50 }, { "XL", 40 }, { "X", 10 }, { "IX", 9 }, { "V", 5 }, { "IV", 4 }, { "I", 1 }};
        private readonly String romaNumber;
        private readonly int numericNumber;
        private char marker;
        public static IComparer<Roman> LengthComparator = new LengthComparator();
        public static IComparer<Roman> LexicalComparator = new LexicalComparator();

        public Roman(String rNumber)
        {
            if (rNumber.Length == 0)
            {
                throw new ArgumentException("Leerer String ist nicht zulässig");
            }
            if (ValidateRomaNumber(rNumber))
            {
                romaNumber = rNumber;
                numericNumber = GetValue();
            }
            else
            {
                throw new ArgumentException(string.Format("{0} ist keine gültige römische Zahl",rNumber));
            }
        }

        public Roman(int nNumber)
        {
            if (nNumber > 3999)
            {
                throw new ArgumentException("Wert darf nicht größer als 3999 sein");
            }
            if (nNumber > 0)
            {
                numericNumber = nNumber;
                romaNumber = ToLiteral(nNumber);
            }
            else
            {
                throw new ArgumentException("Parameter darf nicht 0 oder negativ sein");
            }
        }

        private Boolean ValidateRomaNumber(String rNumber)
        {
            int charcount = 0;
            for (int i = 0; i < rNumber.Length; i++)
            { 
                if ( i == 0|| marker == rNumber[i])
                {
                    charcount += 1;
                    if (charcount == 4)
                    {
                        return false;
                    }
                }
                else
                { 
                    charcount = 1;
                }
                marker = rNumber[i];
            }
            return true;
        }

        public int GetValue()
        {
            int nNumber = 0;
            int lastvalue = 0;

            for ( var i = 0;i < romaNumber.Length;i++)
            {
                if (i == 0 || lastvalue >= RomaNumberValue(romaNumber[i]))
                {//Addieren
                    nNumber += RomaNumberValue(romaNumber[i]);
                    lastvalue = RomaNumberValue(romaNumber[i]);

                }
                else
                {//Subtrahieren
                    nNumber -= lastvalue;
                    nNumber += (RomaNumberValue(romaNumber[i]) - lastvalue);
                    lastvalue = RomaNumberValue(romaNumber[i]);
                }
            }

            return nNumber;
        }

        private int RomaNumberValue(char rNumber)
        {
            if (Romans.ContainsKey(Convert.ToString(rNumber)))
            {
                return Romans[Convert.ToString(rNumber)];
            }
            throw new ArgumentException(string.Format("{0} ist kein gültiges Zeichen für eine Römische Zahl", rNumber));
        }

        private static String ToLiteral(int nNumber)
        {
            var remain = nNumber;
            var parsedNumber = new StringBuilder();
            while (remain > 0) 
            {
                foreach (KeyValuePair<string, int> roman in Romans)
                {
                    if (remain >= roman.Value)
                    {
                        remain -= roman.Value;
                        parsedNumber.Append(roman.Key);
                        break;
                    }
                }
            }
            return parsedNumber.ToString();
        }

        public Roman Add(Roman roman)
        {
            return this + roman;
        }

        public static Roman operator+(Roman roman, Roman otherRoman)
        {
            var sum = roman.GetValue() + otherRoman.GetValue();
            if (sum > 3999)
            {
                throw new ArgumentException("Die Summe der zu Addierenden Zahlen darf 3999 nicht überschreiten");
            }
            return new Roman(sum);
        }

        public Roman Subtract(Roman roman)
        {
            return this - roman;
        }

        public static Roman operator -(Roman roman, Roman otherRoman)
        {
            var dif = roman.GetValue() - otherRoman.GetValue();
            if (dif <= 0)
            {
                throw new ArgumentException("Die Differenz der zu Subtrahierenden Zahlen darf nicht 0 oder negativ sein");
            }
            return new Roman(dif);
        }

        public Roman Multiply(Roman roman)
        {
            return this*roman;
        }

        public static Roman operator *(Roman roman, Roman otherRoman)
        {
            var multi = roman.GetValue() * otherRoman.GetValue();
            if (multi > 3999)
            {
                throw new ArgumentException("Das Produkt der zu Multiplizierenden Zahlen darf 3999 nicht überschreiten");
            }
            return new Roman(multi);
        }

        public Roman Divide(Roman roman)
        {
            
            return this/roman;
        }

        public static Roman operator /(Roman roman, Roman otherRoman)
        {
            var divide = roman.GetValue() / (double)otherRoman.GetValue();
            if (divide < 1)
            {
                throw new ArgumentException("Der Quotient der zu Dividierenden Zahlen darf nicht kleiner als 1 sein");
            }
            if (divide - (int)divide > 0)
            {
                throw new ArgumentException("Der Quotient der zu Dividierenden Zahlen muss Ganzzahlig sein");
            }
            return new Roman((int)divide);
        }

        public override Boolean Equals(object other)
        {
            var otherRoman = other as Roman;
            if (otherRoman == null)
            {
                return false;
            }
            return numericNumber == otherRoman.GetValue();
        }

        public override int GetHashCode()
        {
            return numericNumber;
        }

        public override String ToString()
        {
            return romaNumber;
        }


    }
}