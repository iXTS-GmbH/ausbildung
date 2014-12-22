using System;
using NUnit.Framework;

namespace ixts.Ausbildung.Zaehlmass.Test
{
    [TestFixture]
    public class ZaehlmassUmrechnerTests
    {

        [TestCase(300,"2:Gros 0:Schok 1:Dutzend 0:Stueck")]
        [TestCase(11, "0:Gros 0:Schok 0:Dutzend 11:Stueck")]
        [TestCase(48, "0:Gros 0:Schok 4:Dutzend 0:Stueck")]
        [TestCase(120,"0:Gros 2:Schok 0:Dutzend 0:Stueck")]
        public void GetOldZaelmassTest(int number, String expected)
        {
            var actual = ZaehlmassUmrechner.GetOldZaehlmass(number);

            Assert.AreEqual(expected,actual);

        }
    }
}
