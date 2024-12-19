using IronQr;
using IronSoftware.Drawing;
using Color = IronSoftware.Drawing.Color;

// Set QR options
QrOptions options = new QrOptions(IronQr.QrErrorCorrectionLevel.High, 20);

// Create a QR Code object
QrCode myQr = QrWriter.Write("greetings terra", options);

// Fancy style options
AnyBitmap logoBmp = new AnyBitmap("logo.png");

QrStyleOptions style = new QrStyleOptions
{
    Dimensions = 300, // px
    Margins = 10, // px
    Color = Color.Gray,
    Logo = new QrLogo
    {
        Bitmap = logoBmp,
        Width = 100,
        Height = 100,
        CornerRadius = 2
    }
};

// Save QR Code as a Bitmap
AnyBitmap qrImage = myQr.Save(style);

// Save QR Code Bitmap as File
qrImage.SaveAs("qr_styled.png");
