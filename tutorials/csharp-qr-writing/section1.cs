using IronSoftware.Drawing;
using IronQR;
namespace IronQR.Examples.Tutorial.CsharpQrWriting
{
    public static class Section1
    {
        public static void Run()
        {
            string text = "Hello, World!";
            string url = "https://ironsoftware.com/csharp/qr/";
            string alphanumeric = "WATERSKU-12356";
            
            // Create QR code
            QrCode textQr = QrWriter.Write(text);
            // Save QR code as a bitmap
            AnyBitmap textQrImage = textQr.Save();
            // Save QR code as file
            textQrImage.SaveAs("textQr.png");
            
            QrCode urlQr = QrWriter.Write(url);
            AnyBitmap urlQrImage = urlQr.Save();
            urlQrImage.SaveAs("urlQr.png");
            
            QrCode alphanumericQr = QrWriter.Write(alphanumeric);
            AnyBitmap alphanumericQrImage = alphanumericQr.Save();
            alphanumericQrImage.SaveAs("alphanumericQr.png");
        }
    }
}