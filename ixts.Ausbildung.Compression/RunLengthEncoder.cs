using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ixts.Ausbildung.Compression
{
    public class RunLengthEncoder
    {
        private const int MAX_COUNTER_VALUE = 255;
        private const int MIN_TO_COMPRESS_VALUE = 3;
        private Byte marker;
        private Byte lastByte;
        private int currentPosition;

        public void Marker(char newmarker)
        {
            marker = Convert.ToByte(newmarker);
        }

        public Byte[] Encode(Byte[] bytes)
        {
            if (bytes != null)
            {
                var buffer = new List<Byte>();

                while (currentPosition < bytes.Length)
                {
                    var nextgroup = GetNextGroup(bytes);

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

        public List<Byte> GetNextGroup(Byte[] bytes)
        {
            var group = new List<Byte> ();
            for (var i = currentPosition; i < bytes.Length; i++)
            {
                if (bytes[i] == lastByte || i == 0)
                {
                    if (group.Count == MAX_COUNTER_VALUE)
                    {
                        currentPosition = i;
                        return CompressGroup(group);
                    }
                    lastByte = bytes[i];
                    group.Add(bytes[i]);
                }
                else
                {
                    lastByte = bytes[i];
                    currentPosition = i;
                    return CompressGroup(group);
                }
            }
            currentPosition = bytes.Length;
            return CompressGroup(group);
        }

        public List<Byte> CompressGroup(List<Byte> group)
        {
            if (group.Count < MIN_TO_COMPRESS_VALUE && group[0] != marker)
            {
                return group;
            }

            var compressedGroup = new List<Byte> ();
            compressedGroup.Add(Convert.ToByte(marker));
            compressedGroup.Add(Convert.ToByte(group.Count));
            compressedGroup.Add(group[0]);

            return compressedGroup;
        }

        public Byte[] StringToByteArray(String str)
        {
            return Encoding.ASCII.GetBytes(str);
        }
    }
}
