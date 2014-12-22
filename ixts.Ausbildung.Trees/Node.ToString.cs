using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ixts.Ausbildung.Trees
{
    partial class Node<T>
    {
        public override string ToString()
        {
            if (Children.Any())
                return string.Format("{0} ({1})", Data, string.Join(",", Children));

            return Data.ToString();
        }
    }

    [TestFixture]
    public class NodeToStringFixture
    {
        [Test]
        public void Should_only_display_data_when_leaf()
        {
            var actual = new Node<string>("A").ToString();
            const string expected = "A";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Should_also_display_child_nodes_when_exist()
        {
            var actual = new Node<string>("A", new Node<string>("B"), new Node<string>("C")).ToString();
            const string expected = "A (B,C)";

            Assert.AreEqual(actual, expected);
        }
    }
}
