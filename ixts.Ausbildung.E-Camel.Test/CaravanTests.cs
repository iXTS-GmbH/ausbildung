using NUnit.Framework;

namespace ixts.Ausbildung.E_Camel.Test
{
    [TestFixture]
    public class CaravanTests
    {
        private Caravan caravan;

        [SetUp]
        public void SetUp()
        {
            caravan = new Caravan();
            caravan.AddCamel(new Camel(8));
            caravan.AddCamel(new Camel(9));
            caravan.AddCamel(new Camel(7));
            caravan.AddCamel(new Camel(8));
            caravan.AddCamel(new Camel(9));
        }

        [TestCase(7)]
        public void PaceTest(int expected)
        {
            var actual = caravan.Pace();

            Assert.AreEqual(expected,actual);
        }

        [TestCase(7,6)]
        public void AddLoadTest(int l, int expected)
        {
            caravan.AddLoad(l);
            var actual = caravan.Pace();
        }

        [TestCase(10,7)]
        public void UnLoadTest(int l, int expected)
        {
            caravan.AddLoad(l);
            caravan.Unload();
            var actual = caravan.Pace();

            Assert.AreEqual(expected,actual);
        }
    }
}
