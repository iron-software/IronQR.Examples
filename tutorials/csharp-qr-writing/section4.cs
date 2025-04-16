using IronSoftware.Drawing;
using IronQR;
namespace IronQR.Examples.Tutorial.CsharpQrWriting
{
    public static class Section4
    {
        public static void Run()
        {
            // Create a QR code object
            QrCode qr = QrWriter.Write("hello world");
            
            // Save QR code as a bitmap
            AnyBitmap qrImage = qr.Save();
            
            // Save QR code bitmap as file
            qrImage.SaveAs("qr.png");
        }
    }
}