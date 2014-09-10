using System;

namespace ixts.Ausbildung.NameService.Test
{
    public class TestStreamFactory:IStreamFactory
    {
        public IStream Make(String fileName)
        {
            return new TestStream();
        }
    }
}
