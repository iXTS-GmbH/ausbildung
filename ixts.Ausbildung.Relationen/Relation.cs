using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.Relationen
{
    public abstract class Relation<T>
    {
        public abstract Boolean Related(T a, T b);
        public abstract Dictionary<T, HashSet<T>>.KeyCollection Elements();
    }
}
