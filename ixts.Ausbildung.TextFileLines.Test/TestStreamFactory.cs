using System;

namespace ixts.Ausbildung.TextfileLines.Test
{
    public class TestStreamFactory:IStreamFactory
    {
        public IStream Make(String sourcePath, String targetPath = null)
        {
            return new TestStream(sourcePath, targetPath);
        }
    }
}
