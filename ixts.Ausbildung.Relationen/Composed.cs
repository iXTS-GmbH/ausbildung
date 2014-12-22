using System;
using System.Collections.Generic;
using System.Linq;

namespace ixts.Ausbildung.Relationen
{
    public class Composed<T>:Relation<T>
    {
        private readonly Relation<T> first;
        private readonly Relation<T> second;

        public Composed(Relation<T> fst,Relation<T> snd)
        {
            if (fst.Elements() != snd.Elements())
            {
                throw new Exception("Relations haben nicht die selbe Menge");
            }

            first = fst;
            second = snd;
        }

        public override bool Related(T a, T b)
        {
            return Elements().Any(x => first.Related(a, x) && second.Related(x, b));
        }

        public override Dictionary<T, HashSet<T>>.KeyCollection Elements()
        {
            return first.Elements();
        }
    }
}
