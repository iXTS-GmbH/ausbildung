using System;

namespace ixts.Ausbildung.Primzahlen
{
    public class Fermat
    {
        private static readonly Random Random = new Random();

        public static int RandomPrime()
        {
            var isPrime = false;
            var number = 0;

            while (!isPrime)
            {
                number = Random.Next(1, 1000000);
                isPrime = IsPrime(number);
            }

            return number;
        }

        private static Boolean IsPrime(int number)
        {
            for (var i = 0; i < 100; i++)
            {
                var a = Random.Next(number - 1);

                if (!FermatTest(number, a))
                {
                    return false;
                }
            }
            return true;
        }

        private static Boolean FermatTest(int number, int a)
        {
            return Potenzieren.Potenz.Pow(a, number - 1, number) == 1;
        }

        
    }
}
