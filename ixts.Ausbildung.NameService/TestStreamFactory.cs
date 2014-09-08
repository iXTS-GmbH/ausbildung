using System;

namespace ixts.Ausbildung.NameService
{
    public class TestStreamFactory:IStreamFactory
    {
        public IStream Make(String fileName)
        {
            return new TestStream();
        }
    }
}
