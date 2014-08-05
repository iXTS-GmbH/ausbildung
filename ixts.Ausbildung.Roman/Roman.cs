using System;
using System.Collections.Generic;
using System.Text;

namespace ixts.Ausbildung.Roman
{
    public class Roman
    {
        private static readonly Dictionary<String, int> RomanToNumericMap = new Dictionary<String, int>
            {
                { "M", 1000 },
                { "CM", 900 },
                { "D",  500 },
                { "CD", 400 },
                { "C",  100 },
                { "XC",  90 },
                { "L",   50 },
                { "XL",  40 },
                { "X",   10 },
                { "IX",   9 },
                { "V",    5 },
                { "IV",   4 },
                { "I",    1 }
            };
        private readonly int romanNumber;
        private const int MAX_EQUAL_CHARACTER_IN_A_ROW = 3;
        private const int MIN_ROMAN_NUMBER_VALUE = 1;
        private const int MAX_ROMAN_NUMBER_VALUE = 3999;
        public static IComparer<Roman> LengthComparator = new LengthComparator();
        public static IComparer<Roman> LexicalComparator = new LexicalComparator();

        public Roman(String literal)
        {
            if (literal.Length == 0)
            {
                throw new ArgumentException("Leerer String ist nicht zulässig");
            }
            if (!ValidateRomanNumber(literal))
            {
                throw new ArgumentException(string.Format("{0} ist keine gültige römische Zahl", literal));
            }
            if (!ValidateRomanNumber(ToNumeral(literal)))
            {
                throw new ArgumentException(string.Format("Zahl besitzt ungültigen Wert, Wert muss zwischen {0} und {1} liegen",MIN_ROMAN_NUMBER_VALUE,MAX_ROMAN_NUMBER_VALUE));
            }
            romanNumber = ToNumeral(literal);
        }

        public Roman(int number)
        {
            if (!ValidateRomanNumber(number))
            {
                throw new ArgumentException(string.Format("{0} ist kein gültiger Wert. Wert muss zwischen {1} und {2} liegen", number,MIN_ROMAN_NUMBER_VALUE,MAX_ROMAN_NUMBER_VALUE));   
            }

            romanNumber = number;
        }

        private static Boolean ValidateRomanNumber(String literal)
        {
            var equalCharacterInARow = 1;
            var lastCharacter = literal[0];

            for (var i = 1; i < literal.Length; i++)
            {
                var character = literal[i];

                if (!RomanToNumericMap.ContainsKey(character.ToString()))
                {
                    return false;
                }

                if (lastCharacter == character)
                {
                    equalCharacterInARow += 1;

                    if (equalCharacterInARow > MAX_EQUAL_CHARACTER_IN_A_ROW)
                    {
                        return false;
                    }
                }
                else
                { 
                    equalCharacterInARow = 1;
                }

                lastCharacter = character;
            }

            return true;
        }

        private static Boolean ValidateRomanNumber(int number)
        {
            return number <= MAX_ROMAN_NUMBER_VALUE && number >= MIN_ROMAN_NUMBER_VALUE;
        }

        public int ToNumeral()
        {
            return romanNumber;
        }

        private static int ToNumeral(String literal)
        {
            var number = 0;
            var lastvalue = 0;

            for ( var i = 0;i < literal.Length;i++)
            {
                var characterValue = RomanToNumericMap[Convert.ToString(literal[i])];

                if (i == 0 || lastvalue >= characterValue)
                {
                    number += characterValue;
                }
                else
                {
                    number -= lastvalue;
                    number += (characterValue - lastvalue);
                    
                }

                lastvalue = characterValue;
            }

            return number;
        }

        private static String ToLiteral(int number)
        {
            var remainder = number;
            var literal = new StringBuilder();

            foreach (var roman in RomanToNumericMap)
            {
                while (remainder >= roman.Value)
                {
                    remainder -= roman.Value;
                    literal.Append(roman.Key);
                }
            }

            return literal.ToString();
        }

        public static Roman operator +(Roman roman, Roman otherRoman)
        {
            var sum = roman.ToNumeral() + otherRoman.ToNumeral();

            return new Roman(sum);
        }

        public static Roman operator -(Roman roman, Roman otherRoman)
        {
            var diff = roman.ToNumeral() - otherRoman.ToNumeral();

            return new Roman(diff);
        }

        public static Roman operator *(Roman roman, Roman otherRoman)
        {
            var product = roman.ToNumeral() * otherRoman.ToNumeral();

            return new Roman(product);
        }

        public static Roman operator /(Roman roman, Roman otherRoman)
        {
            var divide = roman.ToNumeral() / (double)otherRoman.ToNumeral();

            if (ValidateDivide(divide))
            {
                return new Roman((int)divide);
            }

            throw new ArgumentException("Der Quotient der zu Dividierenden Zahlen muss Ganzzahlig sein ");
        }

        private static Boolean ValidateDivide(double divide)
        {
            return divide - (int) divide <= 0;
        }

        public override Boolean Equals(object other)
        {
            var otherRoman = other as Roman;

            if (otherRoman == null)
            {
                return false;
            }

            return GetHashCode() == otherRoman.GetHashCode();
        }

        public override int GetHashCode()
        {
            return romanNumber;
        }

        public override String ToString()
        {
            return ToLiteral(romanNumber);
        }
    }
}