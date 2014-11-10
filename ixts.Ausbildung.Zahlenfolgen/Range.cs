
namespace ixts.Ausbildung.Zahlenfolgen
{
    public class Range:Naturals
    {
        private int current;
        private int stopper;

        public Range(int start,int end)
        {
            current = start;
            stopper = end;
        }
    }
}
