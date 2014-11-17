using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.Bitstreams.Test
{
    public class TestBitStreamWriter:IBitStreamWriter
    {
        public List<Byte> Output = new List<Byte>();
        private readonly int[] writebyte = new int[8];
        private int bitcounter = 7;

        public void Write(Boolean bit)
        {
            if (bitcounter > 0)
            {
                writebyte[bitcounter] = Convert.ToInt32(bit);
                bitcounter--;
            }
            else
            {
                writebyte[bitcounter] = Convert.ToInt32(bit);
                bitcounter = 7;
                var byteString = "";
                foreach (var i in writebyte)
                {
                    byteString = i + byteString;
                }
                Output.Add(Convert.ToByte(byteString,2));
            }
        }

        public void Close()
        {
        }
    }
}
