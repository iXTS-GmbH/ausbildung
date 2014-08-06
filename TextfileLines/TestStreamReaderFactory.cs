using System;

namespace TextfileLines
{
    public class TestStreamReaderFactory:IStreamReaderFactory
    {

        public IStreamReader Make(String path)
        {
            return new TestStreamReader(path);
        }

    }
}
