using System;

namespace TextFileLines
{
    public class StreamFactory:IStreamFactory
    {
        public IStream Make(String sourcePath, String targetPath)
        {
            return new StreamImpl(sourcePath, targetPath);
        }
    }
}
