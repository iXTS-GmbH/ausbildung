using System;

namespace TextFileLines.Test
{
    public class TransformTestDeleteEmptyLines : TextFileMapper
    {
        public override String Transform(String line)
        {
            return String.IsNullOrEmpty(line) ? null : line;
            //Bedeutung *
            //Quelle Aufgabenstellung Beispiel
        }
    }
}

//*
//if (String.IsNullOrEmpty(line))
//{
//    return null;
//}
//return line;