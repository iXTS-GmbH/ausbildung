using System;

namespace TextFileLines
{
    public class TestFileStreamFactory:IFileStreamFactory
    {
        public IFileStream Make(String sourcePath)
        {
            return new TestFileStream(sourcePath);
        }
    }
}
