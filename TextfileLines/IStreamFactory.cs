using System;

namespace TextFileLines
{
    public interface IStreamFactory
    {
        IStream Make(String inputFileName, String outputFileName = null);
    }
}
