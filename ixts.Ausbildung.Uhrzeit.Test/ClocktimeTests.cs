using System;
using NUnit.Framework;

namespace ixts.Ausbildung.Uhrzeit.Test
{
    [TestFixture]
    public class ClocktimeTests
    {


        [TestCase(16,30,15,20,"16:30:35")]//Normal
        [TestCase(16,30,15,50,"16:31:05")]//Positiver Sekundenoverflow
        [TestCase(16,30,15,1800,"17:00:15")]//Positiver Minutenoverflow
        [TestCase(16,30,15,27000,"00:00:15")]//Positiver Stundenoverflow
        [TestCase(16,30,15,-20,"16:29:55")]//Negativer Sekundenoverflow
        [TestCase(16,30,15,-1820,"15:59:55")]//Negativer Minutenoverflow
        [TestCase(16,30,15,-59420,"23:59:55")]//Negativer Stundenoverflow
        public void AddTest(int h,int m,int s,int adds,String expected)
        {
            var ct = new Clocktime(h, m, s);
            var nct = ct.Add(adds);
            var actual = nct.ToString();

            Assert.AreEqual(expected,actual);

        }



        [TestCase(0,0,0,0,0,1,1)]
        [TestCase(0,0,1,0,0,0,86399)]
        public void DiffTest(int h1,int m1, int s1, int h2,int m2,int s2,int expected)
        {
            var ct1 = new Clocktime(h1, m1, s1);
            var ct2 = new Clocktime(h2, m2, s2);

            var actual = ct1.Diff(ct2);

            Assert.AreEqual(expected,actual);
        }
    }
}
