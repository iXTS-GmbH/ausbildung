using System;

namespace ixts.Ausbildung.E_Camel
{
    public class Camel
    {
        private readonly int maxTravelSpeed;
        private int pace;
        private Camel next;

        public Camel(int mp)
        {
            maxTravelSpeed = mp;
        }

        public int MaxPace()
        {
            return maxTravelSpeed;
        }

        public int Pace()
        {
            if (maxTravelSpeed - pace <= 0)
            {
                return 0;
            }

            return maxTravelSpeed - pace;
        }

        public void SetLoad(int l)
        {
            pace = l;
        }

        public int GetLoad()
        {
            return pace;
        }

        public void SetNext(Camel c)
        {
            if (this == c)
            {
                throw new Exception("Camel can't be self-follower");
            }


            if (c != null)
            {
                c.SetNext(next);
            }
            
            next = c;
        }

        public Camel GetNext()
        {
            return next;
        }

    }
}
