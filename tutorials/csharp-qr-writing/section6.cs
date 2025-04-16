using IronQr;
using IronQR;
namespace IronQR.Examples.Tutorial.CsharpQrWriting
{
    public static class Section6
    {
        public static void Run()
        {
            // Create a QR code object
            QrCode qr = QrWriter.Write("hello world");
            
            string filepath = "example.pdf";
            int x = 100;
            int y = 150;
            int page = 1;
            
            // Stamp QR code to (100, 150) of the pdf on page 1
            qr.StampToExistingPdfPage(filepath, x, y, page);
        }
    }
}