using System;
using System.Collections.Generic;
using System.IO;
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

        public Byte[] Decode(Byte[] bytes, int checkRange)
        {
            if (bytes != null)
                {
                var buffer = new List<Byte>();
                while (currentPosition < bytes.Length)
                {
                    var nextgroup = GetNextDeCompGroup(bytes, checkRange);
                    var Breakpoint = 0;
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

        public List<Byte> GetNextDeCompGroup(Byte[] bytes, int checkRange)
        {
            var group = new List<Byte> ();
            if (bytes[currentPosition] == marker) 
            {
                for (int i = 0; i < checkRange + 2; i++)
                {
                   group.Add(bytes[currentPosition + i]); 
                }
                currentPosition = currentPosition + 2 + checkRange;
                return DeCompressGroup(group, checkRange);

            }
            for (int i = 0; i < checkRange; i++)
                {
                if (bytes.Length - 1 >= currentPosition + i){
                    group.Add(bytes[currentPosition + i]);
                }
            }
            
            currentPosition = currentPosition + checkRange;
            return DeCompressGroup(group, checkRange);
        }

        public List<Byte> DeCompressGroup(List<Byte> group, int checkRange)
        {
            if (group.Count == 2 + checkRange)
            {
                var count = Convert.ToInt16(group[1]);
                var buffer = new List<Byte> ();
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < checkRange; j++)
                    {
                        buffer.Add(group[2+j]);
                    }
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
