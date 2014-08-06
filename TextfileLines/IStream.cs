using System;

namespace TextfileLines
{
    public interface IStream
    {
        string ReadLine();
        void WriteLine(String line);
        void Close();
    }
}
