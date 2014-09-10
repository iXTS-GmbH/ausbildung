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

        [TestCase]
        public void ParseSpezialCharsToNormalTest()
        {
            String[] parameters = new []
                {
                    "Command",
                    "Key",
                    "ÄValue",
                    "äValue",
                    "ÖValue",
                    "öValue",
                    "ÜValue",
                    "üValue",
                    "ßValue"
                };

            String[] expected = new[]
                {
                    "Command",
                    "Key",
                    "Ae-Value",
                    "ae-Value",
                    "Oe-Value",
                    "oe-Value",
                    "Ue-Value",
                    "ue-Value",
                    "ss-Value"
                };

            String[] actual = ParameterHandler.ParseSpezialCharsToNormal(parameters);

            Assert.AreEqual(expected,actual);

        }
    }
}
