using System;

namespace ixts.Ausbildung.TextfileLines
{
    public class ToLowerLineMapper : TextFileMapper
    {
        protected override String Transform(String line)
        {
            return line.ToLower();
        }
    }
}
