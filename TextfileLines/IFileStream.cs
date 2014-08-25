using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextFileLines
{
    public interface IFileStream
    {
        String[][] GetOutput();
        String[] ReadLines();
        void WriteLines(String fileName,String[] lines);
    }
}
