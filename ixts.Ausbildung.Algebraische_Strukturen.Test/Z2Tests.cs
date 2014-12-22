using System;
using NUnit.Framework;

namespace ixts.Ausbildung.Algebraische_Strukturen.Test
{
    [TestFixture]
    public class Z2Tests
    {
        [TestCase(1,1,0)]
        public void AddTest(int expectedvalue, int value1, int value2)
        {
            var a = new Z2(value1);
            var b = new Z2(value2);
            var expected = new Z2(expectedvalue);
            var actual = a.Add(b);

            Assert.AreEqual(expected,actual);
        }

        [TestCase(1,1,0)]
        public void SubTest(int expectedvalue, int value1, int value2)
        {
            var a = new Z2(value1);
            var b = new Z2(value2);
            var expected = new Z2(expectedvalue);
            var actual = a.Sub(b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1,1,1)]
        public void MultTest(int expectedvalue, int value1, int value2)
        {
            var a = new Z2(value1);
            var b = new Z2(value2);
            var expected = new Z2(expectedvalue);
            var actual = a.Mult(b);

            Assert.AreEqual(expected, actual); 
        }

        [TestCase(1,1,1)]
        public void DivTest(int expectedvalue, int value1, int value2)
        {
            var a = new Z2(value1);
            var b = new Z2(value2);
            var expected = new Z2(expectedvalue);
            var actual = a.Mult(b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1)]
        public void GetHashCodeTest(int value)
        {
            var a = new Z2(value);

            Assert.AreEqual(value,a.GetHashCode());
        }

        [TestCase]
        public void IsOneTest()
        {
            var a = new Z2(1);

            Assert.IsTrue(a.IsOne());
        }

        [TestCase]
        public void IsZeroTest()
        {
            var a = new Z2(0);

            Assert.IsTrue(a.IsZero());
        }

        [TestCase("1",1)]
        public void ToStringTest(String expected,int value)
        {
            var a = new Z2(value);
            var actual = a.ToString();

            Assert.AreEqual(expected,actual);
        }
    }
}
