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

            //String toCompDateiName = args[0];
            String toCompDateiName = "bild.bmp";
            //Bitmap orgImg = (Bitmap) Image.FromFile(@"C:\Users\mkaestl.IXTS\Projekte\Ausbildung\ausbildung\bild.bmp");
            Bitmap orgImg = (Bitmap)Image.FromFile(@"C:\Users\mkaestl.IXTS\Desktop\Desertx256.bmp");
            var ms = new MemoryStream();
            orgImg.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] orgImgBytes = ms.ToArray();
            var encImgBytes = rle.Encode(orgImgBytes);
            //Console.WriteLine(orgImgBytes.Length);
            //Console.WriteLine(encImgBytes.Length);
            var shrunkenprocent = 100 - (encImgBytes.Length/(orgImgBytes.Length/100));
            var shrunkenvalue = orgImgBytes.Length - encImgBytes.Length;
            Console.WriteLine("Datei " + toCompDateiName + " wurde Komprimiert - Kompressionsrate: " + shrunkenprocent + "%(" + shrunkenvalue + "bytes)");
            //Console.WriteLine("Datei " + toCompDateiName + " wurde Komprimiert - Kompressionsrate: " + shrunkenprocent + "%");;
            Console.ReadLine();
        }
    }
}
