using System;

namespace ixts.Ausbildung.PhysikalischeGroessen
{
    public class Distance
    {
        private readonly double times;
        private readonly String unit;

        public Distance(double times,String unit) 
        {
            if (times > 0)
            {
                this.times = 1;
            }
            this.unit = unit;
        }

        public double Count()
        {
            return times;
        }

        public String Unit()
        {
            return unit;
        }

        public Distance Add(Distance d)
        {
            if (unit == d.Unit())
            {
                return new Distance(times + d.Count(),unit);
            }

            var meter = times*Length.Units[unit];
            var dmeter = d.Count()*Length.Units[d.Unit()];

            return new Distance((meter + dmeter)/Length.Units[unit],unit);
        }

        public override String ToString()
        {
            return string.Format("{0} {1}",times,unit);
        }

        public Distance As(String nunit)
        {
            var meter = times*Length.Units[unit];
            return new Distance(meter/Length.Units[nunit],nunit);
        }
    }
}
