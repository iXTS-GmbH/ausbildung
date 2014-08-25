using System;

namespace TextFileLines
{
    public interface IFileStreamFactory
    {
        IFileStream Make(String inputFileName);
    }
}
