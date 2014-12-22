namespace ixts.Ausbildung.Binomialkoeffizienten
{
    public class Binom
    {

        public static int Calculate(int n,int k)
        {
            var bin = 0;

            if (k <= n)
            {
                bin = 1;
                for (var i = 1; i <= k; i++)
                {
                    bin = bin*(n - i + 1)/i;
                }
            }
            return bin;
        }
    }
}
