using System;

namespace ixts.Ausbildung.NumberBase
{
    public class BinToHex
    {
        public static String Parse(int number)
        {
            var numberString = number.ToString();
            var numberOverhead = numberString.Length%4;
            var result = "";

            if (numberOverhead == 0)
            {
                numberOverhead = 4;
            }

            for (var i = numberString.Length; i > numberOverhead; i -=4)
            {
                var resultPart = numberString.Substring(i - 4, 4);
                resultPart = BinToDez.Parse(int.Parse(resultPart));
                result = CharParse(resultPart) + result;
            }

            result = CharParse(BinToDez.Parse(int.Parse(numberString.Substring(0,numberOverhead)))) + result;

            return result;
        }

        private static String CharParse(String resultPart)
        {
            switch (resultPart)
            {
                case "10":
                    return "A";
                case "11":
                    return "B";
                case "12":
                    return "C";
                case "13":
                    return "D";
                case "14":
                    return "E";
                case "15":
                    return "F";
                default:
                    return resultPart;
            }
        }
    }
}
