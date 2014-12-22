using System;

namespace ixts.Ausbildung.Stoppuhren
{
    public class SwissTickZero:IResettableStopWatch
    {
        public long StartInMilli;

        public SwissTickZero()
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

        public void Reset()
        {
            StartInMilli = DateTime.Now.Ticks/10000;
        }
    }
}
