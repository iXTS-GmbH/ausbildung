namespace ixts.Ausbildung.Maexchen
{
    public class PointCalculator
    {
        public static int GetPoints(int value1, int value2)
        {
            if (value1 == value2)
            {
                return 100*value1;
            }

            if (value1 > value2)
            {
                if (value1 == 2)
                {
                    return 1000;
                }
                return 10*value1 + value2;
            }

            if (value2 == 2)
            {
                return 1000;
            }
            return 10*value2 + value1;
        }
    }
}
