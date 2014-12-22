using NUnit.Framework;

namespace ixts.Ausbildung.Primzahlen.Test
{
    [TestFixture]
    public class RandomGeneratorTests
    {
        [TestCase]
        public void RandomGeneratorTest()
        {
            var rGenerator = new RandomGenerator(7, 1);
            var counter = 0;
            var expected = new[] {3,9,27,81,243,731,2193,6579,19737,59211,177635,532905};


            foreach (var number in rGenerator)
            {
                if (counter == expected.Length)
                {
                    break;
                }

                Assert.AreEqual(expected[counter],number);
                counter += 1;
            }

        }

    }
}
