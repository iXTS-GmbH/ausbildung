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
            Bitmap orgImg = (Bitmap) Image.FromFile(@"C:\Users\mkaestl.IXTS\Projekte\Ausbildung\ausbildung\bild.png");

            var ms = new MemoryStream();
            orgImg.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] orgImgBytes = ms.ToArray();
            var encImgBytes = rle.Encode(orgImgBytes);
            //Console.WriteLine(orgImgBytes.Length);
            //Console.WriteLine(encImgBytes.Length);
            //Console.WriteLine("Datei" + toCompDateiName + "wurde Komprimiert");
            Console.ReadLine();
        }
    }
}
