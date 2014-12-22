using System;

namespace ixts.Ausbildung.GroßeGanzzahlen
{
    public class Fibonacci
    {
        public static String Calculator(int index)
        {
            var f1 = new BigInt(1);
            var f2 = new BigInt(1);

            for (var i = 2; i <= index; i++)
            {
                var fi = f1.Add(f2);
                f1 = f2;
                f2 = fi;
            }

            return f2.ToString();
        }
    }
}
