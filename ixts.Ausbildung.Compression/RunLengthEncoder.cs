using System;
using System.Collections.Generic;
using System.Text;

namespace ixts.Ausbildung.Compression
{
    public class RunLengthEncoder
    {
        private const int MAXCOUNTERVALUE = 9;
        private const int MAXBYTEVALUE = 255;
        private const int MINTOCOMPRESSVALUE = 3;
        private char marker = '-';
        private char lastElement;
        private Byte lastByte;
        private int point;

        public String Encode(String str)
        {
            if (str != null)
            {
                var sBuilder = new StringBuilder();
                while (point < str.Length)
                {
                    sBuilder.Append(GetNextGroup(str));
                }
                point = 0;
                return sBuilder.ToString();
            }
            else
            {
                str = "";
                return str;
            }
        }

        public String GetNextGroup(String str)
        {
            var group = new StringBuilder();
            for (var i = point; i < str.Length; i++)
            {
                if (str[i] == lastElement || i == 0)
                {
                    if (group.Length == MAXCOUNTERVALUE)
                    {
                        point = i;
                        return CompressGroup(group.ToString());
                    }
                    lastElement = str[i];
                    group.Append(str[i]);
                }
                else
                {
                    lastElement = str[i];
                    point = i;
                    return CompressGroup(group.ToString());

                }
            }
            point = str.Length;
            return CompressGroup(group.ToString());
        }

        public String CompressGroup(String group)
        {
            if (group.Length < MINTOCOMPRESSVALUE && group[0] != marker)
            {
                return group;
            }
            else
            {
                var compressedGroup = new StringBuilder();
                compressedGroup.Append(marker);
                compressedGroup.Append(group.Length);
                compressedGroup.Append(group[0]);
                return compressedGroup.ToString();
            }
        }

        public void Marker(char newmarker)
        {
            marker = newmarker;
        }

        public Byte[] DataEncode(Byte[] bA)
        {
            if (bA != null)
            {
                var bl = new List<Byte>();
                    Byte[] nextgroup = GetNextByteGroup(bA);
                    for (int i = 0; i < nextgroup.Length; i++)
                    {
                        bl.Add(nextgroup[i]);
                    }
                return bl.ToArray();
            }
            else
            {
                return bA;
            }
        }

        public Byte[] GetNextByteGroup(Byte[] bA)
        {
            var group = new List<Byte>{};
            for (var i = point; i < bA.Length; i++)
            {
                if (bA[i] == lastByte || i == 0)
                {
                    if (group.Count == MAXBYTEVALUE)
                    {
                        point = i;
                        return group.ToArray();
                    }
                    lastByte = bA[i];
                    group.Add(bA[i]);
                }
                else
                {
                    lastByte = bA[i];
                    point = i;
                    return group.ToArray();
                }
            }
            point = bA.Length;
            return group.ToArray();
        }

        public Byte[] CompByteGroup(Byte[] group)
        {
            if (group.Length < MINTOCOMPRESSVALUE && group[0] != 0)
            {
                return group;
            }
            else
            {
                var compressedGroup = new List<Byte>{};
                compressedGroup.Add(Convert.ToByte(0));
                var length = new byte();
                compressedGroup.Add(Convert.ToByte(group.Length));
                compressedGroup.Add(group[0]);
                return compressedGroup.ToArray();
            }

        }

    }
}
