using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ixts.Ausbildung.Roman.Test
{
    [TestFixture]
    public class RomanTests
    {
        [ExpectedException]
        [TestCase]
        public void OutOfRangeTest()
        {
            var r = new Roman(4000);
            r.Numeral();
        }

        [ExpectedException]
        [TestCase]
        public void NullStringTest()
        {
            var r = new Roman("");
            r.Numeral();
        }

        [ExpectedException]
        [TestCase(0)]
        [TestCase(-1)]
        public void NullNegativNumberTest(int numericNumber)
        {
            var r = new Roman(numericNumber);
            r.Numeral();
        }

        [ExpectedException]
        [TestCase("")]//Leerer String löst Exception aus
        [TestCase("Z")]//Unbekannte Zeichen lösen exception aus
        [TestCase("IZV")]//Zeichenfolgen mit einem unbekanntem Buchstaben lösen exeption aus
        public void ExceptionNumeralTest(String romaNumber)
        {
            var r = new Roman(romaNumber);
            r.Numeral();
        }

        [TestCase(4,"IV")]//Klein vor Groß wird subtrahiert
        [TestCase(6,"VI")]//Groß vor Klein wird addiert
        [TestCase(99,"XCIX")]
        [TestCase(1660, "MDCLX")]
        [TestCase(3999, "MMMCMXCIX")]
        public void NumeralTest(int expected, String romaNumber)
        {
            var r = new Roman(romaNumber);
            var actual = r.Numeral();
            Assert.AreEqual(expected,actual);
            
            
        }

        [TestCase("IV","IV")]
        public void ToStringTest(String expected, String romaNumber)
        {
            var r = new Roman(romaNumber);
            var actual = r.ToString();
            Assert.AreEqual(expected,actual);
        }

        [TestCase("V",5,"X")]
        public void AddTest(String romaNumber, int numericNumber, String expectedNumber)
        {
            var expected = new Roman(expectedNumber);
            var r = new Roman(numericNumber);
            var actual = r.Add(new Roman(romaNumber));
            Assert.AreEqual(expected,actual);
        }

        [ExpectedException]
        [TestCase("MMM", 1000)]
        public void ExceptionAddTest(String romaNumber, int numericNumber)
        {
            var r = new Roman(numericNumber);
            r.Add(new Roman(romaNumber));
        }

        [TestCase("V", 10, "V")]
        public void SubtractTest(String romaNumber, int numericNumber, String expectedNumber)
        {
            var expected = new Roman(expectedNumber);
            var r = new Roman(numericNumber);
            var actual = r.Subtract(new Roman(romaNumber));
            Assert.AreEqual(expected,actual);
        }

        [ExpectedException]
        [TestCase("X", 5)]
        [TestCase("V",5)]
        public void ExceptionSubtractTest(String romaNumber, int numericNumber)
        {
            var r = new Roman(numericNumber);
            r.Subtract(new Roman(romaNumber));
        }

        [TestCase("V", 10, "L")]
        public void MultiplyTest(String romaNumber, int numericNumber, String expectedNumber)
        {
            var expected = new Roman(expectedNumber);
            var r = new Roman(numericNumber);
            var actual = r.Multiply(new Roman(romaNumber));
            Assert.AreEqual(expected,actual);
        }

        [ExpectedException]
        [TestCase("V", 1000)]
        public void ExceptionMultiplyTest(String romaNumber, int numericNumber)
        {
            var r = new Roman(numericNumber);
            r.Multiply(new Roman(romaNumber));
        }

        [TestCase("V", 50, "X")]
        public void DivideTest(String romaNumber, int numericNumber, String expectedNumber)
        {
            var expected = new Roman(expectedNumber);
            var r = new Roman(numericNumber);
            var actual = r.Divide(new Roman(romaNumber));
            Assert.AreEqual(expected,actual);
        }

        [ExpectedException]
        [TestCase("X", 5)]
        [TestCase("L",51)]
        public void ExceptionDivideTest(String romaNumber, int numericNumber)
        {
            var r = new Roman(numericNumber);
            r.Divide(new Roman(romaNumber));
        }

        [TestCase(false,"V",10)]
        [TestCase(true,"X",10)]
        [TestCase(false,"X",null)]
        public void EqualsTest(Boolean expected, String romaNumber, int numericNumber)
        {
            var r = new Roman(romaNumber);
            var actual = r.Equals(new Roman(numericNumber));
            Assert.AreEqual(expected, actual);
        }

        [TestCase("XVI",16)] 
        [TestCase("MMMCMXCIX", 3999)] 
        [TestCase("I", 1)] 
        public void GetHashCodeTest(String romaNumber, int expected)
        {
            var r = new Roman(romaNumber);
            var actual = r.GetHashCode();
            Assert.AreEqual(expected,actual);
        }

        [TestCase]
        public void LengthComparatorTest()
        {
            var expected = new List<Roman> {new Roman("I"),new Roman("II"), new Roman("III"), new Roman("VIII")};
            var list = new List<Roman> {new Roman("II"), new Roman("I"), new Roman("VIII"), new Roman("III")};
            list.Sort(Roman.LengthComparator);
            Assert.AreEqual(expected,list);
        }

        [TestCaseSource("LexicalComparatorTestSource")]
        public void LexicalComparatorTest(List<Roman> expected, List<Roman> list  )
        {
            list.Sort(Roman.LexicalComparator);
            Assert.AreEqual(expected,list);
        }

        public static readonly object[] LexicalComparatorTestSource =
            {
                new object[]{new List<Roman>{new Roman("C"), new Roman("D"), new Roman("I"), new Roman("L"), new Roman("M"), new Roman("V"), new Roman("X")},
                             new List<Roman>{new Roman("I"), new Roman("V"), new Roman("X"), new Roman("L"), new Roman("C"), new Roman("D"), new Roman("M")}},
                new object[]{new List<Roman>{new Roman("MDI"), new Roman("MMDI"),new Roman("MMMDDI"), new Roman("MMMDI")}, 
                             new List<Roman>{new Roman("MMMDI"), new Roman("MMDI"),new Roman("MMMDDI"), new Roman("MDI")}}

            };
    }
}
