using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.Compression
{
    public class RunLengthDecoder
    {
        private Byte marker;
        private int currentPosition;

        public void Marker(char newmarker)
        {
            marker = Convert.ToByte(newmarker);
        }

        public Byte[] Decode(Byte[] bytes)
        {
            if (bytes != null)
            {
                var buffer = new List<Byte>();
                while (currentPosition < bytes.Length)
                {
                    var nextgroup = GetNextDeCompGroup(bytes);
                    for (int i = 0; i < nextgroup.Count; i++)
                    {
                        buffer.Add(nextgroup[i]);
                    }
                }
                currentPosition = 0;
                return buffer.ToArray();
            }
            return null;
        }

        public List<Byte> GetNextDeCompGroup(Byte[] bA)
        {
            var group = new List<Byte> ();
            if (bA[currentPosition] == marker)
            {
                group.Add(bA[currentPosition]);
                group.Add(bA[currentPosition + 1]);
                group.Add(bA[currentPosition + 2]);
                currentPosition = currentPosition + 3;
                return DeCompressGroup(group);

            }
            group.Add(bA[currentPosition]);
            currentPosition++;
            return DeCompressGroup(group);
        }

        public List<Byte> DeCompressGroup(List<Byte> group)
        {
            if (group.Count == 3)
            {
                var count = Convert.ToInt16(group[1]);
                var buffer = new List<Byte> ();
                for (int i = 0; i < count; i++)
                {
                    buffer.Add(group[2]);
                }
                return buffer;
            }
            return group;
        }

        public Byte[] StringToByteArray(String str)
        {
            return Encoding.ASCII.GetBytes(str);
        }
    }
}
