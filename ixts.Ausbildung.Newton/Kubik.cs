using System;

namespace ixts.Ausbildung.Newton
{
    public class Kubik
    {

        public static double Calculate(double number)
        {
            var random = new Random();
            var q = (double)random.Next(1, (int)number / 2);


            while (Math.Abs(number - q * q * q) >= 0.000000001)
            {
                q = q*2/3 + number/q/q/3;
            }

            return q;
        }
    }
}
