using System;

namespace ixts.Ausbildung.Binomialkoeffizienten
{
    public class Pascal
    {
        private readonly int[][] triangle;

        public Pascal(int m)
        {
            triangle = new int[m + 1][];
            for (var n = 0; n <= m ; n++)
            {
                triangle[n] = new int[n+1];
                triangle[n][0] = 1;
                triangle[n][n] = 1;
                for (var k = 1; k < n; k++)
                {
                    triangle[n][k] = triangle[n - 1][k - 1] + triangle[n - 1][k];
                }
            }
        }

        public int Calculate(int n, int k)
        {
            if (k < 0 || k > n)
            {
                return 0;
            }
            return triangle[n][k];
        }

        public override String ToString()
        {
            var m = triangle.Length - 1;
            var s = "";
            for (var n = 0; n <= m ; n++)
            {
                for (var l = 0; l < m-n; l++)
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
