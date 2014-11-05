using System;

namespace ixts.Ausbildung.NumberBase
{
    public class HexToDez
    {
        public static String Parse(int number)
        {
            var numberString = number.ToString();
            var result = 0;

            for (var i = numberString.Length - 1; i >= 0 ; i--)
            {
                var positionValue = (int) Math.Pow(16, double.Parse((numberString.Length - 1 - i).ToString()));

                result += CharParse(numberString[i])*positionValue;
            }

            return result.ToString();
        }

        private static int CharParse(Char toParse)
        {
            switch (toParse)
            {
                case 'A':
                    return 10;
                case 'B':
                    return 11;
                case 'C':
                    return 12;
                case 'D':
                    return 13;
                case 'E':
                    return 14;
                case 'F':
                    return 15;
                default:
                    return int.Parse(toParse.ToString());
            }
        }
    }
}
