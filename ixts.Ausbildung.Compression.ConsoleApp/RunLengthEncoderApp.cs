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

            //String toCompDataName = args[0];
            //String newDataName = args[1];
            String toCompDataName = "Desertx256.bmp";
            String newDataName = "Desertx256.rle";
            String path = Path.GetFullPath(toCompDataName);

            Bitmap orgImg = (Bitmap)Image.FromFile(@path);
            var ms = new MemoryStream();
            orgImg.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] orgImgBytes = ms.ToArray();
            var encImgBytes = rle.Encode(orgImgBytes);
            var shrunkenprocent = 100 - (encImgBytes.Length/(orgImgBytes.Length/100));
            var shrunkenvalue = orgImgBytes.Length - encImgBytes.Length;
            Console.WriteLine("Datei " + toCompDataName + " wurde Komprimiert - Kompressionsrate: " + shrunkenprocent + "%(" + shrunkenvalue + "bytes)");
            //Console.WriteLine("Datei " + toCompDataName + " wurde Komprimiert - Kompressionsrate: " + shrunkenprocent + "%");
            String newpath = Path.GetFullPath(newDataName);
            var bw = new BinaryWriter(File.Open(@newpath, FileMode.OpenOrCreate));
            bw.Write(encImgBytes);
            bw.Flush();
            bw.Close();
            Console.ReadLine();
        }
    }
}
