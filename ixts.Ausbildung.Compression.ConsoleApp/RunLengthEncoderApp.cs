using System;
using System.IO;

namespace ixts.Ausbildung.Compression.ConsoleApp
{
    class RunLengthEncoderApp
    {
        static void Main(string[] args)
        {
            var rle = new RunLengthEncoder();
            var rld = new RunLengthDecoder();
            if (args[0] != "-x"){
                var toCompFileName = args[0];
                var newDataName = args[1];
                var checkRange = 1;
                if (args.Length == 3)
                {
                    checkRange = Convert.ToInt32(args[2]);
                }
                var path = Path.GetFullPath(toCompFileName);
                var orgImgBytes = File.ReadAllBytes(@path);
                var encImgBytes = rle.Encode(orgImgBytes, checkRange);
                var shrunkenprocent = 100 - (Convert.ToDouble(encImgBytes.Length)/(Convert.ToDouble(orgImgBytes.Length)/100.0));
                Console.WriteLine("Datei {0} wurde Komprimiert - Kompressionsrate: {1}%", toCompFileName, Convert.ToInt64(shrunkenprocent));
                var newpath = Path.GetFullPath(newDataName);
                File.WriteAllBytes(newpath,encImgBytes);
                //Console.ReadKey();
            }
            else
            {
                var toDeCompFileName = args[1];
                var newDataName = args[2];
                var checkRange = 1;
                if (args.Length == 4)
                {
                    checkRange = Convert.ToInt32(args[3]);
                }
                var path = Path.GetFullPath(toDeCompFileName);
                var newpath = Path.GetFullPath(newDataName);
                var orgimgBytes = File.ReadAllBytes(@path);
                var decimgBytes = rld.Decode(orgimgBytes, checkRange);
                File.WriteAllBytes(newpath,decimgBytes);
                Console.WriteLine("Datei {0} wurde dekomprimiert", toDeCompFileName);
                //Console.ReadKey();
            }
        }
    }
}
