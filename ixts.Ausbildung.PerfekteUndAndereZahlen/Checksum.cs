namespace ixts.Ausbildung.PerfekteUndAndereZahlen
{
    public class Checksum
    {
        public static int Calculate(int number)
        {
            var sum = 0;

            while (number > 0)
            {
                sum += number%10;
                number /= 10;
            }
            return sum;
        }
    }
}
