using IronSoftware.Drawing;
using IronQR;
namespace IronQR.Examples.Tutorial.CsharpQrWriting
{
    public static class Section15
    {
        public static void Run()
        {
            QrStyleOptions styleOptions = new QrStyleOptions()
            {
                // Change color
                BackgroundColor = Color.Blue,
                Color = Color.Red
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