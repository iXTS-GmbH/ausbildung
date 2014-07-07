using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;



namespace ixts.Ausbildung.Compression.Test
{
    [TestFixture]
    public class RunLengthcEncoderTests
    {
        private RunLengthEncoder sut;

        [SetUp]
        public void SetUp()
        {
            sut = new RunLengthEncoder();
        }

        [TestCaseSource("CanGetCompArraySource")]
        public void CanGetCompArray(Byte[] bA, Byte[] expected, int checkRange)
        {
            var actual = sut.Encode(bA, checkRange);
            Assert.AreEqual(expected, actual);
        }

        private static readonly object[] CanGetCompArraySource =
            {
                //CheckRange 1
                new object[]{new Byte[]{65,65,65,65,66,66,66,66,66,66,67,67,67,67}, new Byte[]{0,4,65,0,6,66,0,4,67},1}, //Nur Gruppen
                new object[]{new Byte[]{84,69,83,84,83,84,82,73,78,71}, new Byte[]{84,69,83,84,83,84,82,73,78,71},1}, //Keine Gruppen
                new object[]{new Byte[]{65,65,65,65,65,65,66,66,67,67,67,67,67,67,68,69,69,69,69}, new Byte[]{0,6,65,66,66,0,6,67,68,0,4,69},1}, //Gruppen und Einzelne
                new object[]{new Byte[]{84,69,83,84,0,83,84,82,73,78,71}, new Byte[]{84,69,83,84,0,1,0,83,84,82,73,78,71},1}, //Mit Marker ohne Gruppen
                new object[]{new Byte[]{65,65,65,65,0,66,66,66,66,0,67,67,67,67,0,68,68,68,68,0,69,69,69,69}, new Byte[]{0,4,65,0,1,0,0,4,66,0,1,0,0,4,67,0,1,0,0,4,68,0,1,0,0,4,69},1}, //Mit Marker und Gruppen
                //CheckRange 2
                new object[]{new Byte[]{65,65,65,65,66,66,66,66,66,66,67,67,67,67}, new Byte[]{65,65,65,65,0,3,66,66,67,67,67,67},2}, //Nur Gruppen
                new object[]{new Byte[]{84,69,83,84,83,84,82,73,78,71}, new Byte[]{84,69,83,84,83,84,82,73,78,71},2}, //Keine Gruppen
                new object[]{new Byte[]{65,65,65,65,65,65,66,66,67,67,67,67,67,67,68,69,69,69,69}, new Byte[]{0,3,65,65,66,66,0,3,67,67,68,69,69,69,69},2}, //Gruppen und Einzelne
                new object[]{new Byte[]{84,69,83,84,0,83,84,82,73,78,71}, new Byte[]{84,69,83,84,0,1,0,83,84,82,73,78,71},2}, //Mit Marker ohne Gruppen
                new object[]{new Byte[]{65,65,65,65,0,66,66,66,66,0,67,67,67,67,0,68,68,68,68,0,69,69,69,69}, new Byte[]{65,65,65,65,0,1,0,66,66,66,66,0,67,67,67,67,0,1,0,68,68,68,68,0,69,69,69,69},2}, //Mit Marker und Gruppen
                //CheckRange 3
                new object[]{new Byte[]{65,65,65,65,66,66,66,66,66,66,67,67,67,67}, new Byte[]{65,65,65,65,66,66,66,66,66,66,67,67,67,67},3}, //Nur Gruppen
                new object[]{new Byte[]{84,69,83,84,83,84,82,73,78,71}, new Byte[]{84,69,83,84,83,84,82,73,78,71},3}, //Keine Gruppen
                new object[]{new Byte[]{65,65,65,65,65,65,66,66,67,67,67,67,67,67,68,69,69,69,69}, new Byte[]{65,65,65,65,65,65,66,66,67,67,67,67,67,67,68,69,69,69,69},3}, //Gruppen und Einzelne
                new object[]{new Byte[]{84,69,83,84,0,83,84,82,73,78,71}, new Byte[]{84,69,83,84,0,83,84,82,73,78,71},3}, //Mit Marker ohne Gruppen
                new object[]{new Byte[]{65,65,65,65,0,66,66,66,66,0,67,67,67,67,0,68,68,68,68,0,69,69,69,69}, new Byte[]{65,65,65,65,0,66,66,66,66,0,1,0,67,67,67,67,0,68,68,68,68,0,69,69,69,69},3}, //Mit Marker und Gruppen
                //CheckRange 4
                new object[]{new Byte[]{65,65,65,65,66,66,66,66,66,66,67,67,67,67}, new Byte[]{65,65,65,65,66,66,66,66,66,66,67,67,67,67},4}, //Nur Gruppen
                new object[]{new Byte[]{84,69,83,84,83,84,82,73,78,71}, new Byte[]{84,69,83,84,83,84,82,73,78,71},4}, //Keine Gruppen
                new object[]{new Byte[]{65,65,65,65,65,65,66,66,67,67,67,67,67,67,68,69,69,69,69}, new Byte[]{65,65,65,65,65,65,66,66,67,67,67,67,67,67,68,69,69,69,69},4}, //Gruppen und Einzelne
                new object[]{new Byte[]{84,69,83,84,0,83,84,82,73,78,71}, new Byte[]{84,69,83,84,0,1,0,83,84,82,73,78,71},4}, //Mit Marker ohne Gruppen
                new object[]{new Byte[]{65,65,65,65,0,66,66,66,66,0,67,67,67,67,0,68,68,68,68,0,69,69,69,69}, new Byte[]{65,65,65,65,0,1,0,66,66,66,66,0,67,67,67,67,0,68,68,68,68,0,69,69,69,69},4}, //Mit Marker und Gruppen
                
            };

        [TestCaseSource("GetNextGroupSource")] 
        public void GetNextGroup(Byte[] buffer, List<Byte> expected, int checkRange)
        {
            var actual = sut.GetNextGroup(buffer, checkRange);
            Assert.AreEqual(expected, actual);
        }

        private static readonly object[] GetNextGroupSource =
            {
                //CheckRange 1
                new object[]{new Byte[]{65,65,65,65,66,66,66,66,67,67,67,67},new List<Byte>{0,4,65}, 1},//Nur Gruppen
                new object[]{new Byte[]{84,69,83,84,83,84,82,73,78,71},new List<Byte>{84},1},//Keine Gruppen
                new object[]{new Byte[]{65,65,65,65,65,65,66,66,67,67,67,67,67,67,68,69,69,69,69},new List<Byte>{0,6,65},1},//Gruppen und Einzelne
                new object[]{new Byte[]{84,69,83,84,0,83,84,82,73,78,71},new List<Byte>{84},1},//Mit Marker ohne Gruppen
                //CheckRange 2
                new object[]{new Byte[]{65,65,65,65,66,66,66,66,67,67,67,67},new List<Byte>{65,65,65,65}, 2},//Nur Gruppen
                new object[]{new Byte[]{84,69,83,84,83,84,82,73,78,71},new List<Byte>{84,69},2},//Keine Gruppen
                new object[]{new Byte[]{65,65,65,65,65,65,66,66,67,67,67,67,67,67,68,69,69,69,69},new List<Byte>{0,3,65,65},2},//Gruppen und Einzelne
                new object[]{new Byte[]{84,69,83,84,0,83,84,82,73,78,71},new List<Byte>{84,69},2},//Mit Marker ohne Gruppen
                //CheckRange 3
                new object[]{new Byte[]{65,65,65,65,66,66,66,66,67,67,67,67},new List<Byte>{65,65,65}, 3},//Nur Gruppen
                new object[]{new Byte[]{84,69,83,84,83,84,82,73,78,71},new List<Byte>{84,69,83},3},//Keine Gruppen
                new object[]{new Byte[]{65,65,65,65,65,65,66,66,67,67,67,67,67,67,68,69,69,69,69},new List<Byte>{65,65,65,65,65,65},3},//Gruppen und Einzelne
                new object[]{new Byte[]{84,69,83,84,0,83,84,82,73,78,71},new List<Byte>{84,69,83},3},//Mit Marker ohne Gruppen
                //CheckRange 4
                new object[]{new Byte[]{65,65,65,65,66,66,66,66,67,67,67,67},new List<Byte>{65,65,65,65}, 4},//Nur Gruppen
                new object[]{new Byte[]{84,69,83,84,83,84,82,73,78,71},new List<Byte>{84,69,83,84},4},//Keine Gruppen
                new object[]{new Byte[]{65,65,65,65,65,65,66,66,67,67,67,67,67,67,68,69,69,69,69},new List<Byte>{65,65,65,65},4},//Gruppen und Einzelne
                new object[]{new Byte[]{84,69,83,84,0,83,84,82,73,78,71},new List<Byte>{84,69,83,84},4},//Mit Marker ohne Gruppen
            };

        [TestCaseSource("CompressGroupSource")]
        public void CompressGroup(List<Byte> bA, List<Byte> expected, int checkRange)
        {
            var actual = sut.CompressGroup(bA, checkRange);
            Assert.AreEqual(expected, actual);
        }

        private static readonly object[] CompressGroupSource = 
            {
                //CheckRange 1
                new object[]{new List<Byte>{65,65,65,65,65,65},new List<Byte>{0,6,65},1}, //Komprimierbare Gruppe
                new object[]{new List<Byte>{0,0,0,0,0,0},new List<Byte>{0,6,0},1}, //Komprimierbare Gruppe aus Markern
                new object[]{new List<Byte>{65,65},new List<Byte>{65,65},1}, //Nicht Komprimierbare Gruppe
                new object[]{new List<Byte>{0,0},new List<Byte>{0,2,0},1},//Nicht Komprimierbare Gruppe aus Markern
                //CheckRange 2
                new object[]{new List<Byte>{65,65,65,65,65,65},new List<Byte>{0,3,65,65},2}, //Komprimierbare Gruppe
                new object[]{new List<Byte>{0,0,0,0,0,0},new List<Byte>{0,3,0,0},2}, //Komprimierbare Gruppe aus Markern
                new object[]{new List<Byte>{65,65},new List<Byte>{65,65},2}, //Nicht Komprimierbare Gruppe
                new object[]{new List<Byte>{0,0},new List<Byte>{0,1,0,0},2},//Nicht Komprimierbare Gruppe aus Markern
                //CheckRange 3
                new object[]{new List<Byte>{65,65,65,65,65,65,65,65,65},new List<Byte>{0,3,65,65,65},3}, //Komprimierbare Gruppe
                new object[]{new List<Byte>{0,0,0,0,0,0},new List<Byte>{0,2,0,0,0},3}, //Komprimierbare Gruppe aus Markern
                new object[]{new List<Byte>{65,65,65},new List<Byte>{65,65,65},3}, //Nicht Komprimierbare Gruppe
                new object[]{new List<Byte>{0,0,0},new List<Byte>{0,1,0,0,0},3},//Nicht Komprimierbare Gruppe aus Markern
                //CheckRange 4
                new object[]{new List<Byte>{65,65,65,65,65,65,65,65,65,65,65,65},new List<Byte>{0,3,65,65,65,65},4}, //Komprimierbare Gruppe
                new object[]{new List<Byte>{0,0,0,0,0,0,0,0},new List<Byte>{0,2,0,0,0,0},4}, //Komprimierbare Gruppe aus Markern
                new object[]{new List<Byte>{65,65,65,65},new List<Byte>{65,65,65,65},4}, //Nicht Komprimierbare Gruppe
                new object[]{new List<Byte>{0,0,0,0},new List<Byte>{0,1,0,0,0,0},4},//Nicht Komprimierbare Gruppe aus Markern
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
            var buffer = new List<Byte>();
            for (int i = 0; i < 256; i++)
            {
                buffer.Add(Convert.ToByte('T'));
            }
            var actual = sut.Encode(buffer.ToArray(), 1);
            var expected = new List<Byte> {0,255,84,84};
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void OVER_MAX_COUNTER_VALUE_COMPRESS_CHECK()
        {
            var buffer = new List<Byte>();
            for (int i = 0; i < 510; i++)
            {
                buffer.Add(Convert.ToByte('T'));
            }
            var actual = sut.Encode(buffer.ToArray(), 1);
            var expected = new List<Byte> { 0, 255, 84, 0,255,84 };
            Assert.AreEqual(expected, actual);
        }

        //[TestCase("Desertx16org.bmp", 393334, 1, "Desertx16x1.rle")]
        //[TestCase("Desertx16org.bmp", 393334, 2, "Desertx16x2.rle")]
        //[TestCase("Desertx16org.bmp", 393334, 3, "Desertx16x3.rle")]
        //[TestCase("Desertx16org.bmp", 393334, 4, "Desertx16x4.rle")]
        //[TestCase("Desertx24org.bmp", 2359350, 1, "Desertx24x1.rle")]
        //[TestCase("Desertx24org.bmp", 2359350, 2, "Desertx24x2.rle")]
        //[TestCase("Desertx24org.bmp", 2359350, 3, "Desertx24x3.rle")]
        //[TestCase("Desertx24org.bmp", 2359350, 4, "Desertx24x4.rle")]
        //[TestCase("Desertx256org.bmp", 787510, 1, "Desertx256x1.rle")]
        //[TestCase("Desertx256org.bmp", 787510, 2, "Desertx256x2.rle")]
        //[TestCase("Desertx256org.bmp", 787510, 3, "Desertx256x3.rle")]
        //[TestCase("Desertx256org.bmp", 787510, 4, "Desertx256x4.rle")]
        //[TestCase("DesertxMonoorg.bmp", 98366, 1, "DesertxMonox1.rle")]
        //[TestCase("DesertxMonoorg.bmp", 98366, 2, "DesertxMonox2.rle")]
        //[TestCase("DesertxMonoorg.bmp", 98366, 3, "DesertxMonox3.rle")]
        //[TestCase("DesertxMonoorg.bmp", 98366, 4, "DesertxMonox4.rle")]
        //public void Complete_Encoding_Check_With_Desert_Img(String orgFileName, int bufferSize, int checkRange, String encFileName)
        //{
        //    const string path = @"C:\Users\mkaestl.IXTS\Projekte\Ausbildung\ausbildung\ixts.Ausbildung.Compression.ConsoleApp\bin\Debug\";
        //    var fs = File.OpenRead(@path + orgFileName);
        //    fs.Position = 0;
        //    var buffer = new Byte[bufferSize];
        //    fs.Read(buffer, 0, bufferSize);
        //    var encoded = sut.Encode(buffer, checkRange);
        //    File.WriteAllBytes(@path + encFileName, encoded);
        //    fs.Close();
        //}
    }
}
