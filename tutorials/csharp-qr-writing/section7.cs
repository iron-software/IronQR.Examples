using System.Collections.Generic;
using IronQR;
namespace IronQR.Examples.Tutorial.CsharpQrWriting
{
    public static class Section7
    {
        public static void Run()
        {
            // Create a QR code object
            QrCode qr = QrWriter.Write("hello world");
            
            string filepath = "example.pdf";
            int x = 100;
            int y = 150;
            List<int> pages = new List<int>();
            pages.Add(1);
            pages.Add(2);
            pages.Add(3);
            pages.Add(4);
            
            // Stamp QR code to (100, 150) of the pdf on pages 1-4
            qr.StampToExistingPdfPages(filepath, x, y, pages);
        }
    }
}