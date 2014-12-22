using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ixts.Ausbildung.Trees
{
    partial class Node<T>
    {
        public Node<T> Subst(Node<T> old, Node<T> subst)
        {
            if (Equals(this, old))
                return subst;

            var copy = new Node<T>(this.Data, Children.ToArray());

            copy.Children = copy.Children.Select(n => Equals(n, old) ? n.Subst(n, subst) : n);

            return copy;
        }
    }

    [TestFixture]
    public class NodeSubstFixture
    {
        [Test]
        public void Test()
        {
            var tree = new Node<string>("A",
                                        new Node<string>("B"),
                                        new Node<string>("B"));

            var substitution = new Node<string>("X", new Node<string>("Y"), new Node<string>("Z"));

            var actual = tree.Subst(new Node<string>("B"), substitution);

            var expected = new Node<string>("A",
                                            new Node<string>("X", 
                                                new Node<string>("Y"), new Node<string>("Z")),
                                            new Node<string>("X", 
                                                new Node<string>("Y"), new Node<string>("Z")));

            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}
