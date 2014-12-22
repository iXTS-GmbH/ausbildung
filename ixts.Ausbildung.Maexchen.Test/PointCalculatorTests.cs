using NUnit.Framework;

namespace ixts.Ausbildung.Maexchen.Test
{
    [TestFixture]
    public class PointCalculatorTests
    {
        [TestCase(2,1,1000)]
        [TestCase(1,2,1000)]
        [TestCase(6,6,600)]
        [TestCase(6,5,65)]
        public void GetPointsTest(int value1,int value2,int expected)
        {
            var actual = PointCalculator.GetPoints(value1, value2);

            Assert.AreEqual(expected,actual);
        }
    }
}
