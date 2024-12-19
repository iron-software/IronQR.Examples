using IronQr;
using IronSoftware.Drawing;

// Create a QR Code object
QrCode myQr = QrWriter.Write("hello world");

// Save QR Code as a Bitmap
AnyBitmap qrImage = myQr.Save();

// Save QR Code Bitmap as File
qrImage.SaveAs("qr.png");
