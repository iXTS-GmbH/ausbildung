namespace ixts.Ausbildung.PerfekteUndAndereZahlen
{
    public class LychrelNumbers
    {
        public static int CalculateNext(int start,int limit)
        {

            for (var n = start; n < limit; n++)
            {
                if (n == 10)
                {
                    var br = 0;
                }

                var copy = n;
                var p = 0;

                while (copy != p && copy > 0)
                {
                    copy += p;

                    var x = copy;
                    p = 0;

                    while (x > 0 && copy > 0)
                    {
                        var d = x%10;
                        x /= 10;
                        p = 10*p;
                        p = p + d;
                    }
                }

                if (p != copy)
                {
                    return n;
                }
            }
            return 0;
        }
    }
}
