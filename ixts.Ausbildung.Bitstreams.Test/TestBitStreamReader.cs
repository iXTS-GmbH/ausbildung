using System;
using System.Collections.Generic;
using System.Text;

namespace ixts.Ausbildung.Bitstreams.Test
{
    public class TestBitStreamReader:IBitStreamReader
    {
        private Byte[] file;
        private int byteCounter = 0;
        private int bitCounter = 0; 

        public TestBitStreamReader(String input)
        {
            file = Encoding.ASCII.GetBytes(input);
        }

        public int Read()
        {
            if (byteCounter < file.Length)
            {
                var readByte = file[byteCounter];

                if (bitCounter == 7)
                {
                    byteCounter++;
                }

                if (bitCounter == 8)
                {
                    bitCounter = 0;
                }

                var byteString = Convert.ToString(readByte, 2).PadLeft(8,'0');
                bitCounter++;
                var result = Convert.ToInt32(byteString[bitCounter - 1].ToString());
                return result;  
            }

            return 0;
        }

        public bool EndOfStream()
        {
            return byteCounter >= file.Length;
        }

        public void Close()
        {
        }
    }
}
