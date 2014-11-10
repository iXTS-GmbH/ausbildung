using System;

namespace ixts.Ausbildung.Stoppuhren
{
    public class SwissTick:IBaseStopWatch
    {
        public long StartInMilli;

        public SwissTick()
        {
            StartInMilli = DateTime.Now.Ticks/10000;
        }

        public long Read()
        {
            return DateTime.Now.Ticks/10000 - StartInMilli;
        }

        public void SyncTo(IBaseStopWatch sw)
        {
            StartInMilli = DateTime.Now.Ticks/10000 - sw.Read();
        }
    }
}
