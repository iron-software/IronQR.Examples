# How to Decode QR Code from Images

***Based on <https://ironsoftware.com/how-to/read-qr-codes-from-image/>***


Decoding a QR code involves the extraction and interpretation of data embedded within the code, typically accomplished using imaging technology paired with specific software capable of reading the QR code’s content. This content often includes text, website URLs, contact details, and more.

## Decipher QR Codes from Image Files

IronQR excels in its ability to seamlessly decode QR codes from a variety of image formats. Supported formats include:

- **JPEG** (Joint Photographic Experts Group)
- **PNG** (Portable Network Graphics)
- **GIF** (Graphics Interchange Format)
- **TIFF** (Tagged Image File Format)
- **BMP** (Bitmap Image File)
- **WBMP**
- **WebP**
- **ICO** (Icon)
- **WMF**
- **RAW** (Raw Format)

This capability is provided by the [IronDrawing](https://ironsoftware.com/open-source/csharp/drawing/docs/) library. Below, we demonstrate how to use IronQR to decode a QR code from an image.

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/qr/how-to/read-qr-codes-from-image/simpleQrCode.webp" alt="QR code" class="img-responsive add-shadow">
    </div>
</div>

```cs
using IronQr;
using IronSoftware.Drawing;
using System.Collections.Generic;
using System;

// Initialize the image from which the QR Code will be read
var imageToDecode = AnyBitmap.FromFile("IMAGE_TO_READ.png");

// Prepare the image input for decoding
QrImageInput qrInput = new QrImageInput(imageToDecode);

// Instantiate the QR Code reader
QrReader qrReader = new QrReader();

// Decode the QR Code from the image
IEnumerable<QrResult> qrResults = qrReader.Read(qrInput);

// Output the decoded data
foreach (var qrResult in qrResults)
{
    Console.WriteLine(qrResult.Value);
}
```

<i>Interested in finding out what the QR codes in our sample images contain? Apply the above code snippet to discover!</i>

<hr>

## Types of QR Codes Supported

IronQR supports decoding various QR code formats. Here are the supported types:

- **QRCode**: The standard and most widely used type, capable of containing a vast amount of data—up to 7,089 numeric characters or 4,296 alphanumeric characters. This versatility makes it suitable for multiple uses, from linking to websites to storing personal information.

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/qr/how-to/read-qr-codes-from-image/simpleQrCode.webp" alt="QR code" class="img-responsive add-shadow">
    </div>
</div>

- **MicroQRCode**: This more compact variation is perfect for limited space applications, capable of storing up to 35 numeric characters or 21 alphanumeric characters. It’s ideal for small product packaging or tiny labels.

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/qr/how-to/read-qr-codes-from-image/MicroQRCode.webp" alt="QR code" class="img-responsive add-shadow">
    </div>
</div>

- **RMQRCode**: The Rectangular Micro QR Code is a versatile, compact QR solution that fits well in uniquely shaped places thanks to its rectangular design. While it holds a similar amount of data as the Micro QR Code, it is optimized for non-square spaces.

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/qr/how-to/read-qr-codes-from-image/RMQRCode.webp" alt="QR code" class="img-responsive add-shadow">
    </div>
</div>