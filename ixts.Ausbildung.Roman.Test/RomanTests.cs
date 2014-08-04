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
        public void NumericOutOfRangeTest()
        {
           var r = new Roman(4000);
        }

        [ExpectedException]
        [TestCase]
        public void RomanOutOfRangeTest()
        {
          var r =  new Roman("MMMDD");
        }

        [ExpectedException]
        [TestCase]
        public void NullStringTest()
        {
            new Roman("").ToNumeral();
        }

        [ExpectedException]
        [TestCase("XXXX")]//Viererkette Alleine
        [TestCase("MMMXXXVVVVIII")]//Viererkette in Zahl 
        [TestCase("XXXXXXXXXX")]//Größerere Kette alleine
        [TestCase("MMMCCCCCCCCXXXVVVIII")]//Größerere Kette in Zahl
        public void InvalidStringTest(String invalidRomaNumber)
        {
            new Roman(invalidRomaNumber).ToNumeral();
        }

        [ExpectedException]
        [TestCase(0)]
        [TestCase(-1)]
        public void NullNegativNumberTest(int numericNumber)
        {
            new Roman(numericNumber).ToNumeral();
        }

        [ExpectedException]
        [TestCase("")]//Leerer String löst Exception aus
        [TestCase("Z")]//Unbekannte Zeichen lösen exception aus
        [TestCase("IZV")]//Zeichenfolgen mit einem unbekanntem Buchstaben lösen exeption aus
        public void ExceptionNumeralTest(String romaNumber)
        {
            new Roman(romaNumber).ToNumeral();
        }

        [TestCase(4,"IV")]//Klein vor Groß wird subtrahiert
        [TestCase(6,"VI")]//Groß vor Klein wird addiert
        [TestCase(99,"XCIX")]
        [TestCase(1660, "MDCLX")]
        [TestCase(3999, "MMMCMXCIX")]
        public void GetValueTest(int expected, String romaNumber)
        {
            var actual = new Roman(romaNumber).ToNumeral();
            Assert.AreEqual(expected,actual);
        }
        [TestCase("I", 1)]
        [TestCase("IV", 4)]
        [TestCase("V", 5)]
        [TestCase("IX", 9)]
        [TestCase("XL", 40)]
        [TestCase("MCCCXXXVII", 1337)]
        [TestCase("MMMCMXCIX", 3999)]
        public void ToStringTest(String expected, int numericNumber)
        {
            var actual = new Roman(numericNumber).ToString();
            Assert.AreEqual(expected,actual);
        }

        [TestCase("V",5,"X")]
        public void AddTest(String romaNumber, int numericNumber, String expectedNumber)
        {
            var expected = new Roman(expectedNumber);
            var actual = new Roman(numericNumber) + new Roman(romaNumber);
            Assert.AreEqual(expected,actual);
        }

        [ExpectedException]
        [TestCase("MMM", 1000)]
        public void ExceptionAddTest(String romaNumber, int numericNumber)
        {
            var r = new Roman(numericNumber) + new Roman(romaNumber);
        }

        [TestCase("V", 10, "V")]
        public void SubtractTest(String romaNumber, int numericNumber, String expectedNumber)
        {
            var expected = new Roman(expectedNumber);
            var actual = new Roman(numericNumber) - new Roman(romaNumber);
            Assert.AreEqual(expected, actual);
        }

        [ExpectedException]
        [TestCase("X", 5)]
        [TestCase("V",5)]
        public void ExceptionSubtractTest(String romaNumber, int numericNumber)
        {
          var r = new Roman(numericNumber) - new Roman(romaNumber);
        }

        [TestCase("V", 10, "L")]
        public void MultiplyTest(String romaNumber, int numericNumber, String expectedNumber)
        {
            var expected = new Roman(expectedNumber);
            var actual = new Roman(numericNumber)*new Roman(romaNumber);
            Assert.AreEqual(expected,actual);
        }

        [ExpectedException]
        [TestCase("V", 1000)]
        public void ExceptionMultiplyTest(String romaNumber, int numericNumber)
        {
            var r = new Roman(numericNumber)*new Roman(romaNumber);
        }

        [TestCase("V", 50, "X")]
        public void DivideTest(String romaNumber, int numericNumber, String expectedNumber)
        {
            var expected = new Roman(expectedNumber);
            var actual = new Roman(numericNumber)/new Roman(romaNumber);
            Assert.AreEqual(expected,actual);
        }

        [ExpectedException]
        [TestCase("X", 5)]
        [TestCase("L",51)]
        public void ExceptionDivideTest(String romaNumber, int numericNumber)
        {
           var r = new Roman(numericNumber)/new Roman(romaNumber);
        }

        [TestCase(false,"V",10)]
        [TestCase(true,"X",10)]
        public void EqualsTest(Boolean expected, String romaNumber, int numericNumber)
        {
            var actual = new Roman(romaNumber).Equals(new Roman(numericNumber));
            Assert.AreEqual(expected,actual);
        }
        [TestCase]
        public void EqualsNullTest()
        {
            var actual = new Roman("X").Equals(null);
            Assert.AreEqual(false, actual);
        }


        [TestCase("XVI",16)] 
        [TestCase("MMMCMXCIX", 3999)] 
        [TestCase("I", 1)] 
        public void GetHashCodeTest(String romaNumber, int expected)
        {
            var actual = new Roman(romaNumber).GetHashCode();
            Assert.AreEqual(expected,actual);
        }

        [TestCase]
        public void LengthComparatorTest()
        {
            var expected = new List<Roman> {new Roman("I"),new Roman("II"), new Roman("III"), new Roman("VIII")};
            var actual = new List<Roman> {new Roman("II"), new Roman("I"), new Roman("VIII"), new Roman("III")};
            actual.Sort(Roman.LengthComparator);
            Assert.AreEqual(expected,actual);
        }

        [TestCaseSource("LexicalComparatorTestSource")]
        public void LexicalComparatorTest(List<Roman> expected, List<Roman> actual  )
        {
            actual.Sort(Roman.LexicalComparator);
            Assert.AreEqual(expected,actual);
        }

        public static readonly object[] LexicalComparatorTestSource =
            {
                new object[]{new List<Roman>{new Roman("C"), new Roman("D"), new Roman("I"), new Roman("L"), new Roman("M"), new Roman("V"), new Roman("X")},
                             new List<Roman>{new Roman("I"), new Roman("V"), new Roman("X"), new Roman("L"), new Roman("C"), new Roman("D"), new Roman("M")}},
                new object[]{new List<Roman>{new Roman("CCCLI"), new Roman("CCLI"), new Roman("CLI")}, 
                             new List<Roman>{new Roman("CCCLI"), new Roman("CCLI"), new Roman("CLI")}}

            };
    }
}
