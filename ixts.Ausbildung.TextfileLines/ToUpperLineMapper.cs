using System;

namespace ixts.Ausbildung.TextfileLines
{
    public class ToUpperLineMapper : TextFileMapper
    {
        protected override String Transform(String line)
        {
            return line.ToUpper();
        }
    }
}
