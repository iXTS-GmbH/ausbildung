
namespace ixts.Ausbildung.ProjektEuler
{
    public class Multiplesof3And5
    {
        public static int CalculateSum()
        {
            var result = 0;

            for (var i = 1; i < 1000; i++)
            {
                if (i%3 == 0 || i%5 == 0)
                {
                    result += i;
                }
            }

            return result;
        }
    }
}
