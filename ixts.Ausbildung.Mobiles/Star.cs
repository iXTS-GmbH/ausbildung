using System;

namespace ixts.Ausbildung.Mobiles
{
    public class Star:IMobile
    {
        protected int weight;

        public Star(int weight)
        {
            if (weight <= 0)
            {
                throw new Exception("Gewicht kann nicht 0 oder kleiner sein");
            }
            this.weight = weight;
        }

        public double Weight()
        {
            return weight;
        }

        public void Balance()
        {
        }

        public override String ToString()
        {
            return string.Format("Star[{0}]", weight);
        }
    }
}
