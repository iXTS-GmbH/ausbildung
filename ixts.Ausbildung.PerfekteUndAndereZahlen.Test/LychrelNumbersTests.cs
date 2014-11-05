using NUnit.Framework;

namespace ixts.Ausbildung.PerfekteUndAndereZahlen.Test
{
    [TestFixture]
    public class LychrelNumbersTests
    {
        [TestCase(1, 200, 89)]
        public void CalculateTest(int start,int limit, int expected)
        {
            var actual = LychrelNumbers.CalculateNext(start,limit);

            Assert.AreEqual(expected,actual);
        }

    }
}
