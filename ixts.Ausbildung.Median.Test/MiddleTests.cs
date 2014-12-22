using NUnit.Framework;

namespace ixts.Ausbildung.Median.Test
{
    [TestFixture]
    public class MiddleTests
    {

        [TestCase(1,2,3,2)]
        [TestCase(122,144,166,144)]
        public void GetMiddleTest(int n1,int n2,int n3, int expected)
        {
            var actual = Middle.GetMiddle(n1, n2, n3);

            Assert.AreEqual(expected,actual);
        }
    }
}
