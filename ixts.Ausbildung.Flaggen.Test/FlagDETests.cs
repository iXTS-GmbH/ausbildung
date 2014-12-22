using System;
using NUnit.Framework;

namespace ixts.Ausbildung.Flaggen.Test
{
    [TestFixture]
    public class FlagDETests
    {
        [TestCase(100,90,50,45,"red")]
        [TestCase(100,90,50,15,"gold")]
        [TestCase(100,90,50,75,"black")]
        public void FlagcolorTest(int width,int height,int pX,int pY, String expected)
        {
            var flag = new FlagDE(width, height);

            var actual = flag.Flagcolor(pX, pY);

            Assert.AreEqual(expected,actual);
        }
    }
}
