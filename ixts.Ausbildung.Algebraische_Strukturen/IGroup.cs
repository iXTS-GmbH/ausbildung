using System;

namespace ixts.Ausbildung.Algebraische_Strukturen
{
    public interface IGroup<G> where G:IGroup<G>
    {
        G Add(G x);
        G Sub(G x);
        Boolean IsZero();
    }
}
