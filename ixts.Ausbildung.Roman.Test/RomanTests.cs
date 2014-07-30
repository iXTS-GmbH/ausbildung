using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ixts.Ausbildung.Roman.Test
{
    [TestFixture]
    public class RomanTests
    {

        [TestCase()]
        public void RomaTest(String expected, String romaNumber)
        {
            Roman r = new Roman(romaNumber);
            Assert.AreEqual(expected,r);
        }

        [TestCase()]
        public void NumeralTest()
        {

        }

    }
}
