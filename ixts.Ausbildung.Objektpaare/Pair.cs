using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.Objektpaare
{
    public class Pair<T,U> where T:IComparable
    {
        private readonly T first;
        private readonly U second;

        public Pair(T fst,U snd)
        {
            first = fst;
            second = snd;
        }

        public T First {
            get { return first; }
        }

        public U Second {
            get { return second; }
        }

        public override Boolean Equals(object x )
        {
            if (x == null)
            {
                return false;
            }
            if (x.GetType() != GetType())
            {
                return false;
            }
            var other = (Pair<T,U>) x;

            return NullEquals(first,other.First) && NullEquals(second,other.Second);
        }

        private static Boolean NullEquals(object x,object y)
        {
            if (x == null)
            {
                return false;
            }

            return x.Equals(y);
        }

        public override int GetHashCode()
        {
            var hash = 17;

            if (!first.Equals(null))
            {
                hash = 41*hash + first.GetHashCode();
            }

            if (!second.Equals(null))
            {
                hash = 41*hash + second.GetHashCode();
            }
            return hash;
        }

        public class FirstComparator:IComparer<Pair<T,U>>
        {
            public int Compare(Pair<T, U> p0, Pair<T, U> p1)
            {
                if (p0.First.Equals(null))
                {
                    return p1.First.Equals(null) ? 0 : -1;
                }
                if (p1.First.Equals(null))
                {
                    return 1;
                }
                return p0.First.CompareTo(p1.First);
            }

        }

        public class SecondComparator:IComparer<Pair<T,U>>
        {
            public int Compare(Pair<T, U> p0, Pair<T, U> p1)
            {
                if (p0.Second.Equals(null))
                {
                    return p1.Second.Equals(null) ? 0 : -1;
                }
                if (p1.Second.Equals(null))
                {
                    return 1;
                }
                return p0.First.CompareTo(p1.Second);  
            }
        }
    }
}
