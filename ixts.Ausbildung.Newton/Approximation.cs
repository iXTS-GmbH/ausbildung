using System;

namespace ixts.Ausbildung.Newton
{
    public class Approximation
    {

        public static double Calculate(double number)
        {
            var random = new Random();
            var q = (double)random.Next(1, (int) number/2);


            while (Math.Abs(number - q*q) >= 0.000000001)
            {
                    q = (q + (number/q))/2;
            }

            return q;
        }
    }
}
