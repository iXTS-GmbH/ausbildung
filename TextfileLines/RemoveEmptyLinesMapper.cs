﻿using System;

namespace TextFileLines
{
    public class RemoveEmptyLinesMapper:TextFileMapper
    {
        protected override String Transform(String line)
        {
            return !String.IsNullOrEmpty(line) ? line : null;
            //Bedeutung *
        }
    }
}
//*
//if (!String.IsNullOrEmpty(line))
//    {
//        return line;
//    }
//return null;