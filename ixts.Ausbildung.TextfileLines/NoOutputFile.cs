using System;

namespace ixts.Ausbildung.TextfileLines
{
    public class NoOutputFile : TextFileMapper
    {
        protected override string Transform(String line)
        {
            return line;
        }
    }
}
