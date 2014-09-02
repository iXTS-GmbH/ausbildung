using System;

namespace TextFileLines
{
    public class TestStreamFactory:IStreamFactory
    {
        public IStream Make(String sourcePath, String targetPath = null)
        {
            return new TestStream(sourcePath, targetPath);
        }
    }
}
