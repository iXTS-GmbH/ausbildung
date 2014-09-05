﻿using System;
using System.IO;

namespace TextFileLines
{
    public class StreamImpl:IStream
    {
        private readonly StreamReader reader;
        private readonly StreamWriter writer;
        private readonly String outputFile;

        public StreamImpl(String sourcePath, String targetPath = null)
        {
            reader = new StreamReader(sourcePath);
            outputFile = targetPath;

            if (targetPath != null)
            {
                writer = new StreamWriter(targetPath);
            }

        }

        public string ReadLine()
        {
            return reader.ReadLine();
        }

        public string[][] GetOutput()
        {
            return null;//Ist im Testzweig dazu da die gesplitteten Files zu bekommen hat hier aber keine Verwendung
        }

        public void WriteLine(String line)
        {
            if (outputFile != null)
            {
                writer.WriteLine(line);
            }
            else
            {
                throw new ArgumentException("Kein OutPutFile angegeben");
            }
        }

        public void WriteLine(string targetPath, string line)
        {
            var fileWriter = new StreamWriter(targetPath);
            fileWriter.WriteLine(line);
        }


        public void Close()
        {
            reader.Close();
            writer.Close();//Wichtig ohne Close werden die geschriebenen Zeilen nicht in der Datei gespeichert
        }
    }
}
