using System;
using System.Globalization;

namespace ixts.Ausbildung.Algebraische_Strukturen
{
    public class Z2:IField<Z2>
    {
        private readonly int value;


        public Z2(int i)
        {
            value = i == 0 ? 0 : 1;
        }

        public Z2  Div(Z2 x)
        {
            if (x.IsZero())
            {
                throw new Exception("Division by Zero");
            }
            return Mult(x);
        }

        public Z2  Mult(Z2 x)
        {
            return new Z2(value*x.value);
        }

        public bool  IsOne()
        {
            return value == 1;
        }

        public Z2  Add(Z2 x)
        {
 	        return new Z2(value + x.value);
        }

        public Z2  Sub(Z2 x)
        {
            return Add(x);
        }

        public bool  IsZero()
        {
            return value == 0;
        }

        public override Boolean Equals(object x)
        {
            if (x == null)
            {
                return false;
            }
            if (x.GetType() != GetType())
            {
                return false;
            }
            var other = (Z2) x;

            return other.value == value;
        }

        public override int GetHashCode()
        {
            return value;
        }

        public override String ToString()
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
