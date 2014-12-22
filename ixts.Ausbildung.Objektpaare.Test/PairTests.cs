using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ixts.Ausbildung.Objektpaare.Test
{
    [TestFixture]
    public class PairTests
    {
        [TestCase(5,5,5,5)]
        public void EqualTest(int first, int second,int third,int fourd)
        {
            var pairOne = new Pair<int, int>(first, second);
            var pairTwo = new Pair<int, int>(third, fourd);

            Assert.IsTrue(pairOne.Equals(pairTwo));
        }

        [TestCase(5, 5, 28787)]
        public void GetHashCodeTest(int first,int second,int expected)
        {
            var pair = new Pair<int, int>(first, second);
            var actual = pair.GetHashCode();

            Assert.AreEqual(expected,actual);
        }
    }
}
