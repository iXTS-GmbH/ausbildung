using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ixts.Ausbildung.Vorlesungsverzeichnis.Test
{
    [TestFixture]
    public class LecturesTests
    {
        [TestCase()]
        public void TitlesTest()
        {
            var expected = new List<String>
                {
                    "Compilerbau",
                    "Datenbanken",
                    "Softwareentwicklung II"
                };

            var lecture = new Lectures("Test", new TestFileStream());

            var actual = lecture.Titles();

            Assert.AreEqual(expected,actual);
        }

        [TestCase()]
        public void WorkaholicsTest()
        {
            var expected = new List<String>
                {
                    "Schiedermeier"
                };

            var lecture = new Lectures("Test", new TestFileStream());

            var actual = lecture.Workaholics();

            Assert.AreEqual(expected,actual);
        }

        [TestCase()]
        public void GroupToTitlesTest()
        {
            var expected = new List<String>
                {
                    "Compilerbau",
                    "Datenbanken"
                };
            var lecture = new Lectures("Test", new TestFileStream());

            var actual = lecture.GroupToTiles("IFB4");

            Assert.AreEqual(expected,actual);
        }
    }
}
