using System;

namespace ixts.Ausbildung.Ring_Queue
{
    public class RingQueue<T>
    {
        private T[] items;
        private readonly int capacity;
        private int pointer;
        private Boolean full;
        private Boolean empty = true;

        public RingQueue(int capacity)
        {
            this.capacity = capacity;
            items = new T[capacity];
        }

        public RingQueue(params T[] items)
        {
            this.items = items;
            capacity = items.Length;
            pointer = items.Length - 1;
            empty = false;
        }

        public int Size()
        {
            return full ? capacity : pointer;
        }

        public void Push(T item)
        {
            items[pointer] = item;
            pointer++;

            if (pointer == items.Length)
            {
                pointer = 0;
                full = true;
            }

            empty = false;
        }

        public T Get(int n)
        {
            if (!empty)
            {
                return pointer - n - 1 < 0 ? items[capacity + pointer - n - 1] : items[pointer - n - 1];
            }
            throw new Exception("Ring Queue is empty");
        }

        public void Clear()
        {
            items = new T[capacity];
            pointer = 0;
            full = false;
            empty = true;
        }
    }
}
