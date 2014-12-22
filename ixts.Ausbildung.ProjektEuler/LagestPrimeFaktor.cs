using System;

namespace ixts.Ausbildung.ProjektEuler
{
    public class LagestPrimeFaktor
    {
        public static long Calculate()
        {
            var n = 600851475143;//600.851.475.143
            var result = 0L;
            var counter = 2;

            for (var i = n / counter; i > 1; i = n / counter)
            {

                if (n%i == 0)
                {
                    if (IsPrime(i))
                    {
                        result = i;
                        break;
                    }
                }
                counter++;
            }

            return result;
        }


        private static Boolean IsPrime(long number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Zu prüfender Wert darf nicht negativ sein!");
            }

            if (number == 2)
            {
                return true;
            }

            if (number % 2 == 0)
            {
                return false;
            }

            var nubmerRoot = (int)Math.Sqrt(number);

            for (var i = 3; i <= nubmerRoot; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
