# How to Read QR Codes from Images

***Based on <https://ironsoftware.com/how-to/read-qr-codes-from-image/>***


Extracting information from QR codes involves capturing and decoding the encapsulated data using appropriate hardware and software. This information can range from simple text and URLs to contact information and other data types.

## Extracting QR Codes from Various Image Types

IronQR excels with its inherent ability to extract QR codes from a multitude of image formats with ease. Supported formats include:

- Joint Photographic Experts Group (JPEG)
- Portable Network Graphics (PNG)
- Graphics Interchange Format (GIF)
- Tagged Image File Format (TIFF)
- Bitmap Image File (BMP)
- WBMP
- WebP
- Icon (ICO)
- Windows Metafile (WMF)
- Raw image formats (RAW)

This capability is powered by the open-source library, [IronDrawing](https://ironsoftware.com/open-source/csharp/drawing/docs/). Let's explore the procedure for utilizing IronQR to read QR codes from an image.

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/qr/how-to/read-qr-codes-from-image/simpleQrCode.webp" alt="QR code" class="img-responsive add-shadow">
    </div>
</div>

```csharp
// Include the necessary namespaces for IronQR and IronDrawing
using IronSoftware.Drawing; 
using IronBarcode;

public class QRCodeReader
{
    public static void Main()
    {
        // Load the image file into the application
        using (var inputImage = Image.FromFile("path/to/your/image/file.webp"))
        {
            // Initialize a QrImageInput object with the loaded image
            var qrImageInput = new QrImageInput(inputImage);

            // Execute QR code decoding on the provided image
            var result = BarcodeReader.Read(qrImageInput);

            // Output the decoded QR code data
            foreach (var barcodeResult in result.Barcodes)
            {
                Console.WriteLine($"QR Code Data: {barcodeResult.Value}");
            }
        }
    }
}
```
*Note: Modify "path/to/your/image/file.webp" to the specific path where your QR code image is located.*

<i>Try scanning the QR code in the provided image using the above code example!</i>

<hr>

## Supported Types of QR Codes

IronQR supports a variety of QR codes for decoding and generation, outlined below:

- **QR Code**: The standard and most widely used QR code today, capable of holding extensive data amounts up to 7,089 numeric characters or 4,296 alphanumeric ones, suitable for a variety of uses including URLs and contact details.

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/qr/how-to/read-qr-codes-from-image/simpleQrCode.webp" alt="QR code" class="img-responsive add-shadow">
    </div>
</div>

- **Micro QR Code**: A compact variant designed for space-constrained applications. It accommodates up to 35 numeric or 21 alphanumeric characters, making it perfect for small packaging or labels.

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/qr/how-to/read-qr-codes-from-image/MicroQRCode.webp" alt="Micro QR code" class="img-responsive add-shadow">
    </div>
</div>

- **RM QR Code**: A novel rectangular version of the QR code that adapts flexibly to varied aspect ratios. This is particularly useful for items with rectangular labeling spaces, and it stores a data amount similar to the Micro QR Code.

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/qr/how-to/read-qr-codes-from-image/RMQRCode.webp" alt="Rectangular QR code" class="img-responsive add-shadow">
    </div>
</div>