using System;

namespace TextfileLines
{
    public abstract class TextfileMapper:ITextFileMapper
    {

        public void Map(String inputPath, String outputPath, IStreamFactory str = null)
        {
            str = str ?? new StreamFactory();
            var file = str.Make(inputPath, outputPath);
            var tfL = new TextfileLines(inputPath, str);

            foreach (var line in tfL)
            {
                var transline = Transform(line);

                if (transline != null)
                {
                    file.WriteLine(transline);
                }
            }

            file.Close();
        }

        public abstract String Transform(String line);
    }
}

//Was ich bis jetzt kann:
//Eine Datei anhand ihres Pfades einlesen und zum durchiterieren anbieten
//Woran ich gerade arbeite bis zum ende des Tages zu können:
//Eine Datei mit einer implementierung einer abstrakten klasse abzuändern und in zieldatei zu speichern
