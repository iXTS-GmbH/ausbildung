using NUnit.Framework;

namespace ixts.Ausbildung.ByteBurgTarif.Test
{
    [TestFixture]
    public class TarifCalculatorTests
    {
        [TestCase(00,11,1)]
        [TestCase(13,53,1)]
        [TestCase(13,14,1)]
        [TestCase(11,13,2)]
        [TestCase(12,14,3)]
        [TestCase(11,16,4)]
        public void CalculateTest(int stationStart, int stationEnd, int expected)
        {
            var actual = TarifCalculator.Calculate(stationStart, stationEnd);

            Assert.AreEqual(expected,actual);
        }
    }
}
