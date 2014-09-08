using System;

namespace ixts.Ausbildung.NameService
{
    public class StreamFactory:IStreamFactory
    {
        public IStream Make(String fileName)
        {
            return new StreamImpl(fileName);
        }
    }
}
