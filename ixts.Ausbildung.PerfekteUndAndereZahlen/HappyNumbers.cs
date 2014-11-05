namespace ixts.Ausbildung.PerfekteUndAndereZahlen
{
    public class HappyNumbers
    {
        public static int CalculateNext(int start, int limit)
        {
            for (var n = start; n < limit; n++)
            {
                var copy = n;

                while (copy != 1 && copy != 4)
                {
                    var q = 0;
                    while (copy > 0)
                    {
                        var d = copy%10;
                        q += d*d;
                        copy = copy/10;
                    }

                    copy = q;
                }

                if (copy == 1)
                {
                    return n;
                }
            }
            return 0;
        }
    }
}
