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


        [TestCase(0,"")]//Keine Römische Zahl ist null
        [TestCase(4,"IV")]//Klein vor Groß wird subtrahiert
        [TestCase(6,"VI")]//Groß vor Klein wird addiert
        [TestCase(1660, "MDCLX")]
        [TestCase(0,"Z")]//Unbekannte Zeichen geben 0 zurück
        [TestCase(0,"IZV")]//Zeichenfolgen mit einem unbekanntem Buchstaben geben 0 zurück
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
