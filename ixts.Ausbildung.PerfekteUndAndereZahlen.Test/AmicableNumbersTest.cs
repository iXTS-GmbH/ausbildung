using System;
using NUnit.Framework;

namespace ixts.Ausbildung.PerfekteUndAndereZahlen.Test
{
    [TestFixture]
    public class AmicableNumbersTest
    {
        [TestCase(1, "220 284")]
        public void NextAmicableNumbersTest(int start, String expected)
        {
            var aNumbers = new AmicableNumbers(start);
            var actual = aNumbers.NextAmicableNumbers();

            Assert.AreEqual(expected,actual);
        }


    }
}
