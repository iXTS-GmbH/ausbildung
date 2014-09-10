using System;
using NUnit.Framework;

namespace ixts.Ausbildung.NameService.Test
{
    [TestFixture]
    public class NormalizeParametersTests
    {
        [TestCase]
        public void MoreValueTest()
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

            String[] actual = NormalizeParameters.Normalize(parameters);

            Assert.AreEqual(expected,actual);
        }

        [TestCase]
        public void SpezialValueTest()
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
            String[] expected = new []
                {
                    "Command",
                    "Key",
                    "Ae-Value ae-Value Oe-Value oe-Value Ue-Value ue-Value ss-Value"
                };

            String[] actual = NormalizeParameters.Normalize(parameters);

            Assert.AreEqual(expected,actual);
        }

    }
}
