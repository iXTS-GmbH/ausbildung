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
    }
}
