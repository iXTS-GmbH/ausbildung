using System;

namespace ixts.Ausbildung.Vorlesungsverzeichnis.Test
{
    public class TestFileStream:IFileStream
    {
        public string[] ReadAllLines(String path)
        {
            return new []
                {
                    "IFB2:Softwareentwicklung II:Schiedermeier",
                    "IFS2:Softwareentwicklung II:Köhler",
                    "IFB4:Compilerbau:Schiedermeier",
                    "IFB4:Datenbanken:Bayer"
                };
        }
    }
}
