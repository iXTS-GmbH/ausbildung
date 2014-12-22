using System;
using NUnit.Framework;

namespace ixts.Ausbildung.FilterSamples.Test
{
    [TestFixture]
    public class DataHandlerTest
    {
        //Leerzeichen als Trenner
        [TestCase("1 2 3 0 -4 -3 4 5 -1 -1 -1","1 2 3 0 4 5 ")]//mit Negativen Werten
        [TestCase("1 2 3 0 0 0 4 5 -1 -1 -1","1 2 3 0 4 5 ")]//mit mehreren Nullen
        [TestCase("1 2 3 0 0 -4 -5 4 5 -1 -1 -1","1 2 3 0 4 5 ")]//mit Negativen Werten und mehrere Nullen
        [TestCase("1 2 3 0 4 5 -1 -1 -1","1 2 3 0 4 5 ")]//ohne Negative Werte oder mehrere Nullen
        //Komma als Trenner
        [TestCase("1,2,3,0,-4,-3,4,5,-1,-1,-1", "1 2 3 0 4 5 ")]//mit Negativen Werten
        [TestCase("1,2,3,0,0,0,4,5,-1,-1,-1", "1 2 3 0 4 5 ")]//mit mehreren Nullen
        [TestCase("1,2,3,0,0,-4,-5,4,5,-1,-1,-1", "1 2 3 0 4 5 ")]//mit Negativen Werten und mehrere Nullen
        [TestCase("1,2,3,0,4,5,-1,-1,-1", "1 2 3 0 4 5 ")]//ohne Negative Werte oder mehrere Nullen
        public void HandleTest(String data, String expected)
        {
            var actual = DataHandler.Handle(data);
            
            Assert.AreEqual(expected,actual);
        }
    }
}
