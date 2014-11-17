using System;

namespace ixts.Ausbildung.Bitstreams
{
    public class BitInputStream
    {
        private readonly IBitStreamReader reader;

        public BitInputStream(IBitStreamReader input)
        {
            reader = input;
        }

        public Boolean Read()
        {
           return reader.Read() == 1;
        }

        public Boolean EndofFile()
        {
            return reader.EndOfStream();
        }

        public void Close()
        {
            reader.Close();
        }
    }
}
