using System;

namespace ixts.Ausbildung.NumberBase
{
    public class DezToBin
    {
        public static String Parse(int number)
        {
            var result = "";

            while (number > 0)
            {
                result = number%2 + result;
                number = number/2;
            }


            return result;
        }
    }
}
