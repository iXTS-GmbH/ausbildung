
namespace ixts.Ausbildung.ByteBurgTarif
{
    public class TarifCalculator
    {
        private const int LASTLINE = 5;

        public static int Calculate(int stationStart, int stationEnd)
        {
            if (stationStart - stationStart/10*10 == 3 && stationEnd - stationEnd/10*10 == 3)
            {
                if (stationStart/10*10 == LASTLINE*10 && stationEnd/10*10 == 10 )
                {
                    return 1;
                }

                if (stationEnd/10*10 == LASTLINE*10 && stationStart/10*10 == 10)
                {
                    return 1;
                }
            }

            if (stationEnd == stationStart - 1 || stationEnd == stationStart + 1)
            {
                return 1;
            }

            if (stationStart == 0 && stationEnd - stationEnd/10*10 == 1)
            {
                return 1;
            }

            if (stationEnd == 0 && stationStart - stationStart/10*10 == 1)
            {
                return 1;
            }

            if (stationStart - stationStart/10*10 <= 3 && stationEnd - stationEnd/10*10 > 3)
            {
                return stationEnd - stationEnd/10*10 == 6 ? 4 : 3;
            }

            if (stationEnd - stationEnd/10*10 <= 3 && stationStart - stationStart/10*10 > 3)
            {
                return stationStart - stationStart / 10 * 10 == 6 ? 4 : 3;
            }

            return 2;
        }
    }
}
