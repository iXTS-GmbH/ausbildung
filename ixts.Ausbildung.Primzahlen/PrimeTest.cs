﻿using System;

namespace ixts.Ausbildung.Primzahlen
{
    public class PrimeTest
    {
        public static Boolean IsPrime(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Zu prüfender Wert darf nicht negativ sein!");
            }

            if (number == 2)
            {
                return true;
            }

            if (number%2 == 0)
            {
                return false;
            }

            var nubmerRoot = (int) Math.Sqrt(number);

            for (var i = 3; i <= nubmerRoot ; i += 2)
            {
                if (number%i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
