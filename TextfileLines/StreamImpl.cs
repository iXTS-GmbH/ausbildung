using System;
using System.IO;

namespace TextFileLines
{
    public class StreamImpl:IStream
    {
        private readonly StreamReader reader;
        private readonly StreamWriter writer;
        private readonly String fileName;

        public StreamImpl(String inputFileName, String outputFileName = null)
        {
            reader = new StreamReader(inputFileName);
            fileName = outputFileName;

            if (outputFileName != null)
            {
                writer = new StreamWriter(outputFileName);
            }

        }

        public string ReadLine()
        {
            return reader.ReadLine();
        }

        public void WriteLine(String line)
        {
            if (fileName != null)
            {
                writer.WriteLine(line);
            }
            else
            {
                throw new ArgumentException("Kein OutPutFile angegeben");
            }
        }


        public void Close()
        {
            reader.Close();
            writer.Close();//Wichtig ohne Close werden die geschriebenen Zeilen nicht in der Datei gespeichert
        }
    }
}
