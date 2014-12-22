using System;
using System.IO;

namespace ixts.Ausbildung.Bitstreams
{
    public class BitStreamWriter:IBitStreamWriter
    {
        private readonly StreamWriter writer;
        private readonly int[] writebyte = new int[8];
        private int bitcounter = 8;

        public BitStreamWriter(StreamWriter output)
        {
            writer = output;
        }

        public void Write(Boolean bit)
        {
            if (bitcounter > -1)
            {
                writebyte[bitcounter] = Convert.ToInt32(bit);
                bitcounter--;
            }
            else
            {
                bitcounter = 8;
                writer.Write(Convert.ToByte(writebyte));
            }
        }

        public void Close()
        {
            writer.Close();
        }
    }
}
