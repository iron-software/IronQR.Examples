using IronSoftware.Drawing;
using IronQR;
namespace IronQR.Examples.Tutorial.CsharpQrWriting
{
    public static class Section12
    {
        public static void Run()
        {
            QrStyleOptions styleOptions = new QrStyleOptions()
            {
                // Change the dimensions to 600px
                Dimensions = 600,
            };
            
            string url = "https://ironsoftware.com/csharp/qr/";
            
            // Create QR code
            QrCode qr = QrWriter.Write(url);
            
            // Save QR code as a bitmap
            AnyBitmap qrImage = qr.Save(styleOptions);
            
            // Save QR code bitmap as file
            qrImage.SaveAs("qrURLResized.png");
        }
    }
}