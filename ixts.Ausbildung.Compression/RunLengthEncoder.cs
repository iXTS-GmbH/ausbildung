using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.Compression
{
    public class RunLengthEncoder 
    {
        private const int MAX_COUNTER_VALUE = 255;
        private const int MIN_TO_COMPRESS_VALUE = 3;
        private Byte marker;
        private List<Byte> lastBytes;
        private int currentPosition;

        public void Marker(char newmarker)
        {
            marker = Convert.ToByte(newmarker);
        }
        
        public Byte[] Encode(Byte[] bytes,int checkRange)
        {
            if (bytes != null)
            {
                var buffer = new List<Byte>();

                while (currentPosition < bytes.Length)
                {
                    var nextgroup = GetNextGroup(bytes, checkRange);
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

        public List<Byte> GetNextGroup(Byte[] bytes, int checkRange)
        {
            var group = new List<Byte> ();
            for (var i = currentPosition; i < bytes.Length; i = i + checkRange)
            {
                var nextGroup = new List<Byte>();
                    for (int j = 0; j < checkRange; j++)
                    {
                        if (bytes.Length - 1 >= i+j)
                        {
                            nextGroup.Add(bytes[i + j]);
                        }
                    }
                if (i == 0 || nextGroup.SequenceEqual(lastBytes))
                {
                    lastBytes = nextGroup;
                    if (group.Count/checkRange >= MAX_COUNTER_VALUE)
                    {
                        currentPosition = i;
                        return CompressGroup(group, checkRange);
                    }
                    for (int l = 0; l < nextGroup.Count; l++)
                    {
                        group.Add(nextGroup[l]);
                    }
                }
                else
                {
                    lastBytes = nextGroup;
                    currentPosition = i;
                    return CompressGroup(group, checkRange);
                }

            }
            currentPosition = bytes.Length;
            return CompressGroup(group,checkRange);
        }

        public List<Byte> CompressGroup(List<Byte> group, int checkRange)
        {
            if (group.Count/checkRange < MIN_TO_COMPRESS_VALUE && group[0] != marker)
            {
                return group;
            }

            var compressedGroup = new List<Byte> ();
            compressedGroup.Add(Convert.ToByte(marker));
            var count = group.Count/checkRange;
            compressedGroup.Add(Convert.ToByte(count));
            for (int i = 0; i < checkRange; i++)
            {
                compressedGroup.Add(group[i]);
            }
            return compressedGroup;
        }

        public Byte[] StringToByteArray(String str)
        {
            return Encoding.ASCII.GetBytes(str);
        }
    }
}
