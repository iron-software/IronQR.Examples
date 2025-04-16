using IronSoftware.Drawing;
using IronQR;
namespace IronQR.Examples.Tutorial.CsharpQrWriting
{
    public static class Section11
    {
        public static void Run()
        {
            QrOptions options = new QrOptions
            {
                // Change character encoding to UTF-32
                CharacterEncoding = "UTF-32"
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