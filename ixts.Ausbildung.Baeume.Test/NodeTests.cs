using System.Collections.Generic;
using NUnit.Framework;

namespace ixts.Ausbildung.Baeume.Test
{
    [TestFixture]
    public class NodeTests
    {

        [TestCase(4)]
        public void HeightTest(int expected)
        {
            var bim = new Node("bim", new List<Node>());
            var la = new Node("la", new List<Node>{bim});
            var sa = new Node("sa", new List<Node>{la});
            var sim = new Node("sim", new List<Node>());
            var bra = new Node("bra", new List<Node>());
            var da = new Node("da", new List<Node>{bra,sim});
            var ka = new Node("ka", new List<Node>());
            var abra = new Node("Abra",new List<Node>{ka,da,sa});

            var actual = abra.Height();

            Assert.AreEqual(expected,actual);
        }

        [TestCase()]
        public void EnumerableTest()
        {
            var expected = new [] {"ka","da","sa"};

            var counter = 0;

            var ka = new Node("ka", new List<Node>());
            var da = new Node("da", new List<Node>());
            var sa = new Node("sa", new List<Node>());
            var abra = new Node("Abra", new List<Node>{ka,da,sa});

            foreach (var child in abra)
            {
                Assert.AreEqual(expected[counter],child.Info());
                counter++;
            }
        }
    }
}
