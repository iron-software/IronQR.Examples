using System.Text;
using IronQR;
namespace IronQR.Examples.Tutorial.CsharpQrWriting
{
    public static class Section2
    {
        public static void Run()
        {
            byte[] bytes = Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/qr/");
            
            // Create QR code
            QrCode bytesQr = QrWriter.Write(bytes);
            
            // Save QR code as a bitmap
            AnyBitmap qrImage = bytesQr.Save();
            
            // Save QR code bitmap to file
            qrImage.SaveAs("bytesQr.png");
        }
    }
}