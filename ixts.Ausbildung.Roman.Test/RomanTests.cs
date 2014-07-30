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

        [TestCase("IV","IV")]
        public void RomaTest(String expected, String romaNumber)
        {
            var r = new Roman(romaNumber);
            Assert.AreEqual(expected,r.rNumber);
        }


        //[TestCase()]
        //public void NumeralTest()
        //{

        //}

    }
}
