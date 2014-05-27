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

        [TestCase("AAAABBBBBBCCCC", "-4A-6B-4C")] //Nur Gruppen
        [TestCase("TESTSTRING", "TESTSTRING")] //Keine Gruppen
        [TestCase("AAAAAABBCCCCCCDEEEE", "-6ABB-6CD-4E")] //Gruppen und Einzelne
        [TestCase("TEST-STRING", "TEST-STRING")] //Mit Marker ohne Gruppen
        [TestCase("AAAA-BBBB-CCCC-DDDD-EEEE", "-4A--4B--4C--4D--4E")]
        [TestCase("AAAAAAAAAAAAAAAAAAAA", "-9A-9AAA")] //Überlange Gruppe
        [TestCase("AAAAAAAAAA-AAAAAAAAAA", "-9AA--9AA")] //Überlange Gruppe mit Markern
        public void CanGetCompString(String str, String expected) //Eingabe und ergebnis
        {
            String actual = sut.Encode(str);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("AAAABBBBBBCCCC", "AAAA")] //Nur Gruppen
        [TestCase("TESTSTRING", "T")] //Keine Gruppen
        [TestCase("AAAAAABBCCCCCCDEEEE", "AAAAAA")] //Gruppen und Einzelne
        [TestCase("TEST-STRING", "T")] //Mit Marker ohne Gruppen
        [TestCase("AAAA-BBBB-CCCC-DDDD-EEEE", "AAAA")]
        [TestCase("AAAAAAAAAAAAAAAAAAAA", "AAAAAAAAA")] //Überlange Gruppe
        [TestCase("AAAAAAAAAA-AAAAAAAAAA", "AAAAAAAAA")] //Überlange Gruppe mit Markern
        public void GetNextGroup(String str, String expected)
        {
            String actual = sut.GetNextGroup(str);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("AAAAAA", "-6A")]//Komprimierbare Gruppe
        [TestCase("------", "-6-")]//Komprimierbare Gruppe aus Markern
        [TestCase("AA", "AA")]//Nicht Komprimierbare Gruppe
        [TestCase("--", "--")]//Nicht Komprimierbare Gruppe aus Markern
        public void CompressGroup(String str, String expected)
        {
            String actual = sut.CompressGroup(str);
            Assert.AreEqual(expected, actual);
        }

    }
}
