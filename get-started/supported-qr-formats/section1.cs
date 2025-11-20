using IronQr.Enum;
using IronQR;
namespace IronQR.Examples.GettingStarted.SupportedQrFormats
{
    public static class Section1
    {
        public static void Run()
        {
            // Generate a Micro QR code and save it as PNG
            QrCode myQr = QrWriter.Write(
                "Hello IronQR",
                new QrOptions { Encoding = QrEncoding.MicroQRCode }
            );
            
            myQr.Save().SaveAs("QR.png");
        }
    }
}