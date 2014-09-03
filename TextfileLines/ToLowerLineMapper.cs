using System;

namespace TextFileLines
{
    public class ToLowerLineMapper : TextFileMapper
    {
        protected override String Transform(String line)
        {
            return line.ToLower();
        }
    }
}
