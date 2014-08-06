using System;

namespace TextfileLines
{
    public class StreamFactory:IStreamFactory
    {

        public IStream Make(String inputpath, String outputpath)
        {
            return new StreamImpl(inputpath, outputpath);
        }
    }
}
