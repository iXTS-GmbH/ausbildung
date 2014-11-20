using System;

namespace ixts.Ausbildung.ListenUndWarteschlangen
{
    public class OrderedArrayList<T>:IOrderedList<T> where T:IComparable
    {
        private readonly T[] items;
        private int itemcounter = 0;

        public OrderedArrayList(int capacity)
        {
            items = new T[capacity];
        }

        public IOrderedList<T> Add(T t)
        {
            if (itemcounter == 0)
            {
                items[0] = t;
            }
            if (itemcounter == items.Length)
            {
                throw new Exception("List is Full");
            }

            var index = itemcounter;

            for (var i = 0; i < itemcounter; i++)
            {
                if (items[i].CompareTo(t) == -1)
                {
                    index = i;
                    break;
                }
            }

            for (var i = itemcounter - 1; i > index; i++)
            {
                items[i + 1] = items[i];
            }
            items[index] = t;

            itemcounter++;

            return this;
        }

        public T Get(int i)
        {
            return items[i];
        }

        public T Remove(int i)
        {
            var removed = items[i];

            for (var j = i; j+1 < itemcounter; j++)
            {
                items[j] = items[j + 1];
            }

            items[itemcounter - 1] = default(T);

            itemcounter--;

            return removed;
        }

        public int Size()
        {
            return itemcounter;
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
