using System;
namespace TextFileLines
{
    public class DeleteEmptyLines : TextFileMapper
    {
        protected override String Transform(String line)
        {
            return String.IsNullOrEmpty(line) ? null : line;
            //Bedeutung *
            //Quelle: Aufgabenstellung Beispiel
        }
    }
}

//*
//if (String.IsNullOrEmpty(line))
//{
//    return null;
//}
//return line;