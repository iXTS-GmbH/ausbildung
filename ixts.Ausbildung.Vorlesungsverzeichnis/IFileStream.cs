using System;

namespace ixts.Ausbildung.Vorlesungsverzeichnis
{
    public interface IFileStream
    {
        String[] ReadAllLines(String path);
    }
}
