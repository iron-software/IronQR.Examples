using System.Collections.Generic;
using IronQR;
namespace IronQR.Examples.Tutorial.CsharpQrCodeGeneratorApplication
{
    public static class Section3
    {
        public static void Run()
        {
            IronQr.License.LicenseKey = "License-Key";
            
            var imageToScan = AnyBitmap.FromFile("QRCode.png");
            
            QrImageInput qrInput = new QrImageInput(imageToScan);
            
            QrReader qrScanner = new QrReader();
            
            IEnumerable<QrResult> scanResults = qrScanner.Read(qrInput);
            
            foreach (QrResult qrResult in scanResults)
            {
            
                Console.WriteLine(qrResult.Value);
            
                Console.WriteLine(qrResult.Url);
            
                foreach (IronSoftware.Drawing.PointF coordinate in qrResult.Points)
                {
                    Console.WriteLine($"{coordinate.X}, {coordinate.Y}");
                }
            }
        }
    }
}