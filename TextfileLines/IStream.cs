using System;

namespace TextFileLines
{
    public interface IStream
    {
        String ReadLine();
        String[][] GetOutput();
        void WriteLine(String line);
        void WriteLines(String targetPath, String[] lines);
        void Close();
    }
}
