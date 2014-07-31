using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ixts.Ausbildung.Roman.Test
{
    [TestFixture]
    public class RomanTests
    {

        [TestCase("IV","IV")]
        public void RomaTest(String expected, String romaNumber)
        {
            var r = new Roman(romaNumber);
            Assert.AreEqual(expected,r.rNumber);
        }

        [TestCase(4, 4)]
        public void NumRomaTest(int expected, int numericNumber)
        {
            var r = new Roman(numericNumber);
            Assert.AreEqual(expected, r.nNumber);
        }

        [ExpectedException("System.ArgumentException")]
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
        [TestCase(1660, "MDCLX")]
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
        [TestCase("", 0)]
        [TestCase("IV", 4)]
        [TestCase("VI", 6)]
        public void ToLiteralTest(String expected, int numericNumber)
        {
            var r = new Roman(numericNumber);
            var actual = r.ToLiteral();
            Assert.AreEqual(expected,actual);
        }
    }
}
