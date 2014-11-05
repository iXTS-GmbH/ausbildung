using System;

namespace ixts.Ausbildung.Primzahlen
{
    public class PrimeGenerator
    {

        public static Boolean IsGenerator(int prime, int generator)
        {
            for (var i = 1; i <= (prime-1)/2; i++)
            {
                var a = Potenzieren.Potenz.Pow(generator,i,prime);

                if (a == 1)
                {
                    return false;
                }
            }

            return true;
        }

        public static int GetGenerator(int prime)
        {
            var isGenerator = false;
            var number = 0;

            while (!isGenerator)
            {
                number += 1;
                isGenerator = IsGenerator(prime, number);
            }

            return number;
        }
    }
}
