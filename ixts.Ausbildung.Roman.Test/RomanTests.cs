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


        [TestCase(0,"")]//Keine Römische Zahl ist null
        [TestCase(4,"IV")]//Klein vor Groß wird subtrahiert
        [TestCase(6,"VI")]//Groß vor Klein wird addiert
        public void NumeralTest(int expected, String romaNumber)
        {
            var r = new Roman(romaNumber);
            var actual = r.Numeral();
            Assert.AreEqual(expected,actual);
        }

    }
}
