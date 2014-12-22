using System.Collections;

namespace ixts.Ausbildung.ListenUndWarteschlangen
{
    public interface IOrderedList<T>:IEnumerable
    {
        IOrderedList<T> Add(T t);
        T Get(int i);
        T Remove(int i);
        int Size();
    }
}
