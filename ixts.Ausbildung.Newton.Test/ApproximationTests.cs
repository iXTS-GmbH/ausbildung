using NUnit.Framework;

namespace ixts.Ausbildung.Newton.Test
{
    [TestFixture]
    public class ApproximationTests
    {

        [TestCase(25.0,5.0)]
        [TestCase(144.0,12.0)]
        public void CalculateTest(double number,double expected)
        {
            var actual = Approximation.Calculate(number);

            Assert.AreEqual(expected, actual, 0.000000001);
        }
    }
}
