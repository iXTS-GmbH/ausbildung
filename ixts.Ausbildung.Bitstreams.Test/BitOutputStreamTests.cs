using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ixts.Ausbildung.Bitstreams.Test
{
    [TestFixture]
    public class BitOutputStreamTests
    {
        [TestCase()]
        public void WriteTest()
        {
            var expected = new List<Byte> { 65, 66, 67 };
            var streamWriter = new TestBitStreamWriter();
            var outputStream = new BitOutputStream(streamWriter);
            var toWrite = new []
                {
                    0,1,0,0,0,0,0,1,//A
                    0,1,0,0,0,0,1,0,//B
                    0,1,0,0,0,0,1,1//C
                };

            foreach (var bit in toWrite)
            {
                outputStream.Write(bit == 1);
            }

            Assert.AreEqual(expected,streamWriter.Output);
        }
    }
}
