using System.Text;
using IronQR;
namespace IronQR.Examples.Tutorial.CsharpQrWriting
{
    public static class Section3
    {
        public static void Run()
        {
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/qr/"));
            
            // Create QR code
            QrCode streamQr = QrWriter.Write(stream);
            
            // Save QR code as a bitmap
            AnyBitmap streamQrImage = streamQr.Save();
            
            // Save QR code bitmap as file
            streamQrImage.SaveAs("streamQr.png");
        }
    }
}