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

        public Byte[] Encode(Byte[] bA)
        {
            if (bA != null)
            {
                var bl = new List<Byte>();
                while (currentPosition < bA.Length)
                {
                    Byte[] nextgroup = GetNextGroup(bA);
                    for (int i = 0; i < nextgroup.Length; i++)
                    {
                        bl.Add(nextgroup[i]);
                    }
                }
                currentPosition = 0;
                return bl.ToArray();
            }
            else
            {
                return null;
            }
        }

        public Byte[] GetNextGroup(Byte[] bA)
        {
            var group = new List<Byte> {};
            for (var i = currentPosition; i < bA.Length; i++)
            {
                if (bA[i] == lastByte || i == 0)
                {
                    if (group.Count == MAX_COUNTER_VALUE)
                    {
                        currentPosition = i;
                        return CompressGroup(group.ToArray());
                    }
                    lastByte = bA[i];
                    group.Add(bA[i]);
                }
                else
                {
                    lastByte = bA[i];
                    currentPosition = i;
                    return CompressGroup(group.ToArray());
                }
            }
            currentPosition = bA.Length;
            return CompressGroup(group.ToArray());
        }

        public Byte[] CompressGroup(Byte[] group)
        {
            if (group.Length < MIN_TO_COMPRESS_VALUE && group[0] != marker)
            {
                return group;
            }
            else
            {
                var compressedGroup = new List<Byte> {};
                compressedGroup.Add(Convert.ToByte(marker));
                compressedGroup.Add(Convert.ToByte(group.Length));
                compressedGroup.Add(group[0]);
                return compressedGroup.ToArray();
            }
        }

        public Byte[] StringToByteArray(String str)
        {
            var bA = new List<Byte> {};
            for (int i = 0; i < str.Length; i++)
            {
               bA.Add(Convert.ToByte(str[i])); 
            }
            return bA.ToArray();
        }

        public Byte[] Decode(Byte[] bA)
        {
            if (bA != null)
            {
                var bL = new List<Byte> {};
                while (currentPosition < bA.Length)
                {
                    Byte[] nextgroup = GetNextDeCodeGroup(bA);
                    for (int i = 0; i < nextgroup.Length; i++)
                    {
                        bL.Add(nextgroup[i]);
                    }
                }
                currentPosition = 0;
                return bL.ToArray();
            }
            else
            {
                return null;
            }
        }

        public Byte[] GetNextDeCodeGroup(Byte[] bA)
        {
            return null;
        }
    }
}
