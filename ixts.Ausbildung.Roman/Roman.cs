using System;
using System.Collections.Generic;
using System.Text;

namespace ixts.Ausbildung.Roman
{
    public class Roman
    {
        private static readonly Dictionary<String, int> Romans = new Dictionary<String, int>{{"I",1},{"IV",4},{"V",5},{"IX",9},{"X",10},{"XL",40},{"L",50},{"XC",90},{"C",100},{"CD",400},{"D",500},{"CM",900},{"M",1000}};
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
            if (Romans.ContainsKey(Convert.ToString(romaNumber)))
            {
                return Romans[Convert.ToString(romaNumber)];
            }
            throw new ArgumentException(string.Format("{0} ist kein gültiges Zeichen für eine Römische Zahl", romaNumber));
        }

        private static String ToLiteral(int numericNumber)
        {
            var remain = numericNumber;
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
            var sum = nNumber + roman.Numeral();
            if (sum > 3999)
            {
                throw new ArgumentException("Die Summe der zu Addierenden Zahlen darf 3999 nicht überschreiten");
            }
            return new Roman(sum);
        }

        public Roman Subtract(Roman roman)
        {
            var dif = nNumber - roman.Numeral();
            if (dif <= 0)
            {
                throw new ArgumentException("Die Differenz der zu Subtrahierenden Zahlen darf nicht 0 oder negativ sein");
            }
            return new Roman(dif);
        }

        public Roman Multiply(Roman roman)
        {
            var multi = nNumber*roman.Numeral();
            if (multi > 3999)
            {
                throw new ArgumentException("Das Produkt der zu Multiplizierenden Zahlen darf 3999 nicht überschreiten");
            }
            return new Roman(multi);
        }

        public Roman Divide(Roman roman)
        {
            var divide = nNumber/(double)roman.Numeral();
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
            return nNumber == otherRoman.Numeral();
        }

        public override int GetHashCode()
        {
            return nNumber;
        }
    }
}