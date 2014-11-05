using NUnit.Framework;

namespace ixts.Ausbildung.PerfekteUndAndereZahlen.Test
{
    [TestFixture]
    public class ChecksumTest
    {
        [TestCase(1234,10)]
        [TestCase(123456,21)]
        public void CalculateTest(int number, int expected)
        {
            var actual = Checksum.Calculate(number);

            Assert.AreEqual(expected,actual);
        }
    }
}
