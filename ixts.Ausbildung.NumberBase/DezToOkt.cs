using System;

namespace ixts.Ausbildung.NumberBase
{
    public class DezToOkt
    {
        public static String Parse(int number)
        {
            var result = "";

            while (number > 0)
            {
                result = number % 8 + result;
                number = number / 8;
            }


            return result;
        }
    }
}
