using System;
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

        [TestCase("AAAABBBBBBCCCC", "04A06B04C")] //Nur Gruppen
        [TestCase("TESTSTRING", "TESTSTRING")] //Keine Gruppen
        [TestCase("AAAAAABBCCCCCCDEEEE", "06ABB06CD04E")] //Gruppen und Einzelne
        [TestCase("TEST0STRING", "TEST010STRING")] //Mit Marker ohne Gruppen
        [TestCase("AAAA0BBBB0CCCC0DDDD0EEEE", "04A01004B01004C01004D01004E")]//Mit Marker und Gruppen
        [TestCase("AAAAAAAAAAAAAAAAAAAA", "09A09AAA")] //Überlange Gruppe
        [TestCase("AAAAAAAAAA0AAAAAAAAAA", "09AA01009AA")] //Überlange Gruppe mit Markern
        public void CanGetCompString(String str, String expected) //Eingabe und ergebnis
        {
            var bA = sut.StringToByteArray(str);
            var actual = sut.Encode(bA);
            var expect = sut.StringToByteArray(expected);
            Assert.AreEqual(expect, actual);
        }

        [TestCase("AAAABBBBBBCCCC", "04A")] //Nur Gruppen
        [TestCase("TESTSTRING", "T")] //Keine Gruppen
        [TestCase("AAAAAABBCCCCCCDEEEE", "06A")] //Gruppen und Einzelne
        [TestCase("TEST-STRING", "T")] //Mit Marker ohne Gruppen
        [TestCase("AAAA-BBBB-CCCC-DDDD-EEEE", "04A")]
        [TestCase("AAAAAAAAAAAAAAAAAAAA", "09A")] //Überlange Gruppe
        [TestCase("AAAAAAAAAA0AAAAAAAAAA", "09A")] //Überlange Gruppe mit Markern
        public void GetNextGroup(String str, String expected)
        {
            var bA = sut.StringToByteArray(str);
            var actual = sut.GetNextGroup(bA);
            var expect = sut.StringToByteArray(expected);
            Assert.AreEqual(expect, actual);
        }

        [TestCase("AAAAAA", "06A")]//Komprimierbare Gruppe
        [TestCase("000000", "060")]//Komprimierbare Gruppe aus Markern
        [TestCase("AA", "AA")]//Nicht Komprimierbare Gruppe
        [TestCase("00", "020")]//Nicht Komprimierbare Gruppe aus Markern
        public void CompressGroup(String str, String expected)
        {
            var bA = sut.StringToByteArray(str);
            var actual = sut.CompressGroup(bA);
            var expect = sut.StringToByteArray(expected);
            Assert.AreEqual(expect, actual);
        }
        [TestCase("X1XAX4X")]
        public void Different_Marker(String expected)
        {
            sut.Marker('X');
            var actual = sut.Encode(sut.StringToByteArray("XAXXXX"));
            var expect = sut.StringToByteArray(expected);
            Assert.AreEqual(expect, actual);
        }

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
    }
}
