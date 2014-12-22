
namespace ixts.Ausbildung.Stoppuhren
{
    public interface IBaseStopWatch
    {
        long Read();
        void SyncTo(IBaseStopWatch sw);
    }
}
