using IronSoftware.Drawing;
using IronQR;
namespace IronQR.Examples.HowTo.CreateQrCodeImage
{
    public static class Section1
    {
        public static void Run()
        {
            // Creating a QR code
            QrCode qrCode = QrWriter.Write("12345");
            
            // Save QR code to AnyBitmap
            AnyBitmap anyBitmap = qrCode.Save();
            
            // Save AnyBitmap to PNG
            anyBitmap.SaveAs("simpleQrCode.png", AnyBitmap.ImageFormat.Png);
        }
    }
}