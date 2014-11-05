using System;
using NUnit.Framework;

namespace ixts.Ausbildung.Reihen.Test
{
    [TestFixture]
    public class SeriesTests
    {
        [TestCase(2.0)]
        public void ExpTest(double number)
        {
            var actual = Series.Exp(number);

            Assert.AreEqual(Math.Exp(number),actual,1E-13);
        }

        [TestCase(0.5)]
        public void SinhTest(double number)
        {
            var actual = Series.Sinh(number);

            Assert.AreEqual(Math.Sinh(number),actual,1E-13);
        }

        [TestCase(0.5)]
        public void ArsinhTest(double number)
        {
            var actual = Series.Arsinh(Series.Sinh(number));
            var expected = Series.Sinh(Series.Arsinh(number));

            Assert.AreEqual(expected,actual,1E-13);
        }

        [ExpectedException]
        [TestCase]
        public void UndefindedArsinhTest()
        {
            Series.Arsinh(2);
        }
    }
}
