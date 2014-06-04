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
        public void CanGetDeCompArray(Byte[] bA, Byte[] expected,int checkRange)
        {
            var actual = sut.Decode(bA, checkRange);
            Assert.AreEqual(expected, actual);
        }

        private static readonly object[] CanGetDeCompArraySource =
            { 
                //CheckRange 1
                new object[]{new Byte[]{0,4,65,0,6,66,0,4,67}, new Byte[]{65,65,65,65,66,66,66,66,66,66,67,67,67,67},1}, //Nur Gruppen
                new object[]{new Byte[]{84,69,83,84,83,84,82,73,78,71}, new Byte[]{84,69,83,84,83,84,82,73,78,71},1}, //Keine Gruppen
                new object[]{new Byte[]{0,6,65,66,66,0,6,67,68,0,4,69}, new Byte[]{65,65,65,65,65,65,66,66,67,67,67,67,67,67,68,69,69,69,69},1}, //Gruppen und Einzelne
                //CheckRange 2
                new object[]{new Byte[]{0,4,65,65,0,3,66,66,0,4,67,67}, new Byte[]{65,65,65,65,65,65,65,65,66,66,66,66,66,66,67,67,67,67,67,67,67,67},2}, //Nur Gruppen
                new object[]{new Byte[]{84,69,83,84,83,84,82,73,78,71}, new Byte[]{84,69,83,84,83,84,82,73,78,71},2}, //Keine Gruppen
                new object[]{new Byte[]{0,3,65,65,66,66,0,4,67,67,68,68,0,4,69,69}, new Byte[]{65,65,65,65,65,65,66,66,67,67,67,67,67,67,67,67,68,68,69,69,69,69,69,69,69,69},2}, //Gruppen und Einzelne
                //CheckRange 3
                new object[]{new Byte[]{0,3,65,65,65,0,3,66,66,66,0,3,67,67,67}, new Byte[]{65,65,65,65,65,65,65,65,65,66,66,66,66,66,66,66,66,66,67,67,67,67,67,67,67,67,67},3}, //Nur Gruppen
                new object[]{new Byte[]{84,69,83,84,83,84,82,73,78,71,69,84}, new Byte[]{84,69,83,84,83,84,82,73,78,71,69,84},3}, //Keine Gruppen
                new object[]{new Byte[]{0,3,65,65,65,66,67,66,0,3,67,67,67,68,64,65,0,3,69,69,69}, new Byte[]{65,65,65,65,65,65,65,65,65,66,67,66,67,67,67,67,67,67,67,67,67,68,64,65,69,69,69,69,69,69,69,69,69},3}, //Gruppen und Einzelne
                //CheckRange 4
                new object[]{new Byte[]{0,3,65,65,65,65,0,3,66,66,66,66,0,3,67,67,67,67}, new Byte[]{65,65,65,65,65,65,65,65,65,65,65,65,66,66,66,66,66,66,66,66,66,66,66,66,67,67,67,67,67,67,67,67,67,67,67,67},4}, //Nur Gruppen
                new object[]{new Byte[]{84,69,83,84,83,84,82,73,78,71,69,84}, new Byte[]{84,69,83,84,83,84,82,73,78,71,69,84},4}, //Keine Gruppen
                new object[]{new Byte[]{0,3,65,65,65,65,66,66,66,66,0,3,67,67,67,67,68,68,68,68,0,3,69,69,69,69}, new Byte[]{65,65,65,65,65,65,65,65,65,65,65,65,66,66,66,66,67,67,67,67,67,67,67,67,67,67,67,67,68,68,68,68,69,69,69,69,69,69,69,69,69,69,69,69},4}, //Gruppen und Einzelne
            };

        [TestCase]
        public void MAX_COUNTER_VALUE_DECOMPRESS_CHECK()
        {
            var bA = new Byte[] { 0, 255, 65 };
            var bL = new List<Byte> ();
            for (int i = 0; i < 255; i++)
            {
                bL.Add(Convert.ToByte('A'));
            }
            var expected = bL.ToArray();
            var actual = sut.Decode(bA, 1);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Empty_Input_Decomp_Array()
        {
            Assert.AreEqual(sut.Decode(null, 1), null);
        }

        [TestCaseSource("GetNextDeCompGroupSource")]
        public void GetNextDeCompGroup(Byte[] bA, Byte[] expected, int checkRange)
        {
            var actual = sut.GetNextDeCompGroup(bA, checkRange);
            Assert.AreEqual(expected, actual);
        }

        private static readonly object[] GetNextDeCompGroupSource =
            {
                //CheckRange 1
                new object[]{new Byte[]{0,4,65,0,5,66,0,4,67,0,7,68},new Byte[]{65,65,65,65},1},//Nur Gruppen
                new object[]{new Byte[]{84,69,83,84,83,84,82,73,78,71},new Byte[]{84},1},//Keine Gruppen
                //CheckRange 2
                new object[]{new Byte[]{0,4,65,65,0,5,66,66,0,4,67,67,0,7,68,68},new Byte[]{65,65,65,65,65,65,65,65},2},//Nur Gruppen
                new object[]{new Byte[]{84,69,83,84,83,84,82,73,78,71},new Byte[]{84,69},2},//Keine Gruppen
                //CheckRange 3
                new object[]{new Byte[]{0,4,65,65,65,0,5,66,66,66,0,4,67,67,67,0,7,68,68,68,68},new Byte[]{65,65,65,65,65,65,65,65,65,65,65,65},3},//Nur Gruppen
                new object[]{new Byte[]{84,69,83,84,83,84,82,73,78,71},new Byte[]{84,69,83},3},//Keine Gruppen
                //CheckRange 4
                new object[]{new Byte[]{0,4,65,65,65,65,0,5,66,66,66,66,0,4,67,67,67,67,0,7,68,68,68,68},new Byte[]{65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65},4},//Nur Gruppen
                new object[]{new Byte[]{84,69,83,84,83,84,82,73,78,71},new Byte[]{84,69,83,84},4},//Keine Gruppen
            };

        [TestCaseSource("DeCompressGroupSource")]
        public void DeCompressGroup(List<Byte> group, Byte[] expected, int checkRange)
        {
            var actual = sut.DeCompressGroup(group, checkRange);
            Assert.AreEqual(expected, actual);
        }

        private static readonly object[] DeCompressGroupSource =
            {
                //CheckRange 1
                new object[]{new List<Byte>{0,6,65},new Byte[]{65,65,65,65,65,65},1}, //Dekomprimierbare Gruppe
                new object[]{new List<Byte>{0,6,0},new Byte[]{0,0,0,0,0,0},1}, //Dekomprimierbare Gruppe aus Markern
                new object[]{new List<Byte>{65},new Byte[]{65},1}, //Nicht Dekomprimierbare Gruppe
                //CheckRange 2
                new object[]{new List<Byte>{0,3,65,65},new Byte[]{65,65,65,65,65,65},2}, //Dekomprimierbare Gruppe
                new object[]{new List<Byte>{0,3,0,0},new Byte[]{0,0,0,0,0,0},2}, //Dekomprimierbare Gruppe aus Markern
                new object[]{new List<Byte>{65,65},new Byte[]{65,65},2}, //Nicht Dekomprimierbare Gruppe
                //CheckRange 3
                new object[]{new List<Byte>{0,3,65,65,65},new Byte[]{65,65,65,65,65,65,65,65,65},3}, //Dekomprimierbare Gruppe
                new object[]{new List<Byte>{0,3,0,0,0},new Byte[]{0,0,0,0,0,0,0,0,0},3}, //Dekomprimierbare Gruppe aus Markern
                new object[]{new List<Byte>{65,65,65},new Byte[]{65,65,65},3}, //Nicht Dekomprimierbare Gruppe
                //CheckRange 4
                new object[]{new List<Byte>{0,3,65,65,65,65},new Byte[]{65,65,65,65,65,65,65,65,65,65,65,65},4}, //Dekomprimierbare Gruppe
                new object[]{new List<Byte>{0,3,0,0,0,0},new Byte[]{0,0,0,0,0,0,0,0,0,0,0,0},4}, //Dekomprimierbare Gruppe aus Markern
                new object[]{new List<Byte>{65,65,65,65},new Byte[]{65,65,65,65},4}, //Nicht Dekomprimierbare Gruppe
            };
    }
}
