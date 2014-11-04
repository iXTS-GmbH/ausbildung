using NUnit.Framework;

namespace ixts.Ausbildung.Newton.Test
{
    [TestFixture]
    public class KubikTests
    {
        [TestCase(216,6)]
        [TestCase(27,3)]
        public void CalculateTest(double number,double expected)
        {
            var actual = Kubik.Calculate(number);

            Assert.AreEqual(expected, actual, 0.000000001);
        }

    }
}
