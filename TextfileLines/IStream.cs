﻿using System;

namespace TextFileLines
{
    public interface IStream
    {
        String ReadLine();
        String[][] GetOutput();
        void WriteLine(String line);
        void WriteLine(String targetPath, String line);
        void Close();
    }
}
