using NUnit.Framework;

namespace ixts.Ausbildung.PerfekteUndAndereZahlen.Test
{
    [TestFixture]
    public class HappyNumbersTests
    {
        [TestCase(2,20,7)]
        public void CalculateNextTest(int start, int limit,int expected)
        {
            var actual = HappyNumbers.CalculateNext(start, limit);

            Assert.AreEqual(expected,actual);
        }
    }
}
