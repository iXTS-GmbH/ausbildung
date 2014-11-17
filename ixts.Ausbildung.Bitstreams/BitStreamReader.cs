using System;
using System.IO;

namespace ixts.Ausbildung.Bitstreams
{
    public class BitStreamReader:IBitStreamReader
    {
        private readonly StreamReader reader;

        public BitStreamReader(Stream input)
        {
            reader = new StreamReader(input);
        }

        public int Read()
        {
            if (!EndOfStream())
            {
                return reader.Read();
            }
            return 0;
        }

        public Boolean EndOfStream()
        {
            return reader.EndOfStream;
        }

        public void Close()
        {
            reader.Close();
        }
    }
}
