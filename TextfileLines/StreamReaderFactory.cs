using System;

namespace TextfileLines
{
    public class StreamReaderFactory:IStreamReaderFactory
    {

        public IStreamReader Make(String path)
        {
            return new StreamReaderImpl(path);
        }

    }
}
