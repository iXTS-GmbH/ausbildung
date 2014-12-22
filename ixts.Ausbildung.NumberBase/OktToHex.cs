using System;

namespace ixts.Ausbildung.NumberBase
{
    public class OktToHex
    {
        public static String Parse(int number)
        {
            var result = OktToDez.Parse(number);

            return DezToHex.Parse(int.Parse(result));
        }
    }
}
