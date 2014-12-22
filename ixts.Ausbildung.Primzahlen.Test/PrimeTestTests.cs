using System;
using NUnit.Framework;

namespace ixts.Ausbildung.Primzahlen.Test
{
    [TestFixture]
    public class PrimeTestTests
    {
        [TestCase(1,true)]
        [TestCase(2,true)]
        [TestCase(1031, true)]
        [TestCase(2624, false)]
        [TestCase(999983, true)]
        [TestCase(999999, false)]
        public void IsPrimeTest(int number, Boolean expected)
        {
            var actual = PrimeTest.IsPrime(number);

            Assert.AreEqual(expected,actual);
        }
        [ExpectedException]
        [TestCase(-15)]
        public void NegativPrimeTest(int number)
        {
            PrimeTest.IsPrime(number);
        }
    }
}
