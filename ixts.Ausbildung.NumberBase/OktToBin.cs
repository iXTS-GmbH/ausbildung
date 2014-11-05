using System;

namespace ixts.Ausbildung.NumberBase
{
    public class OktToBin
    {
        public static String Parse(int number)
        {
            var numberString = number.ToString();
            var result = "";

            for (var i = numberString.Length - 1; i >= 0; i--)
            {
                var resultPart = DezToBin.Parse(int.Parse(numberString[i].ToString()));;

                while (resultPart.Length < 3)
                {
                    resultPart = "0" + resultPart;
                }

                result = resultPart + result;
            }

            while (result.StartsWith("0"))
            {
                result = result.Substring(1);
            }


            return result;
        }
    }
}
