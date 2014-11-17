using System;

namespace ixts.Ausbildung.Bitstreams
{
    public class BitOutputStream
    {
        private IBitStreamWriter writer;

        public BitOutputStream(IBitStreamWriter output)
        {
            writer = output;
        }

        public void Write(Boolean bit)
        {
            writer.Write(bit);
        }

        public void Close()
        {
            writer.Close();
        }
    }
}
