using System;
using System.Collections.Generic;
using System.Linq;

namespace ixts.Ausbildung.Relationen
{
    public class Simple<T>:Relation<T>
    {
        private readonly Dictionary<T,HashSet<T>> pairs = new Dictionary<T, HashSet<T>>(); 

        public Simple(IEnumerable<T> e,params T[] args)
        {
            foreach (var t in e)
            {
                pairs.Add(t,new HashSet<T>());
            }

            for (var i = 0; i < args.Length; i += 2)
            {
                pairs[args[i]].Add(args[i + 1]);
            }
        }

        public override bool Related(T a, T b)
        {
            return pairs[a].Contains(b);
        }

        public override Dictionary<T,HashSet<T>>.KeyCollection Elements()
        {
            return pairs.Keys;
        }

        public Boolean IsReflexive()
        {
            return Elements().All(t => Related(t, t));
        }

        public Boolean IsSymmetric()
        {
            return Elements().All(t => Elements().Any(u => Related(t, u) != Related(u, t)));
        }

        public Boolean IsTransitive()
        {
            return Elements().All(t => !Elements().Any(u => Elements().Any(v => Related(t, u) && Related(u, v) && !Related(t, v))));
        }
    }
}
