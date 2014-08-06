using System;

namespace TextFileLines
{
    public interface ITextFileMapper
    {
        void Map(String inputFileName, String outputFileName, IStreamFactory streamFactory = null);
        String Transform(String line);
    }
}
