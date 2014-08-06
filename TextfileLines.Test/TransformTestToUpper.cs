using System;

namespace TextFileLines.Test
{
    public class TransformTestToUpper : TextFileMapper
    {
        public override String Transform(String line)
        {
            return line.ToUpper();
        }
    }
}
