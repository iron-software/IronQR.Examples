# Generating a QR Code Image

***Based on <https://ironsoftware.com/how-to/create-qr-code-image/>***


Creating a QR code image involves producing a QR code, which is a two-dimensional barcode that stores information in a matrix of black and white squares. This format allows for the coded data, such as URLs, text, or other types of data, to be interpreted when scanned by a QR code reader or a camera.

## Generate and Save QR Codes as Images Using IronQR

Generating a QR code using the IronQR library is straightforward. Start by creating a QR code in a single line, then use various methods to save it as an image.

```csharp
using IronQr;
using IronSoftware.Drawing;

// Initialize a QR code
QrCode qrCode = QrWriter.Write("12345");

// Convert QR code to AnyBitmap
AnyBitmap anyBitmap = qrCode.Save();

// Output AnyBitmap to a file in PNG format
anyBitmap.SaveAs("simpleQrCode.png", AnyBitmap.ImageFormat.Png);
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/qr/how-to/create-qr-code-image/simpleQrCode.webp" alt="QR code" class="img-responsive add-shadow">
    </div>
</div>

The `Save` method generates an **AnyBitmap** object. This object can be saved in different image formats, each suitable for various needs:

- **JPEG (.jpg or .jpeg)**: A popular compressed format for digital images. Although it uses lossy compression, it delivers a good balance between image quality and file size.
- **PNG (.png)**: This format is preferred for the web due to its lossless compression and support for transparency, ensuring high-quality images without any data loss.
- **Bmp (.bmp)**: An uncompressed format, primarily used in Windows environments. It preserves image quality but results in larger file sizes.
- **GIF (.gif)**: Ideal for animations and images requiring transparency but limited to 256 colors. It's commonly used for simple graphics on websites.
- **TIFF (.tiff or .tif)**: Often used in professional photography, this format is highly flexible and can be either lossless or compressed.
- **WBMP (.wbmp)**: A monochrome image format used chiefly in mobile communications; it defaults to BMP if not supported.
- **WebP (.webp)**: Provides superior compression techniques (both lossy and lossless), optimal for faster web loading.
- **Icon (.ico)**: Used to create icons for programs and files, especially in user interfaces.
- **WMF (.wmf)**: A format used mainly in Windows, suitable for both vector and raster graphics used in older systems.
- **RawFormat (.raw)**: Captures unprocessed image data from digital cameras, preserving the highest quality for professional editing.

## Types of QR Codes Supported

IronQR supports creating and decoding multiple QR code formats:

- **QRCode**: The standard and most widely used format today, capable of encoding substantial data—ideal for applications ranging from web addresses to personal contact details.

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/qr/how-to/read-qr-codes-from-image/simpleQrCode.webp" alt="QR code" class="img-responsive add-shadow">
    </div>
</div>

- **MicroQRCode**: A smaller variant designed for limited space applications. While it holds less data, its small footprint is perfect for tiny product labels or small print areas.

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/qr/how-to/read-qr-codes-from-image/MicroQRCode.webp" alt="QR code" class="img-responsive add-shadow">
    </div>
</div>

- **RMQRCode**: A rectangular version of the QR code, allowing for a versatile aspect ratio to fit various shaped spaces. This format is similarly data-efficient to the Micro QR Code but caters to more specific spatial requirements.

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/qr/how-to/read-qr-codes-from-image/RMQRCode.webp" alt="QR code" class="img-responsive add-shadow">
    </div>
</div>