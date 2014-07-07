using System;
using System.Collections.Generic;
using System.IO;
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

        [TestCase]
        public void StringToByteArray()
        {
            var expected = new Byte[] { 48, 48, 48, 48, 48 };
            const String str = "00000";
            var actual = sut.StringToByteArray(str);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource("DifferentMarkerSource")]
        public void DifferentMarker(Byte[] buffer, Byte[] expected)
        {
            sut.Marker('X');
            var actual = sut.Decode(buffer, 1);
            Assert.AreEqual(expected, actual);
        }
        private static readonly object[] DifferentMarkerSource =
        {
                new object[]{new Byte[] {88,1,88,65,88,4,88},new Byte[]{88,65,88,88,88,88} }
        };

        //[TestCase("Desertx16org.bmp","Desertx16x1.rle" , 393334, 1,"Desertx16x1.bmp")]
        //[TestCase("Desertx16org.bmp", "Desertx16x2.rle", 393334, 2, "Desertx16x2.bmp")]
        //[TestCase("Desertx16org.bmp", "Desertx16x3.rle", 393334, 3, "Desertx16x3.bmp")]
        //[TestCase("Desertx16org.bmp", "Desertx16x4.rle", 393334, 4, "Desertx16x4.bmp")]
        //[TestCase("Desertx24org.bmp", "Desertx24x1.rle", 2359350, 1, "Desertx24x1.bmp")]
        //[TestCase("Desertx24org.bmp", "Desertx24x2.rle", 2359350, 2, "Desertx24x2.bmp")]
        //[TestCase("Desertx24org.bmp", "Desertx24x3.rle", 2359350, 3, "Desertx24x3.bmp")]
        //[TestCase("Desertx24org.bmp", "Desertx24x4.rle", 2359350, 4, "Desertx24x4.bmp")]
        //[TestCase("Desertx256org.bmp", "Desertx256x1.rle", 787510, 1, "Desertx256x1.bmp")]
        //[TestCase("Desertx256org.bmp", "Desertx256x2.rle", 787510, 2, "Desertx256x2.bmp")]
        //[TestCase("Desertx256org.bmp", "Desertx256x3.rle", 787510, 3, "Desertx256x3.bmp")]
        //[TestCase("Desertx256org.bmp", "Desertx256x4.rle", 787510, 4, "Desertx256x4.bmp")]
        //[TestCase("DesertxMonoorg.bmp", "DesertxMonox1.rle", 98366, 1, "DesertxMonox1.bmp")]
        //[TestCase("DesertxMonoorg.bmp", "DesertxMonox2.rle", 98366, 2, "DesertxMonox2.bmp")]
        //[TestCase("DesertxMonoorg.bmp", "DesertxMonox3.rle", 98366, 3, "DesertxMonox3.bmp")]
        //[TestCase("DesertxMonoorg.bmp", "DesertxMonox4.rle", 98366, 4, "DesertxMonox4.bmp")]
        //public void Complete_Decoding_Check(String orgFileName,String encFileName,int bufferSize, int checkRange,String decFileName)
        //{
        //    const string path = @"C:\Users\mkaestl.IXTS\Projekte\Ausbildung\ausbildung\ixts.Ausbildung.Compression.ConsoleApp\bin\Debug\";
        //    var fs = File.OpenRead(@path + orgFileName);
        //    fs.Position = 0; 
        //    var buffer = new Byte[bufferSize];
        //    fs.Read(buffer, 0, bufferSize);
        //    var encoded = File.ReadAllBytes(@path + encFileName);
        //    var actual = sut.Decode(encoded, checkRange);
        //    File.WriteAllBytes(@path + decFileName, actual);
        //    Assert.AreEqual(buffer, actual);
        //    fs.Close();
        //}
    }
}
