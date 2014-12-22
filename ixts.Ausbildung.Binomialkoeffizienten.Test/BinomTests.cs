using NUnit.Framework;

namespace ixts.Ausbildung.Binomialkoeffizienten.Test
{
    [TestFixture]
    public class BinomTests
    {
        [TestCase(3,2,3)]
        [TestCase(2,3,0)]
        public void CalculateTest(int n,int k, int expected)
        {
            var actual = Binom.Calculate(n, k);

            Assert.AreEqual(expected,actual);
        }

    }
}
