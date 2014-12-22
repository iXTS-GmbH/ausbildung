using NUnit.Framework;

namespace ixts.Ausbildung.Josephusring.Test
{
    [TestFixture]
    public class RingTests
    {

        [TestCase(4,3,0)]
        [TestCase(5,7,3)]
        public void GetJosephusPositionTest(int prisioners, int fatalNumber, int expected)
        {
            var ring = new Ring(prisioners);

            var actual = ring.GetJosephusPosition(fatalNumber);

            Assert.AreEqual(expected,actual);
        }
    }
}
