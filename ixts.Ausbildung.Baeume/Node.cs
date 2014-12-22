using System;
using System.Collections;
using System.Collections.Generic;

namespace ixts.Ausbildung.Baeume
{
    public class Node :IEnumerable<Node>
    {
        private readonly String info;
        private List<Node> childs = new List<Node>(); 
        public Boolean IsLeaf;


        public Node(String info,List<Node> childs )
        {
            this.info = info;
            this.childs = childs;
            IsLeaf = childs.Count == 0;
        }

        public String Info()
        {
            return info;
        }

        public int Size()
        {
            return childs.Count;
        }

        public override String ToString()
        {
            if (IsLeaf)
            {
                return info;
            }
            
            var result = "";

            foreach (var child in childs)
            {
               result = string.Format("{0},{1}",result,child);
            }

            return string.Format("{0}({1})",info,result);
        }

        public int Height()
        {
            var maxheight = 1;

            if (IsLeaf)
            {
                return 1;
            }

            foreach (var child in childs)
            {
                var height = child.Height() + 1;
                if (height > maxheight)
                {
                    maxheight = height;
                }
            }

            return maxheight;
        }

        public Boolean Equals(Node n)
        {
            return n.info == info && n.childs == childs;
        }

        public override int GetHashCode()
        {
            //ich weis derzeit nicht wie der Hashcode aussehen soll um unit zu sein
            return 0;
        }

        public void Subst(Node old,Node nu)
        {
            for (var i = 0; i < childs.Count; i++)
            {
                if (childs[i].Equals(old))
                {
                    childs[i] = nu;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Node> GetEnumerator()
        {
            return childs.GetEnumerator();
        }
    }
}
