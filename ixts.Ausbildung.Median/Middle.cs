
namespace ixts.Ausbildung.Median
{
    public class Middle
    {
        public static int GetMiddle(int n1, int n2, int n3)
        {
            if (n1 < n2)
            {
                if (n3 > n1)
                {
                    return n2 < n3 ? n2 : n3;
                }
                return n1;
            }
            if (n3 < n1)
            {
                return n2 < n3 ? n3 : n2;
            }
            return n1;
        }

    }
}
