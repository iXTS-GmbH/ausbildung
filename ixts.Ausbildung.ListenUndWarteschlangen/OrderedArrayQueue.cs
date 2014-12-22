using System;

namespace ixts.Ausbildung.ListenUndWarteschlangen
{
    public class OrderedArrayQueue<T>:IOrderedQueue<T> where T:IComparable
    {

        private readonly T[] items;
        private int itemcounter = 0; 

        public OrderedArrayQueue(int capacity)
        {
            items = new T[capacity];
        }

        public IOrderedQueue<T> Offer(params T[] elements)
        {
            if (itemcounter + elements.Length > items.Length)
            {
                throw new Exception("Queue can't handle amount of elements");
            }

            foreach (var element in elements)
            {
                Add(element);
            }
            return this;
        }

        private void Add(T t)
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
        }

        public T Poll()
        {
            var removed = items[0];

            for (var i = 0; i+1 < itemcounter; i++)
            {
                items[i] = items[i + 1];
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
