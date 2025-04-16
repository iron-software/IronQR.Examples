using IronSoftware.Drawing;
using IronQR;
namespace IronQR.Examples.Tutorial.CsharpQrWriting
{
    public static class Section14
    {
        public static void Run()
        {
            QrStyleOptions styleOptions = new QrStyleOptions()
            {
                // Change margins
                MarginBottom = 30,
                MarginTop = 100,
                MarginRight = 40,
                MarginLeft = 20,
            };
            
            string url = "https://ironsoftware.com/csharp/qr/";
            
            // Create QR code
            QrCode qr = QrWriter.Write(url);
            
            // Save QR code as a bitmap
            AnyBitmap qrImage = qr.Save(styleOptions);
            
            // Save QR code bitmap as file
            qrImage.SaveAs("qrURLMarginMultiple.png");
        }
    }
}