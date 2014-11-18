using System;
using System.Threading;

namespace ixts.Ausbildung.Tittle_Tattle
{
    public class RandomTicker:ITicker
    {
        private readonly Random rng = new Random();

        public int Tick()
        {
            Thread.Sleep(1000 + rng.Next(9000));

            return rng.Next(100);
        }
    }
}
