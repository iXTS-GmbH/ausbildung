using System.Collections;

namespace ixts.Ausbildung.ListenUndWarteschlangen
{
    public interface IOrderedQueue<T>:IEnumerable
    {
        IOrderedQueue<T> Offer(params T[] elements);
        T Poll();
        int Size();
    }
}
