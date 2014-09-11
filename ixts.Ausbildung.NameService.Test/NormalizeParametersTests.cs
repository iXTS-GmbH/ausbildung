using NUnit.Framework;

namespace ixts.Ausbildung.NameService.Test
{
    [TestFixture]
    public class NormalizeParametersTests
    {
        [TestCase]
        public void NormalizeTest()
        {
            var parameters = new []
                {
                    "Command",
                    "Key",
                    "Value1",
                    "Value2",
                    "Value3"
                };

            var expected = new []
                {
                    "Command",
                    "Key",
                    "Value1 Value2 Value3"
                };

            var actual = ParameterHandler.Normalize(parameters);

            Assert.AreEqual(expected,actual);
        }
    }
}
