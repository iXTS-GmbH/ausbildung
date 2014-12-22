using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ixts.Ausbildung.Trees
{
    partial class Node<T>
    {
        public void Traverse(Action<Node<T>> visitor)
        {
            var stack = new Stack<Node<T>>(new[] { this });

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                visitor(current);

                foreach (var child in current.Children.Reverse())
                    stack.Push(child);
            }
        }

        public IEnumerable<Node<T>> Traverse()
        {
            var buffer = new List<Node<T>>();
            Traverse(buffer.Add);
            return buffer;
        }
    }

    [TestFixture]
    public class NodeTraverseFixture
    {
        [Test]
        public void Traversal_should_be_pre_order()
        {
            var tree = new Node<string>("A",
                                        new Node<string>("B",
                                                         new Node<string>("C"),
                                                         new Node<string>("D",
                                                                          new Node<string>("E"),
                                                                          new Node<string>("F")),
                                                         new Node<string>("G")),
                                        new Node<string>("H",
                                                         new Node<string>("I"),
                                                         new Node<string>("J",
                                                                          new Node<string>("K")))
                );

            var actual = tree.Traverse().Select(n => n.Data).Aggregate(string.Concat);
            const string expected = "ABCDEFGHIJK";

            Assert.AreEqual(expected, actual);
        }
    }
}
