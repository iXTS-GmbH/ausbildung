using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ixts.Ausbildung.Primzahlen.Test
{
    [TestFixture]
    public class FermatTests
    {

        [TestCase]
        public void RandomPrimeTest()
        {
            var number = Fermat.RandomPrime();
            var actual = number != 2 || number%2 != 0;

            Assert.IsTrue(actual);
        }
    }
}
