using IronSoftware.Drawing;
using IronQR;
namespace IronQR.Examples.Tutorial.CsharpQrWriting
{
    public static class Section10
    {
        public static void Run()
        {
            QrOptions options = new QrOptions
            {
                // Change QR code version to 40
                Version = 40,
            };
            
            // Create QR code
            QrCode qr = QrWriter.Write("1234", options);
            
            // Save QR code as a bitmap
            AnyBitmap qrImage = qr.Save();
            
            // Save QR code bitmap as file
            qrImage.SaveAs("qrImage.png");
        }
    }
}