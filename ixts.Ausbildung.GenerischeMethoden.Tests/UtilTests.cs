using System;
using NUnit.Framework;

namespace ixts.Ausbildung.GenerischeMethoden.Tests
{
    [TestFixture]
    public class UtilTests
    {

        [TestCase(1,null,null,1)]
        public void NoNullIntTest(int expected,params int[] args)
        {
            var actual = Util.NoNull(args);

            Assert.AreEqual(expected,actual);
        }

        [TestCase("1",null,null,"1")]
        public void NoNullStringTest(String expected, params String[] args)
        {
            var actual = Util.NoNull(args);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(6,8,6,4)]
        public void MedianIntTest(int expected,int a,int b,int c)
        {
            var actual = Util.Median(a, b, c);

            Assert.AreEqual(expected,actual);
        }

        [TestCase("B","A","B","C")]
        public void MedianStringTest(String expected,String a,String b,String c)
        {
            var actual = Util.Median(a, b, c);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Test",10)]
        public void CloneArrayTest(String orig, int count)
        {
            var actual = Util.CloneArray(orig, count);

            foreach (var s in actual)
            {
                Assert.AreEqual(orig,s);
            }
        }
    }
}
