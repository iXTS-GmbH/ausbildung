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
            String[] parameters = new String[]
                {
                    "Command",
                    "Key",
                    "Value1",
                    "Value2",
                    "Value3"
                };

            String[] expected = new String[]
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
