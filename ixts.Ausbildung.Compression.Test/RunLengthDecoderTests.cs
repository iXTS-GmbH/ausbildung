using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ixts.Ausbildung.Compression.Test
{
    [TestFixture]
    public class RunLengthDecoderTests
    {
        private RunLengthDecoder sut;

        [SetUp]
        public void SetUp()
        {
            sut = new RunLengthDecoder();
        }

        [TestCaseSource("CanGetDeCompArraySource")]
        public void CanGetDeCompArray(Byte[] bA, Byte[] expected)
        {
            var actual = sut.Decode(bA);
            Assert.AreEqual(expected, actual);
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
        public void DeCompressGroup(List<Byte> group, Byte[] expected)
        {
            var actual = sut.DeCompressGroup(group);
            Assert.AreEqual(expected, actual);
        }

        private static readonly object[] DeCompressGroupSource =
            {
                new object[]{new List<Byte>{0,6,65},new Byte[]{65,65,65,65,65,65}}, //Dekomprimierbare Gruppe
                new object[]{new List<Byte>{0,6,0},new Byte[]{0,0,0,0,0,0}}, //Dekomprimierbare Gruppe aus Markern
                new object[]{new List<Byte>{65},new Byte[]{65}}, //Nicht Dekomprimierbare Gruppe
            };
    }
}
