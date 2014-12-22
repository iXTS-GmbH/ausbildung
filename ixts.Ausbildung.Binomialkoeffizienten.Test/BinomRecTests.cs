using NUnit.Framework;

namespace ixts.Ausbildung.Binomialkoeffizienten.Test
{
    [TestFixture]
    public class BinomRecTests
    {
        [TestCase(3, 2, 3)]
        [TestCase(2, 3, 0)]
        public void CalculateTest(int n, int k, int expected)
        {
            var actual = BinomRec.Calculate(n, k);

            Assert.AreEqual(expected, actual);
        }
    }
}
