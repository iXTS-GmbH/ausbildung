﻿using System;

namespace TextfileLines
{
    public abstract class TextfileMapper:ITextFileMapper
    {

        public void Map(String inputPath, String outputPath, IStreamFactory sTF = null)
        {
            sTF = sTF ?? new StreamFactory();
            var file = sTF.Make(inputPath, outputPath);

            for (var line = file.ReadLine(); line != null; line = file.ReadLine())
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