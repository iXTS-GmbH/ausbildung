using System;
using System.Collections;
using System.Collections.Generic;

namespace ixts.Ausbildung.Primzahlen
{
    public class Primes:IEnumerable<Int32>
    {
        public IEnumerator<int> GetEnumerator()
        {
            return new PrimeIterator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class PrimeIterator:IEnumerator<int>
    {
        private int currentPrime = 0;

        public object Current
        {
            get { return currentPrime; }
        }

        int IEnumerator<int>.Current
        {
            get { return currentPrime; }
        }

        public bool MoveNext()
        {
            if (currentPrime == 2)
            {
                currentPrime = 3;
                return true;
            }
            if (currentPrime == 2147483647) //Maximalwert den ein Int32 annehmen kann
            {
                return false;
            }

            currentPrime = currentPrime + 2;

            while (!PrimeTest.IsPrime(currentPrime))
            {

                currentPrime = currentPrime + 2;
            }

            return true;
        }

        public void Reset()
        {
            currentPrime = 2;
        }

        public void Dispose()
        {
            
        }
    }
}
