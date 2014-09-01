using System;

namespace TextFileLines
{
    public interface IFileStream
    {
        String[][] GetOutput();
        String[] ReadLines();
        void WriteLines(String fileName,String[] lines);
    }
}
