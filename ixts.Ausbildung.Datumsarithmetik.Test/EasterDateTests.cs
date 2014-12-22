using System;
using NUnit.Framework;

namespace ixts.Ausbildung.Datumsarithmetik.Test
{
    [TestFixture]
    public class EasterDateTests
    {

        [TestCase(2008,"23 3")]
        [TestCase(2009,"12 4")]
        public void GetEasterDateTest(int year, String expected)
        {
            var actual = EasterDate.GetEasterDate(year);

            Assert.AreEqual(expected,actual);
        }

    }
}
