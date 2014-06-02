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

        [TestCaseSource("CanGetCompStringSource")] //Nur Gruppen
        public void CanGetCompString(Byte[] bA, Byte[] expected) //Eingabe und ergebnis
        {
            var actual = sut.Encode(bA);
            Assert.AreEqual(expected, actual);
        }

        private static readonly object[] CanGetCompStringSource =
            {
                new object[]{new Byte[]{65,65,65,65,66,66,66,66,66,66,67,67,67,67}, new Byte[]{48,4,65,48,6,66,48,4,67}},
                new object[]{new Byte[]{84,69,83,84,83,84,82,73,78,71}, new Byte[]{84,69,83,84,83,84,82,73,78,71}},
                new object[]{new Byte[]{65,65,65,65,65,65,66,66,67,67,67,67,67,67,68,69,69,69,69}, new Byte[]{48,6,65,66,66,48,6,67,68,48,4,69}},
                new object[]{new Byte[]{84,69,83,84,48,83,84,82,73,78,71}, new Byte[]{84,69,83,84,48,1,48,83,84,82,73,78,71}},
                new object[]{new Byte[]{65,65,65,65,48,66,66,66,66,48,67,67,67,67,48,68,68,68,68,48,69,69,69,69}, new Byte[]{48,4,65,48,1,48,48,4,66,48,1,48,48,4,67,48,1,48,48,4,68,48,1,48,48,4,69}},
                new object[]{new Byte[]{65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65}, new Byte[]{48,20,65}},
                new object[]{new Byte[]{65,65,65,65,65,65,65,65,65,65,48,65,65,65,65,65,65,65,65,65,65}, new Byte[]{48,10,65,48,1,48,48,10,65}},
                
            };

        [TestCaseSource("GetNextGroupSource")] 
        public void GetNextGroup(Byte[] bA, Byte[] expected)
        {
            var actual = sut.GetNextGroup(bA);
            Assert.AreEqual(expected, actual);
        }

        private static readonly object[] GetNextGroupSource =
            {
                new object[]{new Byte[]{65,65,65,65,66,66,66,66,67,67,67,67},new Byte[]{48,4,65}},//Nur Gruppen
                new object[]{new Byte[]{84,69,83,84,83,84,82,73,78,71},new Byte[]{84}},//Keine Gruppen
                new object[]{new Byte[]{65,65,65,65,65,65,66,66,67,67,67,67,67,67,68,69,69,69,69},new Byte[]{48,6,65}},//Gruppen und Einzelne
                new object[]{new Byte[]{84,69,83,84,48,83,84,82,73,78,71},new Byte[]{84}},//Mit Marker ohne Gruppen
                new object[]{new Byte[]{65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65},new Byte[]{48,20,65}},//Überlange Gruppe
                new object[]{new Byte[]{65,65,65,65,65,65,65,65,65,65,48,65,65,65,65,65,65,65,65,65,65},new Byte[]{48,10,65}}//Überlange Gruppe mit Markern
            };

        [TestCaseSource("CompressGroupSource")]
        public void CompressGroup(Byte[] bA, Byte[] expected)
        {
            var actual = sut.CompressGroup(bA);
            Assert.AreEqual(expected, actual);
        }

        private static readonly object[] CompressGroupSource = 
            {
                new object[]{new Byte[]{65,65,65,65,65,65},new Byte[]{48,6,65}}, //Komprimierbare Gruppe
                new object[]{new Byte[]{48,48,48,48,48,48},new Byte[]{48,6,48}}, //Komprimierbare Gruppe aus Markern
                new object[]{new Byte[]{65,65},new Byte[]{65,65}}, //Nicht Komprimierbare Gruppe
                new object[]{new Byte[]{48,48},new Byte[]{48,2,48}},//Nicht Komprimierbare Gruppe aus Markern
            };

        [TestCaseSource("DifferentMarkerSource")]
        public void DifferentMarker(Byte[] expected)
        {
            sut.Marker('X');
            var actual = sut.Encode(sut.StringToByteArray("XAXXXX"));
            Assert.AreEqual(expected, actual);
        }
        static readonly Byte[][] DifferentMarkerSource =
        {
                new Byte[] { 88,1,88,65,88,4,88 }
        };
        [TestCase]
        public void Empty_InputString()
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
        public void MAX_COUNTER_VALUE_CHECK()
        {
            var Bl = new List<Byte>{};
            for (int i = 0; i < 256; i++)
            {
                Bl.Add(Convert.ToByte('A'));
            }
            var actual = sut.Encode(Bl.ToArray());
            var expected = new Byte[] {48,255,65,65};
            Assert.AreEqual(expected, actual);
        }
    }
}
