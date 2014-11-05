using NUnit.Framework;

namespace ixts.Ausbildung.PerfekteUndAndereZahlen.Test
{
    [TestFixture]
    public class PerfectNumbersTest
    {

        [TestCase(1, 6)]
        [TestCase(7, 28)]
        public void PerfectNumberTest(int start,int expected)
        {
            var pNumbers = new PerfectNumbers(start);
            var actual = pNumbers.NextPerfectNumber();

            Assert.AreEqual(expected,actual);
        }
    }
}
