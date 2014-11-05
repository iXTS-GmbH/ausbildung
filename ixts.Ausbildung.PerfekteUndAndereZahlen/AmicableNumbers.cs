using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.PerfekteUndAndereZahlen
{
    public class AmicableNumbers
    {
        private int n;
        private int value2;

        public AmicableNumbers(int startpoint)
        {
            n = startpoint >= 1 ? startpoint : 1;
        }

        public String NextAmicableNumbers()
        {

            var areAmicable = false;

            while (!areAmicable)
            {
                var t = 2;
                var s = 1;

                while (t*t < n)
                {
                    if (n%t == 0)
                    {
                        s += t;
                        s += n/t;
                    }
                    t++;
                    if (t*t == n)
                    {
                        s += t;
                    }

                    if (s > n)
                    {
                        t = 2;
                        var f = 1;

                        while (t*t < s)
                        {
                            if (s%t == 0)
                            {
                                f += t;
                                f += s/t;
                            }

                            t++;
                        }

                        if (t*t == s)
                        {
                            f += t;
                        }

                        if (f == n)
                        {
                            areAmicable = true;
                        }
                        n++;
                    }
                }  
            }

            areAmicable = false;

            return string.Format("{0} {1}",n - 1,value2);
        }
    }
}
