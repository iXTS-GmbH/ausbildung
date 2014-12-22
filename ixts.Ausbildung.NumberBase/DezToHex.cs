using System;

namespace ixts.Ausbildung.NumberBase
{
    public class DezToHex
    {
        public static String Parse(int number)
        {

            var result = "";

            while (number > 0)
            {
                result = CharParse(number%16) + result;
                number = number/16;
            }


            return result;
        }

        private static String CharParse(int resultPart)
        {
            switch (resultPart)
            {
                case 10:
                    return "A";
                case 11:
                    return "B";
                case 12:
                    return "C";
                case 13:
                    return "D";
                case 14:
                    return "E";
                case 15:
                    return "F";
                default:
                    return resultPart.ToString();
            }
        }
    }
}
