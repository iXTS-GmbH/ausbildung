using System;

namespace ixts.Ausbildung.Primzahlen
{
    public class Fermat
    {
        private static readonly Random Random = new Random();


        private static Boolean FermatTest(int number, int a)
        {
            var pow = Math.Pow(a/100000.0, (number - 1)/100000.0);// a/100000.0 um infinity vorzubeugen

            var abs = Math.Abs(pow%number - 1);

            return abs <= 1.0 && abs > 0.001;
        }

        private static Boolean IsPrime(int number)
        {
            for (var i = 0; i < 100; i++)
            {
                var a = Random.Next(number - 1);

                if (!FermatTest(number,a))
                {
                    return false;
                }
            }
            return true;
        }

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
    }
}
