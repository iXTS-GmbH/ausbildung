using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.Zaehlerlisten
{
    public class CountList<E>:IList<E>
    {
        private List<E> elementList;

        public CountList()
        {
            elementList = new List<E>();
        }

        public int ElementCount(E element)
        {
            var count = 0;
            foreach (var e in elementList)
            {
                if (e.Equals(element))
                {
                    count++;
                }
            }
            return count;
        }

        public int Unique()
        {
            var list = new List<E>();

            foreach (var e in elementList)
            {
                if (!list.Contains(e))
                {
                    list.Add(e);
                }
            }
            return list.Count;
        }

        public Dictionary<E, int> Counts()
        {
            var counts = new Dictionary<E, int>();
            foreach (var element in this)
            {
                var count = ElementCount(element);
                counts.Add(element,count == 0? 1: count + 1);
            }
            return counts;
        }

        public int IndexOf(E item)
        {
            return elementList.IndexOf(item);
        }

        public void Insert(int index, E item)
        {
            elementList.Insert(index,item);
        }

        public void RemoveAt(int index)
        {
            elementList.RemoveAt(index);
        }

        public E this[int index]
        {
            get { return elementList[index]; }
            set { elementList[index] = value; }
        }

        public void Add(E item)
        {
            elementList.Add(item);
        }

        public void Clear()
        {
            elementList.Clear();
        }

        public Boolean Contains(E item)
        {
            return elementList.Contains(item);
        }

        public void CopyTo(E[] array, int arrayIndex)
        {
            elementList.CopyTo(array,arrayIndex);
        }

        public int Count
        {
            get { return elementList.Count; }
        }

        public Boolean IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public Boolean Remove(E item)
        {
            return elementList.Remove(item);
        }

        public IEnumerator<E> GetEnumerator()
        {
            return elementList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return elementList.GetEnumerator();
        }
    }
}
