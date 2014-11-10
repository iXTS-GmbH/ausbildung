
namespace ixts.Ausbildung.Stoppuhren
{
    interface ISuspendableStopWatch:IResettableStopWatch
    {
        void Suspend();
        void Resume();
    }
}
