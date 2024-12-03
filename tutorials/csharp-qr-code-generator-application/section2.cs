using System.Collections.Generic;
using IronQR;
namespace ironqr.CsharpQrCodeGeneratorApplication
{
    public class Section2
    {
        public void Run()
        {
            IronQr.License.LicenseKey = "License-Key";
            
            // Load the image file that contains the QR Code
            var inputImage = AnyBitmap.FromFile("QRCode.png");
            
            QrImageInput mixedScanInput = new QrImageInput(inputImage, QrScanMode.OnlyDetectionModel);
            IEnumerable<QrResult> mixedScanResults = new QrReader().Read(mixedScanInput);
            
            QrImageInput mlScanInput = new QrImageInput(inputImage, QrScanMode.OnlyDetectionModel);
            IEnumerable<QrResult> mlScanResults = new QrReader().Read(mlScanInput);
            
            QrImageInput basicScanInput = new QrImageInput(inputImage, QrScanMode.OnlyBasicScan);
            IEnumerable<QrResult> basicScanResults = new QrReader().Read(basicScanInput);
        }
    }
}