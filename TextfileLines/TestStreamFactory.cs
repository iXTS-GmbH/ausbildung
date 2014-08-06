using System;

namespace TextFileLines
{
    public class TestStreamFactory:IStreamFactory
    {
        public IStream Make(String inputFileName, String outputFileName)
        {
            return new TestStream(inputFileName, outputFileName);
        }
    }
}
