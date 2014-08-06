using System;

namespace TextFileLines
{
    public interface IStream
    {
        string ReadLine();
        void WriteLine(String line);
        void Close();
    }
}
