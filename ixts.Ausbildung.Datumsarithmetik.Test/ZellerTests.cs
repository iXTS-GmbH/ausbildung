using System;
using NUnit.Framework;

namespace ixts.Ausbildung.Datumsarithmetik.Test
{
    [TestFixture]
    public class ZellerTests
    {

        [TestCase(3,11,14,20,"Montag")]
        [TestCase(30,9,14,20,"Dienstag")]
        [TestCase(19,11,14,20,"Mittwoch")]
        [TestCase(1,13,14,20,"Donnerstag")]
        [TestCase(28,14,13,20,"Freitag")]
        [TestCase(1,11,14,20,"Samstag")]
        [TestCase(14,4,96,19,"Sonntag")]
        public void ZellerTest(int day,int month,int year,int century, String expected)
        {
            var actual = Zeller.Wochentag(day, month, year,century);

            Assert.AreEqual(expected,actual);
        }
    }
}
