using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.Binomialkoeffizienten
{
    public class PascalOpt
    {
        private readonly int[][] triangle;

        public PascalOpt(int m)
        {
            triangle = new int[m + 1][];
            for (var n = 0; n <= m; n++)
            {
                triangle[n] = new int[n/2 + 1];
                triangle[n][0] = 1;

                for (var k = 0; k < (n + 1)/2; k++)
                {
                    triangle[n][k] = triangle[n - 1][k - 1] + triangle[n- 1][k];
                    if (n > 0 && n%2 == 0)
                    {
                        triangle[n][n/2] = 2*triangle[n - 1][n/2 - 1];
                    }
                }
            }
        }

        public int Calculate(int n,int k)
        {
            if (k > n/2)
            {
                k = n - k;
            }

            return k < 0 ? 0 : triangle[n][k];
        }

        public override String ToString()
        {
            var m = triangle.Length - 1;
            var s = "";
            for (var n = 0; n <= m; n++)
            {
                for (var l = 0; l < m - n; l++)
                {
                    s += " ";
                }
                for (var k = 0; k <= n; k++)
                {
                    s += String.Format("{0}", Calculate(n, k));
                }
                s += Environment.NewLine;
            }
            return s;
        }

    }
}
