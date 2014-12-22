using NUnit.Framework;

namespace ixts.Ausbildung.Potenzieren.Test
{
    [TestFixture]
    public class PotenzTest
    {
        [TestCase(5,2,100,25)]
        public void PowTest(int number, int exponent,int modulo, int expected)
        {
            var actual = Potenz.Pow(number, exponent, modulo);
            
            Assert.AreEqual(expected,actual);
        }
    }
}
