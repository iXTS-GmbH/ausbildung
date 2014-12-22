using System;

namespace ixts.Ausbildung.NumberBase
{
    public class OktToDez
    {
        public static String Parse(int number)
        {
            var numberString = number.ToString();
            var result = 0;

            for (var i = numberString.Length - 1; i >= 0; i--)
            {
                var positionValue = (int)Math.Pow(8, double.Parse((numberString.Length - 1 - i).ToString()));

                result += int.Parse(numberString[i].ToString())  * positionValue;
            }

            return result.ToString();
        }
    }
}
