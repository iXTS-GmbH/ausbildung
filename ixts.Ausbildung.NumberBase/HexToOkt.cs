using System;

namespace ixts.Ausbildung.NumberBase
{
    public class HexToOkt
    {
        public static String Parse(int number)
        {
            var result = HexToDez.Parse(number);
            return DezToOkt.Parse(int.Parse(result));
        }
    }
}
