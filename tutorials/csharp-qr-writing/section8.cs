using IronSoftware.Drawing;
using IronQR;
namespace IronQR.Examples.Tutorial.CsharpQrWriting
{
    public static class Section8
    {
        public static void Run()
        {
            QrOptions options = new QrOptions
            {
                // Change encoding to micro QR code
                Encoding = IronQr.Enum.QrEncoding.MicroQRCode,
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