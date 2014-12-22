using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ixts.Ausbildung.Trees
{
    partial class Node<T> : IEnumerable<Node<T>>
    {
        public T Data { get; set; }

        public IEnumerable<Node<T>> Children { get; set; }
        
        public Node(T data, params Node<T>[] children)
        {
            Data = data;
            Children = children;
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            return Children.GetEnumerator();
        }
       
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        public int Size { get { return Children.Count(); } }

        public override int GetHashCode()
        {
            var hashCode = 17;

            if (Equals(Data, default(T)))
                hashCode = 37 * hashCode + Data.GetHashCode();

            if (Children.Any())
                hashCode = 37 * hashCode + Children.Select(c => c.GetHashCode()).Aggregate((x, y) => x ^ y);

            return hashCode;
        }              
    }
}
