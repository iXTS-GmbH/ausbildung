
using System;

namespace ixts.Ausbildung.Mobiles
{
    public class Wire:IMobile
    {
        private readonly IMobile armLeft;
        private readonly IMobile armRight;
        private int length;
        private const double EPSILON = 1E-13;
        public int NodePoint;

        public Wire(IMobile left, IMobile right, int length)
        {
            armLeft = left;
            armRight = right;
            this.length = length;
            Balance();
        }

        public double Weight()
        {
            return armLeft.Weight() + armRight.Weight();
        }

        public void Balance()
        {
            for (var i = 0; i < length; i++)
            {
                if (armLeft.Weight()*i - armRight.Weight()*(length - i) < EPSILON)
                {
                    NodePoint = i;
                    break;
                }
            }
        }

        public override String ToString()
        {
            return string.Format("Mobile[{0}{1}, {2}{3}]",NodePoint,armLeft.ToString(),length - NodePoint,armRight.ToString());
        }
    }
}
