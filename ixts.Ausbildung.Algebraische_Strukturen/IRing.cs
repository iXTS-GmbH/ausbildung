using System;

namespace ixts.Ausbildung.Algebraische_Strukturen
{
    public interface IRing<R>:IGroup<R> where R:IRing<R>
    {
        R Mult(R x);
        Boolean IsOne();
    }
}
