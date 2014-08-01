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
        }

        [ExpectedException]
        [TestCase]
        public void NullStringTest()
        {
            var r = new Roman("");
        }

        [ExpectedException]
        [TestCase(0)]
        [TestCase(-1)]
        public void NullNegativNumberTest(int numericNumber)
        {
            var r = new Roman(numericNumber);
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
        public void AddTest(String romaNumber, int numericNumber, String expected)
        {
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
        public void SubtractTest(String romaNumber, int numericNumber, String expected)
        {
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
        public void MultiplyTest(String romaNumber, int numericNumber, String expected)
        {
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
        public void DivideTest(String romaNumber, int numericNumber, String expected)
        {
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
        public void EqualsTest(Boolean expected, String romaNumber, int numericNumber)
        {
            var r = new Roman(romaNumber);
            var actual = r.Equals(new Roman(numericNumber));
            Assert.AreEqual(expected, actual);
        }

        [ExpectedException]
        [TestCase]
        public void ExceptionEqualsTest()//Wenn null übergeben wird ist false keine exception
        {
            var r = new Roman("X");
            r.Equals(null);
        }

        [TestCase("XVI",166100)] //HashCode Zwischendrin //Genaugenommen 00166100 aber 0 vorne fällt weg
        [TestCase("MMMCMXCIX", 39999993)] //Höchster HashCode
        [TestCase("I", 11000)] //Niedrigster HashCode //Genaugenommen 00011000 aber 0 vorne fällt weg
        public void GetHashCodeTest(String romaNumber, int expected)
        {
            var r = new Roman(romaNumber);
            var actual = r.GetHashCode();
            Assert.AreEqual(expected,actual);
        }

        [TestCase()]
        public void LengthComparatorTest()
        {
            var list = new List<Roman> {new Roman("II"), new Roman("I"), new Roman("VIII"), new Roman("III")};//Ganze listen vergleichen
            list.Sort(Roman.LengthComparator);
            Assert.AreEqual("I",list[0].ToString());
            Assert.AreEqual("II",list[1].ToString());
            Assert.AreEqual("III",list[2].ToString());
            Assert.AreEqual("VIII",list[3].ToString());
        }

        [TestCase()]
        public void LexicalComparatorTest()
        {
            var list = new List<Roman> {new Roman("I"), new Roman("V"), new Roman("X"), new Roman("L"), new Roman("C"), new Roman("D"), new Roman("M")};
            list.Sort(Roman.LexicalComparator);
            Assert.AreEqual("C", list[0].ToString());
            Assert.AreEqual("D", list[1].ToString());
            Assert.AreEqual("I", list[2].ToString());
            Assert.AreEqual("L", list[3].ToString());
            Assert.AreEqual("M", list[4].ToString());
            Assert.AreEqual("V", list[5].ToString());
            Assert.AreEqual("X", list[6].ToString());
        }

        [TestCase()]
        public void ELexicalComparatorTest()
        {
            var list = new List<Roman> {new Roman("MMMDI"), new Roman("MMDI"),new Roman("MMMDDI"), new Roman("MDI")};
            list.Sort(Roman.LexicalComparator);
            Assert.AreEqual("MDI", list[0].ToString());
            Assert.AreEqual("MMDI", list[1].ToString());
            Assert.AreEqual("MMMDDI", list[2].ToString());
            Assert.AreEqual("MMMDI", list[3].ToString());
        }

    }
}
