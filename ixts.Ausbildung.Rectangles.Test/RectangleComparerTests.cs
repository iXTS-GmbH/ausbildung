using System;
using NUnit.Framework;

namespace ixts.Ausbildung.Rectangles.Test
{
    [TestFixture]
    public class RectangleCompararTests
    {

        [TestCase(1,1,5,5,6,1,8,2,"disjoint")]//Berühren sich nicht
        [TestCase(1,1,5,5,1,1,5,5,"same")]//Sind Gleich
        [TestCase(1,1,5,5,2,2,4,4,"contained")]//erstes enthält zweites oder umgekehrt
        [TestCase(1,1,5,5,5,3,8,5,"aligned")]//Linie gleich
        [TestCase(1,1,5,5,5,5,8,7,"touching")]//Punkt gleich
        [TestCase(1,1,5,5,0,4,3,5,"intersecting")]//Überschnitt ist rechteck
        public void CompareTest(int pX, int pY, int qX, int qY, int sX, int sY, int tX, int tY, String expected)
        {
            var rComparer = new RectangleComparer(pX, pY, qX, qY, sX, sY, tX, tY);
            var actual = rComparer.Compare();
            
            Assert.AreEqual(expected,actual);
        }
    }
}
