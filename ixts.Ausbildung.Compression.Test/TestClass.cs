using System;
using System.Collections.Generic;
using NUnit.Framework;



namespace ixts.Ausbildung.Compression.Test
{
    [TestFixture]
    public class TestClass
    {
        private RunLengthEncoder sut;

        [SetUp]
        public void SetUp()
        {
            sut = new RunLengthEncoder();
        }

        [TestCaseSource("CanGetCompArraySource")]
        public void CanGetCompArray(Byte[] bA, Byte[] expected) //Eingabe und ergebnis
        {
            var actual = sut.Encode(bA);
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
            var actual = sut.GetNextGroup(bA);
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
        public void CompressGroup(Byte[] bA, Byte[] expected)
        {
            var actual = sut.CompressGroup(bA);
            Assert.AreEqual(expected, actual);
        }

        private static readonly object[] CompressGroupSource = 
            {
                new object[]{new Byte[]{65,65,65,65,65,65},new Byte[]{0,6,65}}, //Komprimierbare Gruppe
                new object[]{new Byte[]{0,0,0,0,0,0},new Byte[]{0,6,0}}, //Komprimierbare Gruppe aus Markern
                new object[]{new Byte[]{65,65},new Byte[]{65,65}}, //Nicht Komprimierbare Gruppe
                new object[]{new Byte[]{0,0},new Byte[]{0,2,0}},//Nicht Komprimierbare Gruppe aus Markern
            };

        [TestCaseSource("DifferentMarkerSource")]
        public void DifferentMarker(Byte[] expected)
        {
            sut.Marker('X');
            var actual = sut.Encode(sut.StringToByteArray("XAXXXX"));
            Assert.AreEqual(expected, actual);
        }
        private static readonly Byte[][] DifferentMarkerSource =
        {
                new Byte[] { 88,1,88,65,88,4,88 }
        };
        [TestCase]
        public void Empty_InputArray()
        {
            Assert.AreEqual(sut.Encode(null),null);
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
            var bL = new List<Byte>{};
            for (int i = 0; i < 256; i++)
            {
                bL.Add(Convert.ToByte('A'));
            }
            var actual = sut.Encode(bL.ToArray());
            var expected = new Byte[] {0,255,65,65};
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource("CanGetDeCompArraySource")]
        public void CanGetDeCompArray(Byte[] bA, Byte[] expected)
        {
            var actual = sut.Decode(bA);
            Assert.AreEqual(expected,actual);
        }

        private static readonly object[] CanGetDeCompArraySource =
            { 
                new object[]{new Byte[]{0,4,65,0,6,66,0,4,67}, new Byte[]{65,65,65,65,66,66,66,66,66,66,67,67,67,67}}, //Nur Gruppen
                new object[]{new Byte[]{84,69,83,84,83,84,82,73,78,71}, new Byte[]{84,69,83,84,83,84,82,73,78,71}}, //Keine Gruppen
                new object[]{new Byte[]{0,6,65,66,66,0,6,67,68,0,4,69}, new Byte[]{65,65,65,65,65,65,66,66,67,67,67,67,67,67,68,69,69,69,69}}, //Gruppen und Einzelne
            };

        [TestCase]
        public void MAX_COUNTER_VALUE_DECOMPRESS_CHECK()
        {
            var bA = new Byte[] { 0, 255, 65 };
            var bL = new List<Byte> { };
            for (int i = 0; i < 255; i++)
            {
                bL.Add(Convert.ToByte('A'));
            }
            var expected = bL.ToArray();
            var actual = sut.Decode(bA);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Empty_Input_Decomp_Array()
        {
            Assert.AreEqual(sut.Decode(null), null);
        }

        [TestCaseSource("GetNextDeCompGroupSource")]
        public void GetNextDeCompGroup(Byte[] bA, Byte[] expected)
        {
            var actual = sut.GetNextDeCompGroup(bA);
            Assert.AreEqual(expected, actual);
        }

        private static readonly object[] GetNextDeCompGroupSource =
            {
                new object[]{new Byte[]{0,4,65,0,5,66,0,4,67,0,7,68},new Byte[]{65,65,65,65}},//Nur Gruppen
                new object[]{new Byte[]{84,69,83,84,83,84,82,73,78,71},new Byte[]{84}},//Keine Gruppen
            };

        [TestCaseSource("DeCompressGroupSource")]
        public void DeCompressGroup(Byte[] group, Byte[] expected)
        {
            var actual = sut.DeCompressGroup(group);
            Assert.AreEqual(expected,actual);
        }

        private static readonly object[] DeCompressGroupSource =
            {
                new object[]{new Byte[]{0,6,65},new Byte[]{65,65,65,65,65,65}}, //Dekomprimierbare Gruppe
                new object[]{new Byte[]{0,6,0},new Byte[]{0,0,0,0,0,0}}, //Dekomprimierbare Gruppe aus Markern
                new object[]{new Byte[]{65},new Byte[]{65}}, //Nicht Dekomprimierbare Gruppe
            };
    }
}
