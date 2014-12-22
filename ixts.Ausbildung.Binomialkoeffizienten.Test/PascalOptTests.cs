using NUnit.Framework;

namespace ixts.Ausbildung.Binomialkoeffizienten.Test
{
    public class PascalOptTests
    {
        [TestCase(3, 2, 5, 3)]
        [TestCase(2, 3, 5, 0)]
        public void CalculateTest(int n, int k, int m, int expected)
        {
            var pascal = new Pascal(m);
            var actual = pascal.Calculate(n, k);

            Assert.AreEqual(expected, actual);
        }

        [ExpectedException]
        [TestCase(17, 16, 5)]
        public void OverflowTest(int n, int k, int m)
        {
            var pascal = new Pascal(m);
            pascal.Calculate(n, k);
        }
    }
}
