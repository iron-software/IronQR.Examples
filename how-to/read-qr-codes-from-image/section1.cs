using System;
using System.Collections.Generic;
using IronSoftware.Drawing;
using IronQr;
namespace IronQR.Examples.HowTo.ReadQrCodesFromImage
{
    public static class Section1
    {
        public static void Run()
        {
            // Load the image file into the application
            AnyBitmap inputImage = AnyBitmap.FromFile("path/to/your/image/file.webp");

            // Initialize a QrImageInput object with the loaded image
            QrImageInput qrImageInput = new QrImageInput(inputImage);

            // Execute QR code decoding on the provided image
            QrReader reader = new QrReader();
            IEnumerable<QrResult> results = reader.Read(qrImageInput);

            // Output the decoded QR code data
            foreach (QrResult result in results)
            {
                Console.WriteLine($"QR Code Data: {result.Value}");
            }
        }
    }
}
