using System;

namespace ixts.Ausbildung.NameService
{
    public interface IStreamFactory
    {
        IStream Make(String fileName);
    }
}
