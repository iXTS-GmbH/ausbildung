using System;

namespace TextfileLines
{
    public interface ITextFileMapper
    {
        void Map(String inputPath, String outputPath, IStreamFactory sTF = null);
        String Transform(String line);
    }
}
