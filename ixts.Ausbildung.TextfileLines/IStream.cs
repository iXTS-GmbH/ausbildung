using System;

namespace ixts.Ausbildung.TextfileLines
{
    public interface IStream
    {
        String ReadLine();
        void WriteLine(String line);
        void WriteLine(String targetPath, String line);
        void Close();
    }
}
