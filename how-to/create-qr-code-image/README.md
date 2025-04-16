# Generating a QR Code as an Image

***Based on <https://ironsoftware.com/how-to/create-qr-code-image/>***


Creating a QR code image is essentially rendering data — such as a URL, text, or other data forms — into a visual format via a 2D matrix of black and white blocks. These blocks can then be interpreted using either a camera or a QR code scanner application.

## Generating Images of QR Codes

Generating a QR code using IronQR is straightforward, requiring minimal code. Initially, a QR code is created as an object; it can then be saved as an image through a combination of methods. See the example below:

```cs
using IronQr;
using IronSoftware.Drawing;

// Instantiate a new QR code
QrCode qrCode = QrWriter.Write("12345");

// Save the QR code in an AnyBitmap object
AnyBitmap qrImage = qrCode.Save();

// Export the AnyBitmap to a PNG file
qrImage.SaveAs("simpleQrCode.png", AnyBitmap.ImageFormat.Png);
```

![QR code](https://ironsoftware.com/static-assets/qr/how-to/create-qr-code-image/simpleQrCode.webp)

The `Save` method facilitates the capture of the **AnyBitmap** object, from which you can export the QR code to various image formats, including:

- **JPEG (.jpg or .jpeg)**: A commonly used compression format for digital images, balancing file size with visual quality.
- **PNG (.png)**: A lossless format ideal for digital graphics used online, featuring support for transparent backgrounds.
- **BMP (.bmp)**: An uncompressed image format predominantly used on Windows platforms that keeps images in high quality but has large file sizes.
- **GIF (.gif)**: A format capable of displaying animations and transparency, limited to 256 colors and often used for simple graphics on the web.
- **TIFF (.tiff or .tif)**: A highly flexible format favored in professional photography which can be either compressed or uncompressed.
- **WBMP (.wbmp)**: A monochrome image format for wireless applications, defaulting to BMP if not supported.
- **WebP (.webp)**: A modern format offering efficient compression, both lossy and lossless, suited for web usage.
- **Icon (.ico)**: Used for displaying small square icons in user interfaces, such as those in operating systems.
- **WMF (.wmf)**: A format used mainly on Windows, capable of handling both vector and raster graphics, commonly utilized in legacy applications.
- **RawFormat (.raw)**: This format stores raw image data from digital cameras, preserving maximum quality for professional photo editing.

<hr>

## Supported Formats for QR Codes

IronQR supports various QR code formats, catering to different data storage requirements and physical size constraints:

- **QRCode**: The default and most widely used format, capable of encoding substantial information like URLs or contacts.
  
![Standard QR Code](https://ironsoftware.com/static-assets/qr/how-to/read-qr-codes-from-image/simpleQrCode.webp)

- **MicroQRCode**: A compact version suitable for constrained spaces, useful for small items like packaging or labels.

![Micro QR Code](https://ironsoftware.com/static-assets/qr/how-to/read-qr-codes-from-image/MicroQRCode.webp)

- **RMQRCode**: A rectangular variant of the QR code, ideal for specific applications where a rectangular output is beneficial. 

![Rectangular Micro QR Code](https://ironsoftware.com/static-assets/qr/how-to/read-qr-codes-from-image/RMQRCode.webp)