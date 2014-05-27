﻿using System;
using System.Text;

namespace ixts.Ausbildung.Compression
{
    public class RunLengthEncoder
    {
        private char lastElement;
        private int point;

        public String Encode(String str)
        {
            var sBuilder = new StringBuilder();
            while(point < str.Length)
            {
                sBuilder.Append(GetNextGroup(str));
            }
            return sBuilder.ToString();
        }

        public String GetNextGroup(String str)
        {
            var group = new StringBuilder();
            for (var i = point; i < str.Length; i++)
            {
                if (str[i] == lastElement || i == 0)
                {
                    if (group.Length == 9)
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
            if (group.Length < 3)
            {
                return group;
            }
            else
            {
                var compressedGroup = new StringBuilder();
                compressedGroup.Append("-");
                compressedGroup.Append(group.Length);
                compressedGroup.Append(group[0]);
                return compressedGroup.ToString();
            }
        }


    }
}
