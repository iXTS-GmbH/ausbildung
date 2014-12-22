using System;

namespace ixts.Ausbildung.NumberBase
{
    public class HexToBin
    {
        public static String Parse(int number)
        {
            var numberString = number.ToString();
            var result = "";

            for (var i = 0; i < numberString.Length; i++)
            {
                var resultPart = "";

                switch (numberString[i])
                {
                    case 'A':
                        resultPart = DezToBin.Parse(10);
                        break;
                    case 'B':
                        resultPart = DezToBin.Parse(11);
                        break;
                    case 'C':
                        resultPart = DezToBin.Parse(12);
                        break;
                    case 'D':
                        resultPart = DezToBin.Parse(13);
                        break;
                    case 'E':
                        resultPart = DezToBin.Parse(14);
                        break;
                    case 'F':
                        resultPart = DezToBin.Parse(15);
                        break;
                    default:
                        resultPart = DezToBin.Parse(int.Parse(numberString[i].ToString()));
                        break;
                }

                while (resultPart.Length < 4)
                {
                    resultPart = "0" + resultPart;
                }

                result = resultPart + result;
            }

            return result;
        }
    }
}
