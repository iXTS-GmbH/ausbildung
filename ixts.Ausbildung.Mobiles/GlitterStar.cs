using System;

namespace ixts.Ausbildung.Mobiles
{
    public class GlitterStar:Star
    {
        public GlitterStar(int weight) : base(weight)
        {
        }

        public void Decorate()
        {
            weight = weight + 1;
        }

        public override String ToString()
        {
            return string.Format("Glitterstar[{0}]", weight);
        }
    }
}
