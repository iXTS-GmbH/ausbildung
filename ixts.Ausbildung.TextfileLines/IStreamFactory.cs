using System;

namespace ixts.Ausbildung.TextfileLines
{
    public interface IStreamFactory
    {
        IStream Make(String sourcePath, String targetPath = null);
    }
}
