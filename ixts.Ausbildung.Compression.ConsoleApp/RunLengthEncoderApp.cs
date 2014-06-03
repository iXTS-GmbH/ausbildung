using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ixts.Ausbildung.Compression.ConsoleApp
{
    class RunLengthEncoderApp
    {
        static void Main(string[] args)
        {
            var rle = new RunLengthEncoder();
            var rld = new RunLengthDecoder();
            if (args[0] != "-x"){
                var toCompDataName = args[0];
                String newDataName = args[1];
                String path = Path.GetFullPath(toCompDataName);
                Bitmap orgImg = (Bitmap)Image.FromFile(@path);
                var ms = new MemoryStream();
                orgImg.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                var orgImgBytes = ms.ToArray();
                var encImgBytes = rle.Encode(orgImgBytes);
                var shrunkenprocent = 100 - (encImgBytes.Length/(orgImgBytes.Length/100));
                var shrunkenvalue = orgImgBytes.Length - encImgBytes.Length;
                Console.WriteLine("Datei " + toCompDataName + " wurde Komprimiert - Kompressionsrate: " + shrunkenprocent + "%(" + shrunkenvalue + "bytes)");
                var newpath = Path.GetFullPath(newDataName);
                File.WriteAllBytes(newpath,encImgBytes);
                Console.ReadKey();
            }
            else
            {
                String toDeCompDataName = args[1];
                String newDataName = args[2];
                String path = Path.GetFullPath(toDeCompDataName);
                String newpath = Path.GetFullPath(newDataName);
                var orgimgBytes = File.ReadAllBytes(@path);
                var decimgBytes = rld.Decode(orgimgBytes);
                File.WriteAllBytes(newpath,decimgBytes);
                Console.WriteLine("Datei " + toDeCompDataName + " dekomprimiert");
                Console.ReadKey();
            }
        }
    }
}
