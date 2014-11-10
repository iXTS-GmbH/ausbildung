using System;

namespace ixts.Ausbildung.Zahlenfolgen
{
    public class Evans:Filter
    {
        public Evans(Naturals source) : base(source)
        {
        }


        public override Boolean Pass(int number)
        {
            return number%2 == 0;
        }
    }
}
