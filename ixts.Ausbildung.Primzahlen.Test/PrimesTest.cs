using NUnit.Framework;

namespace ixts.Ausbildung.Primzahlen.Test
{
    [TestFixture]
    public class PrimesTest
    {

        [TestCase]
        public void EnumeratorTest()
        {
            var primes = new Primes();
            var counter = 0;
            var expected = new [] {2,3,5,7,11,13,17,19};

            foreach (var prime in primes)
            {
                Assert.AreEqual(expected[counter],prime);
                counter += 1;
                if (counter == expected.Length)
                {
                    break;
                }
            }

        }
    }
}
