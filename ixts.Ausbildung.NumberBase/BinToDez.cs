
namespace ixts.Ausbildung.NumberBase
{
    public class BinToDez
    {
        public static string Parse(int number)
        {
            var arrayNumber = number.ToString().ToCharArray();

            var result = 0;

            var multiply = 1;

            for (var i = arrayNumber.Length - 1; i >= 0; i--)
            {
                if (arrayNumber[i] == '1')
                {
                    result += multiply;
                }
                multiply = multiply*2;
            }

            return result.ToString();
        }
    }
}
