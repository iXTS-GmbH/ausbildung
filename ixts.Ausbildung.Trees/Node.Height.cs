using System;
using NUnit.Framework;

namespace ixts.Ausbildung.Trees
{
    partial class Node<T>
    {
        public int Height
        {
            get
            {
                var height = 0;

                foreach (var child in this)
                {
                    height = Math.Max(child.Height + 1, height);
                }

                return height;
            }
        }
    }

    [TestFixture]
    public class HeightFixture
    {
        [TestCase]
        public void Height_should_be_0_when_node_has_no_children()
        {
            var actual = new Node<string>("A").Height;
            const int expected = 0;

            Assert.AreEqual(actual, expected);
        }

        [TestCase]
        public void Height_should_be_correct()
        {
            var actual = new Node<string>("A",
                                          new Node<string>("B",
                                                           new Node<string>("C"),
                                                           new Node<string>("D"),
                                                           new Node<string>("G")),
                                          new Node<string>("H",
                                                           new Node<string>("I"),
                                                           new Node<string>("J",
                                                                            new Node<string>("K")))
                ).Height;

            const int expected = 3;

            Assert.AreEqual(actual, expected);
        }
    }
}
