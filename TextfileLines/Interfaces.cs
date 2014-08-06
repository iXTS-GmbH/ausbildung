using System;

namespace TextfileLines
{
    class Interfaces
    {
    }

    public interface ITextFileMapper
    {
        void Map(String inputPath, String outputPath, IStreamFactory sTF = null);
        String Transform(String line);
    }

    public interface IStreamFactory
    {
        IStream Make(String inputPath, String outputPath = null);
    }

    public interface IStream
    {
        string ReadLine();
        void WriteLine(String line);
        void Close();
    }
}
