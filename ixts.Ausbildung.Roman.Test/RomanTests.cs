﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ixts.Ausbildung.Roman.Test
{
    [TestFixture]
    public class RomanTests
    {



        [ExpectedException("System.ArgumentException")]
        [TestCase]
        public void NullStringTest()
        {
            var r = new Roman("");
        }

        [ExpectedException("System.ArgumentException")]
        [TestCase(0)]
        [TestCase(-1)]
        public void NullNegativNumberTest(int numericNumber)
        {
            var r = new Roman(numericNumber);
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

        [TestCase("IV", 4)]
        [TestCase("VI", 6)]
        [TestCase("III", 3)]
        [TestCase("MDCLX", 1660)]
        [TestCase("IX", 9)]
        [TestCase("XL", 40)]
        [TestCase("XC", 90)]
        [TestCase("CD", 400)]
        [TestCase("CM", 900)]
        public void ToLiteralTest(String expected, int numericNumber)
        {
            var r = new Roman(numericNumber);
            var actual = r.ToLiteral();
            Assert.AreEqual(expected,actual);
        }
    }
}
