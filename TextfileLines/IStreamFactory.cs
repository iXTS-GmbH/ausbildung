using System;

namespace TextfileLines
{
    public interface IStreamFactory
    {
        IStream Make(String inputPath, String outputPath = null);
    }
}
