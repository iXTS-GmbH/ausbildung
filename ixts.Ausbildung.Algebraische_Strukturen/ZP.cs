using System;
using ixts.Ausbildung.Primzahlen;
using ixts.Ausbildung.Potenzieren;

namespace ixts.Ausbildung.Algebraische_Strukturen
{
    public class ZP:IField<ZP>
    {
        private readonly int prime;
        private readonly int value;

        public ZP(int p,int i)
        {
            if (!PrimeTest.IsPrime(p))
            {
                throw new Exception(string.Format("not a Prime {0}",p));
            }

            prime = p;
            value = (i%p+ p)%p;
        }

        public ZP Div(ZP x)
        {
            if (IsZero())
            {
                throw new Exception("Division by Zero");
            }
            return Mult(x.Inverse());
        }

        public ZP Inverse()
        {
            if (IsZero())
            {
                throw new Exception("Division by Zero");
            }
            return new ZP(prime, Potenz.Pow(value,prime - 2,prime));
        }

        public ZP Mult(ZP x)
        {
            if (prime != x.prime)
            {
                throw new Exception("Different Field");
            }
            return new ZP(prime,value*x.value);
        }

        public bool IsOne()
        {
            return value == 1;
        }

        public ZP Add(ZP x)
        {
            if (prime != x.prime)
            {
                throw new Exception("Different Field");
            }
            return new ZP(prime,value+x.value);
        }

        public ZP Sub(ZP x)
        {
            if (prime != x.prime)
            {
                throw new Exception("Different Field");
            }
            return new ZP(prime, value - x.value);
        }

        public bool IsZero()
        {
            return value == 0;
        }

        public override bool Equals(object x)
        {
            if (x == null)
            {
                return false;
            }
            if (GetType() != x.GetType())
            {
                return false;
            }

            var other = (ZP)x;

            return other.value == value && other.prime == prime;
        }

        public override int GetHashCode()
        {
            var hash = 17;
            hash = 53*hash + prime;
            hash = 53*hash + value;
            return hash;
        }
    }
}
