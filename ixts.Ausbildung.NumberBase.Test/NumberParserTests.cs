using System;
using NUnit.Framework;

namespace ixts.Ausbildung.NumberBase.Test
{
    [TestFixture]
    public class NumberParserTests
    {
        [TestCase("2","8",10011001,"231")]//BinToOkt
        [TestCase("2","10",10011001,"153")]//BinToDez
        [TestCase("2","16",10011001,"99")]//BinToHex
        [TestCase("8","2",231,"10011001")]//OktToBin
        [TestCase("8","10",231,"153")]//OktToDez
        [TestCase("8","16",231,"99")]//OktToHex
        [TestCase("10","2",153,"10011001")]//DezToBin
        [TestCase("10","8",153,"231")]//DezToOkt
        [TestCase("10","16",153,"99")]//DezToHex
        [TestCase("16","2",99,"10011001")]//HexToBin
        [TestCase("16","8",99,"231")]//HexToOkt
        [TestCase("16","10",99,"153")]//HexToDez
        public void ParseTest(String startBase,String endBase,int number,String expected)
        {
            var actual = NumberParser.Parse(startBase, endBase, number);

            Assert.AreEqual(expected,actual);
        }
    }
}
