using System;

namespace TextFileLines
{
    public class TestFileStreamFactory:IFileStreamFactory
    {
        public IFileStream Make(String inputFileName)
        {
            return new TestFileStream(inputFileName);
        }
    }
}
