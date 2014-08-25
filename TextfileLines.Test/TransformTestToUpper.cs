using System;

namespace TextFileLines.Test
{
    public class TransformTestToUpper : TextFileMapper
    {
        protected override String Transform(String line)
        {
            return line.ToUpper();
        }
    }
}
