using System.Collections;
using System.Collections.Generic;

namespace ixts.Ausbildung.Primzahlen
{
    public class RandomGenerator:IEnumerator<int>, IEnumerable
    {
        private readonly int generator;
        private int exponent;
        private readonly int seed;
        private readonly int prime;
        private int current;
        private int last;

        public RandomGenerator(int prime, int seed)
        {
            generator = PrimeGenerator.GetGenerator(prime);
            exponent = seed - 1;
            this.seed = seed;
            this.prime = prime;
        }

        public int Current
        {
            get
            {
                current = Potenzieren.Potenz.Pow(generator, exponent, prime) + last*generator - (last*generator)%prime;
                return current;
            }
        }

        public void Dispose()
        {
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            last = current;

            if (exponent + 1 < prime-1)
            {
                exponent += 1;
            }
            else
            {
                exponent = 1;
            }
            return true;
        }

        public void Reset()
        {
           exponent = seed;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }
    }
}
