using System;
using System.IO;

namespace ixts.Ausbildung.I_O_Filter
{
    public class ReverseInputStream:StreamReader
    {
        private Byte[] image = new Byte[0];
        private int remaining = 0;

        public ReverseInputStream(Stream input):base(input)
        {
            var a = input.Length - input.Position;
            while (a > 0)
            {
                Array.Copy(image, image, remaining + a);
                remaining += input.Read(image, remaining, (int)a);
                a = input.Length - input.Position;
            }
        }

        public override int Read()
        {
            if (remaining == 0)
            {
                return -1;
            }
            remaining--;
            return image[remaining];
        }

        public override int Read(char[] buffer, int index, int count)
        {
            if (remaining == 0)
            {
                return -1;
            }
            if (remaining < count)
            {
                count = remaining;
            }
            for (int i = index; i < index+count; i++)
            {
                buffer[i] = (char)Read();
            }
            return count;
        }
    }
}
