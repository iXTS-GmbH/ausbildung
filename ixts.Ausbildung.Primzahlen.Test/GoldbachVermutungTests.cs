using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ixts.Ausbildung.Primzahlen.Test
{
    [TestFixture]
    public class GoldbachVermutungTests
    {
        [TestCase(1000000)]
        public void TestGoldbachTest(int number)
        {
            Assert.IsTrue(GoldbachVermutung.TestGoldbach(number));
        }
    }
}
