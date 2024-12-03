using IronSoftware.Drawing;
using IronQR;
namespace ironqr.Quickstart
{
    public class Section1
    {
        public void Run()
        {
            // Create a QR Code object
            QrCode myQr = QrWriter.Write("hello world");
            
            // Save QR Code as a Bitmap
            AnyBitmap qrImage = myQr.Save();
            
            // Save QR Code Bitmap as File
            qrImage.SaveAs("qr.png");
        }
    }
}