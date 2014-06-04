using System;
using System.Collections.Generic;
using NUnit.Framework;



namespace ixts.Ausbildung.Compression.Test
{
    [TestFixture]
    public class RunLengthEncodeTests
    {
        private RunLengthEncoder sut;

        [SetUp]
        public void SetUp()
        {
            sut = new RunLengthEncoder();
        }

        [TestCaseSource("CanGetCompArraySource")]
        public void CanGetCompArray(Byte[] bA, Byte[] expected)
        {
            var actual = sut.Encode(bA, 1);
            Assert.AreEqual(expected, actual);
        }

        private static readonly object[] CanGetCompArraySource =
            {
                new object[]{new Byte[]{65,65,65,65,66,66,66,66,66,66,67,67,67,67}, new Byte[]{0,4,65,0,6,66,0,4,67}}, //Nur Gruppen
                new object[]{new Byte[]{84,69,83,84,83,84,82,73,78,71}, new Byte[]{84,69,83,84,83,84,82,73,78,71}}, //Keine Gruppen
                new object[]{new Byte[]{65,65,65,65,65,65,66,66,67,67,67,67,67,67,68,69,69,69,69}, new Byte[]{0,6,65,66,66,0,6,67,68,0,4,69}}, //Gruppen und Einzelne
                new object[]{new Byte[]{84,69,83,84,0,83,84,82,73,78,71}, new Byte[]{84,69,83,84,0,1,0,83,84,82,73,78,71}}, //Mit Marker ohne Gruppen
                new object[]{new Byte[]{65,65,65,65,0,66,66,66,66,0,67,67,67,67,0,68,68,68,68,0,69,69,69,69}, new Byte[]{0,4,65,0,1,0,0,4,66,0,1,0,0,4,67,0,1,0,0,4,68,0,1,0,0,4,69}}, //Mit Marker und Gruppen
                
            };

        [TestCaseSource("GetNextGroupSource")] 
        public void GetNextGroup(Byte[] bA, Byte[] expected)
        {
            var actual = sut.GetNextGroup(bA, 1);
            Assert.AreEqual(expected, actual);
        }

        private static readonly object[] GetNextGroupSource =
            {
                new object[]{new Byte[]{65,65,65,65,66,66,66,66,67,67,67,67},new Byte[]{0,4,65}},//Nur Gruppen
                new object[]{new Byte[]{84,69,83,84,83,84,82,73,78,71},new Byte[]{84}},//Keine Gruppen
                new object[]{new Byte[]{65,65,65,65,65,65,66,66,67,67,67,67,67,67,68,69,69,69,69},new Byte[]{0,6,65}},//Gruppen und Einzelne
                new object[]{new Byte[]{84,69,83,84,0,83,84,82,73,78,71},new Byte[]{84}},//Mit Marker ohne Gruppen
            };

        [TestCaseSource("CompressGroupSource")]
        public void CompressGroup(List<Byte> bA, List<Byte> expected)
        {
            var actual = sut.CompressGroup(bA, 1);
            Assert.AreEqual(expected, actual);
        }

        private static readonly object[] CompressGroupSource = 
            {
                new object[]{new List<Byte>{65,65,65,65,65,65},new List<Byte>{0,6,65}}, //Komprimierbare Gruppe
                new object[]{new List<Byte>{0,0,0,0,0,0},new List<Byte>{0,6,0}}, //Komprimierbare Gruppe aus Markern
                new object[]{new List<Byte>{65,65},new List<Byte>{65,65}}, //Nicht Komprimierbare Gruppe
                new object[]{new List<Byte>{0,0},new List<Byte>{0,2,0}},//Nicht Komprimierbare Gruppe aus Markern
            };

        [TestCaseSource("DifferentMarkerSource")]
        public void DifferentMarker(Byte[] expected)
        {
            sut.Marker('X');
            var actual = sut.Encode(sut.StringToByteArray("XAXXXX"), 1);
            Assert.AreEqual(expected, actual);
        }
        private static readonly Byte[][] DifferentMarkerSource =
        {
                new Byte[] { 88,1,88,65,88,4,88 }
        };
        [TestCase]
        public void Empty_InputArray()
        {
            Assert.AreEqual(sut.Encode(null, 1),null);
        }


        [TestCase]
        public void StringToByteArray()
        {
            var expected = new Byte[] {48,48,48,48,48};
            const String str = "00000";
            var actual = sut.StringToByteArray(str);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void MAX_COUNTER_VALUE_COMPRESS_CHECK()
        {
            var bL = new List<Byte>();
            for (int i = 0; i < 256; i++)
            {
                bL.Add(Convert.ToByte('A'));
            }
            var actual = sut.Encode(bL.ToArray(), 1);
            var expected = new Byte[] {0,255,65,65};
            Assert.AreEqual(expected, actual);
        }
    }
}
