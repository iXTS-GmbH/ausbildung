using System;

namespace TextFileLines
{
    public class StreamFactory:IStreamFactory
    {
        public IStream Make(String inputFileName, String outputFileName)
        {
            return new StreamImpl(inputFileName, outputFileName);
        }
    }
}
