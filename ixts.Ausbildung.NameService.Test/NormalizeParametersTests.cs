using System;
using NUnit.Framework;

namespace ixts.Ausbildung.NameService.Test
{
    [TestFixture]
    public class NormalizeParametersTests
    {
        [TestCase]
        public void NormalizeTest()
        {
            String[] parameters = new []
                {
                    "Command",
                    "Key",
                    "Value1",
                    "Value2",
                    "Value3"
                };

            String[] expected = new []
                {
                    "Command",
                    "Key",
                    "Value1 Value2 Value3"
                };

            String[] actual = ParameterHandler.Normalize(parameters);

            Assert.AreEqual(expected,actual);
        }
    }
}
