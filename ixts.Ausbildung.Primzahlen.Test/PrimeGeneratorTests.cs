using System;
using NUnit.Framework;

namespace ixts.Ausbildung.Primzahlen.Test
{
    [TestFixture]
    public class PrimeGeneratorTests
    {
        [TestCase(3,7,true)]
        [TestCase(19,191,true)]
        [TestCase(4,7,false)]
        public void IsGeneratorTest(int generator, int prime, Boolean expected)
        {
            var actual = PrimeGenerator.IsGenerator(prime, generator);

            Assert.AreEqual(expected,actual);
        }

        [TestCase(7,3)]
        [TestCase(191,19)]
        public void GetGeneratorTest(int prime, int expected)
        {
            var actual = PrimeGenerator.GetGenerator(prime);

            Assert.AreEqual(expected,actual);
        }

    }
}
