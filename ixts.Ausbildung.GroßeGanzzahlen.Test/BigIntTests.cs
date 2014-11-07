using System;
using NUnit.Framework;

namespace ixts.Ausbildung.GroßeGanzzahlen.Test
{
    [TestFixture]
    public class BigIntTests
    {
        [TestCase(9999,"1111","11110")] //gleich lang
        [TestCase(9999,"11111","21110")]//b Länger
        [TestCase(11111,"9999","21110")]//bI Länger
        public void AddTest(int number,String numberAdd,String expectedString)
        {
            var bI = new BigInt(number);
            var b = new BigInt(numberAdd);
            var expected = new BigInt(expectedString);

            var actual = bI.Add(b);

            Assert.IsTrue(expected.Equals(actual));
        }


        [TestCase(1000,10000,true)]//b länger
        [TestCase(10000,1000,false)]//bI länger
        [TestCase(1001,1000,false)]//gleich lang bI größer
        [TestCase(1000,1001,true)]//gleich lang b größer
        public void LessTest(int number,int numberLess,Boolean expected)
        {
            var bI = new BigInt(number);
            var b = new BigInt(numberLess);

            var actual = bI.Less(b);

            Assert.AreEqual(expected,actual);
        }
    }
}
