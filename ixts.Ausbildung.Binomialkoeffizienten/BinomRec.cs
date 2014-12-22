namespace ixts.Ausbildung.Binomialkoeffizienten
{
    public class BinomRec
    {
        public static int Calculate(int n,int k)
        {
            if (k > n || k < 0)
            {
                return 0;
            }

            if (k == 0 || k == n)
            {
                return 1;
            }
            return (Calculate(n, k - 1)*(n - k + 1))/k;
        }
    }
}
