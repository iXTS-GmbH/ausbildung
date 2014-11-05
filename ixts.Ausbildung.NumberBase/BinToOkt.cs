using System;

namespace ixts.Ausbildung.NumberBase
{
    public class BinToOkt
    {
        public static String Parse(int number)
        {
            var numberString = number.ToString();
            var numberOverhead = numberString.Length % 3;
            var result = "";

            if (numberOverhead == 0)
            {
                numberOverhead = 3;
            }

            for (var i = numberString.Length; i > numberOverhead; i -= 3)
            {
                var resultPart = numberString.Substring(i - 3, 3);
                resultPart = BinToDez.Parse(int.Parse(resultPart));
                result = resultPart + result;
            }

            result = BinToDez.Parse(int.Parse(numberString.Substring(0, numberOverhead))) + result;

            return result;
        }
    }
}
