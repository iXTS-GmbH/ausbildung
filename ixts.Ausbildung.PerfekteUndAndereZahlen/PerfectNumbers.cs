namespace ixts.Ausbildung.PerfekteUndAndereZahlen
{
    public class PerfectNumbers
    {
        private int currentNumber;

        public PerfectNumbers(int startPoint)
        {
            currentNumber = startPoint <= 0 ? 1 : startPoint;
        }

        public int NextPerfectNumber()
        {
            var isPerfect = false;

            while (!isPerfect)
            {

                var t = 2;
                var s = 1;

                while (t*t < currentNumber)
                {
                    if (currentNumber%t == 0)
                    {
                        s += t;
                        s += currentNumber/t;
                    }
                    t++;
                }
                if (t*t == currentNumber)
                {
                    s += t;
                }

                if (s == currentNumber)
                {
                    isPerfect = true;
                }
                currentNumber += 1;
            }

            isPerfect = false;

            return currentNumber - 1;
        }


    }
}
