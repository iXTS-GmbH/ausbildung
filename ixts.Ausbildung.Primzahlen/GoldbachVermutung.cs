using System;

namespace ixts.Ausbildung.Primzahlen
{
    public class GoldbachVermutung
    {
        public static Boolean TestGoldbach(int number)
        {
            for (int i = 4; i <= number; i += 2)
            {
                if (!Decomposamble(i))
                {
                    return false;
                }
                
            }

            return true;
        }

        private static Boolean Decomposamble(int number)
        {
            foreach (var prime in new Primes())
            {
                if (PrimTest.IsPrime(number-prime))
                {
                    return true;
                }
                if (prime > number/2)
                {
                    return false;
                }

            }
            return false; //unerreichbar
        }
    }
}
