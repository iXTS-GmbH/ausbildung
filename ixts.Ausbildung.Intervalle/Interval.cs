using System;

namespace ixts.Ausbildung.Intervalle
{
    public class Interval
    {
        private readonly int start;
        private readonly int end;
        private readonly Boolean empty;

        public Interval(int start, int end)
        {
            if (start < end)
            {
                this.start = start;
                this.end = end;
                empty = false;
            }
            else
            {
                empty = true;
            }
        }

        public Interval()
        {
            empty = true;
        }

        public Boolean IsEmpty()
        {
            return empty;
        }

        public int LowerBound()
        {
            return !empty ? start : new int();
        }

        public int UpperBound()
        {
            return !empty ? end : new int();
        }

        public override String ToString()
        {
            return empty ? "[]" : string.Format("[{0},{1}]",start,end);
        }

        public override bool Equals(object x)
        {
            if (x == null)
            {
                return false;
            }

            if (x.GetType() != GetType())
            {
                return false;
            }

            var other = (Interval)x;

            if (empty)
            {
                return other.IsEmpty();
            }

            return start == other.LowerBound() && end == other.UpperBound();
        }

        public override int GetHashCode()
        {
            return !empty ? int.Parse(string.Format("{0}{1}", start, end)) : 0;
        }

        public Boolean Contains(int i)
        {
            return i >= start && i <= end;
        }

        public Boolean Contains(Interval i)
        {
            return i.LowerBound() >= start && i.UpperBound() <= end;
        }

        public Boolean DisJoint(Interval i)
        {
            if (i.IsEmpty())
            {
                return true;
            }

            return i.LowerBound() > end && i.UpperBound() < start;
        }

        public Interval Hull(Interval i)
        {
            var nstart = start < i.LowerBound() ? start : i.LowerBound();
            var nend = end > i.UpperBound() ? end : i.UpperBound();

            return new Interval(nstart,nend);
        }

        public Interval Intersection(Interval i)
        {
            var nstart = start > i.LowerBound() ? start : i.LowerBound();
            var nend = end < i.UpperBound() ? end : i.UpperBound();

            return nstart < nend ? new Interval(nstart,nend) : new Interval();
        }
    }
}
