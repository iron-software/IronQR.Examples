using System.Collections.Generic;
using IronQR;
namespace ironqr.CsharpQrCodeGeneratorApplication
{
    public class Section1
    {
        public void Run()
        {
            IronQr.License.LicenseKey = "License-Key";
            
            // Load the image file that contains the QR Code
            var inputImage = AnyBitmap.FromFile("QRCode.png");
            
            // Prepare the image for QR code detection
            QrImageInput qrInput = new QrImageInput(inputImage);
            
            // Initialize the QR Code reader
            QrReader qrReader = new QrReader();
            
            // Execute QR Code reading on the provided image
            IEnumerable<QrResult> qrResults = qrReader.Read(qrInput);
            
            // Assuming you have the QR results in qrResults as before
            foreach (var result in qrResults)
            {
                Console.WriteLine(result.Value); // Print the QR code content to the console
            }
        }
    }
}