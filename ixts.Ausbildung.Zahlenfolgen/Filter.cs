using System;

namespace ixts.Ausbildung.Zahlenfolgen
{
    public abstract class Filter:Naturals
    {
        public abstract Boolean Pass(int number);
        private readonly Naturals source;


        protected Filter(Naturals source)
        {
            this.source = source;
        }
    }
}
