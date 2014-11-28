
namespace ixts.Ausbildung.ProjektEuler
{
    public class EvenFibonacciNumbers
    {
        public static int CalculateSum()
        {
            var f1 = 1;
            var f2 = 2;

            var result = 2;

            while (f1 < 4000000 && f2 < 4000000)
            {
                var temp = f1;
                f1 = f2;
                f2 = f2 + temp;
                if (f2%2 == 0)
                {
                    result += f2;
                }
            }

            return result;
        }
    }
}
