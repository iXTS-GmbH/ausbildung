using System;

namespace TextFileLines
{
    public class ToUpperLine : TextFileMapper
    {
        protected override String Transform(String line)
        {
            return line.ToUpper();
        }
    }
}
