using System.Drawing;
using IronQR;
namespace IronQR.Examples.Tutorial.CsharpQrWriting
{
    public static class Section5
    {
        public static void Run()
        {
            // Create a QR code object
            QrCode qr = QrWriter.Write("hello world");
            
            // Save QR code as a bitmap
            Bitmap qrImage = qr.Save();
            
            // Save QR code bitmap as file
            qrImage.Save("qrBitmap.png");
        }
    }
}