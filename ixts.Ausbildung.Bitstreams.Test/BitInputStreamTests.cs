using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace ixts.Ausbildung.Bitstreams.Test
{
    [TestFixture]
    public class BitInputStreamTests
    {

        [TestCase("ABC")]
        public void ReadTest(String input)
        {
            var streamReader = new TestBitStreamReader(input);
            var inputStream = new BitInputStream(streamReader);
            var resultarray = new List<Byte>();

            while (!inputStream.EndofFile())
            {
                var byteString = "";

                for (var i = 0; i < 8; i++)
                {
                    if (inputStream.Read())
                    {
                        byteString = byteString + 1;
                    }
                    else
                    {
                        byteString = byteString + 0;
                    }
                }
                var result = Convert.ToByte(byteString, 2);
                resultarray.Add(result);
            }

            Assert.AreEqual(input,Encoding.ASCII.GetString(resultarray.ToArray()));
        }
    }
}
