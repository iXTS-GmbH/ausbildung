using System;

namespace TextFileLines
{
    public interface IStreamFactory
    {
        IStream Make(String sourcePath, String targetPath = null);
    }
}
