using System;

namespace ixts.Ausbildung.NameService
{
    public interface IConsole
    {
        String Readline();
        void WriteLine(String line);
    }
}
