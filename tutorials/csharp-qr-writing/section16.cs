using IronSoftware.Drawing;
using IronQR;
namespace IronQR.Examples.Tutorial.CsharpQrWriting
{
    public static class Section16
    {
        public static void Run()
        {
            // Load new logo image
            AnyBitmap logo = AnyBitmap.FromFile("sample.png");
            
            // Add new logo to QR code style options
            QrStyleOptions styleOptions = new QrStyleOptions()
            {
                Logo = new QrLogo(logo, 50, 50, 10),
            };
            
            string url = "https://ironsoftware.com/csharp/qr/";
            
            // Create QR code
            QrCode qr = QrWriter.Write(url);
            
            // Save QR code as a bitmap
            AnyBitmap qrImage = qr.Save(styleOptions);
            
            // Save QR code bitmap as file
            qrImage.SaveAs("qrURLColored.png");
        }
    }
}