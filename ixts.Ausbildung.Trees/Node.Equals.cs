using System.Linq;
using NUnit.Framework;

namespace ixts.Ausbildung.Trees
{
    partial class Node<T>
    {
        public override bool Equals(object obj)
        {
            var other = obj as Node<T>;

            return other != null && Equals(Data, other.Data) && Children.SequenceEqual(other.Children);
        }
    }

    [TestFixture]
    public class NodeEqualsFixture
    {
        
        [Test]
        public void Equal_leafes()
        {
            Assert.That(new Node<string>("A"), Is.EqualTo(new Node<string>("A")));
        }

        [Test]
        public void Inequal_leafes()
        {
            Assert.That(new Node<string>("A"), Is.EqualTo(new Node<string>("X")));
        }

        [Test]
        public void Equal_trees()
        {
            Assert.That(
                new Node<string>("B",
                                 new Node<string>("C"),
                                 new Node<string>("D")),
                Is.EqualTo(new Node<string>("B",
                                            new Node<string>("C"),
                                            new Node<string>("D"))));
        }

        [Test]
        public void Inequal_tree_structure()
        {
            Assert.That(
                new Node<string>("B",
                                 new Node<string>("C"),
                                 new Node<string>("D"))
                    .Equals(
                        new Node<string>("D",
                                         new Node<string>("C"),
                                         new Node<string>("B"))), Is.False);
        }

        [Test]
        public void Inequal_tree_data()
        {
            Assert.That(
               new Node<string>("B",
                                new Node<string>("C"),
                                new Node<string>("D")),
               Is.EqualTo(new Node<string>("B",
                                           new Node<string>("C"),
                                           new Node<string>("X"))));
        }
    }
}
