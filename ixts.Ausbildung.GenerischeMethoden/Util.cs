using System;

namespace ixts.Ausbildung.GenerischeMethoden
{
    public class Util
    {
        public static T NoNull<T>(params T[] args)
        {

            foreach (var arg in args)
            {
                if (arg != null && !arg.Equals(0))
                {
                    return arg;
                }
            }

            return args[0];
        }

        public static T Median<T>(T a, T b, T c) where T:IComparable<T>
        {
            if (a.CompareTo(b) < 0)
            {
                if (b.CompareTo(c) < 0)
                {
                    return b;
                }

                if (a.CompareTo(c) < 0)
                {
                    return c;
                }
                return a;
            }

            if (b.CompareTo(c) < 0)
            {
                if (a.CompareTo(c) < 0)
                {
                    return a;
                }
                return c;
            }
            return b;
        }

        public static T[] CloneArray<T>(T orig, int count)where T:ICloneable
        {
            var result = new object[count];

            var clone = orig.GetType().GetMethod("Clone");

            for (var i = 0; i < count; i++)
            {
                result[i] = clone.Invoke(orig,new object[]{});
            }

            var army = new T[count];

            for (var i = 0; i < count; i++)
            {
                army[i] = (T) result[i];
            }

            return army;
        }
    }
}
