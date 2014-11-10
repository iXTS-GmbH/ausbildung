using System;

namespace ixts.Ausbildung.Stoppuhren
{
    public class SwissTickDeluxe:ISuspendableStopWatch
    {
        public long StartInMilli;
        private Boolean suspended = false;
        private long partTimeInMillis = 0;

        public SwissTickDeluxe()
        {
            StartInMilli = DateTime.Now.Ticks/10000;
        }

        public long Read()
        {
            return (DateTime.Now.Ticks/10000 - StartInMilli) + partTimeInMillis;
        }

        public void SyncTo(IBaseStopWatch sw)
        {
            StartInMilli = DateTime.Now.Ticks/10000 - sw.Read();
        }

        public void Reset()
        {
            partTimeInMillis = 0;
            StartInMilli = DateTime.Now.Ticks/10000;
        }

        public void Suspend()
        {
            if (!suspended)
            {
                partTimeInMillis += DateTime.Now.Ticks/10000 - StartInMilli;
            }
        }

        public void Resume()
        {
            if (suspended)
            {
                StartInMilli = DateTime.Now.Ticks/10000;
            }
        }
    }
}
