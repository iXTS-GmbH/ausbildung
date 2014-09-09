using System;

namespace ixts.Ausbildung.TextfileLines.Test
{
    public class ToUpperLineMapper : TextFileMapper
    {
        protected override String Transform(String line)
        {
            return line.ToUpper();
        }
    }
}
