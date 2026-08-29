# Generate QR Codes in C#

> Full guide: [Generate QR Codes in C#](https://ironsoftware.com/tutorials/csharp-qr-writing/)

## Introduction

IronQR generates QR codes in the common image formats and styles them with background colours, margins, and logos, or places them into PDFs. Error correction level and QR version are both configurable.

This guide works through IronQR's main features with examples of QR code generation in C#.

## Contents Outline

- **Data Input Options**
  - [Text, Web Links, and Numeric Data](#text-urls-numbers)
  - Binary Data and Streams

- **QR Code Exporting Methods**
  - Image File Saving
  - Utilizing `System.Drawing.Images`
  - Usage of `IronSoftware.Drawing`
  - PDF Document Stamping

- **Customizing QR Code Settings**
  - [Choice of QR Encoding](#encoding)
  - [Levels of Error Correction](#error-correction-capabilities-in-ironqr)
  - [Selecting QR Code Versions](#adjusting-qr-code-version)
  - [Setting Character Encodings](#character-encoding-options)

- **Styling Options for QR Codes**
  - Adjusting QR Code Size
  - Setting Margins and Borders
  - Changing Color Schemes
  - Incorporating Logos into QR Codes

---

## Input Data

### Text, URLs, Numbers

IronQR turns text, URLs, and numeric values into QR codes: links, plain text, inventory numbers, or arbitrary binary data. The `QrWriter` class carries a method for each kind of input.

```csharp
using IronQr;
using IronSoftware.Drawing;

// Initialization of data
string textContent = "Hello, World!";
string websiteUrl = "https://ironsoftware.com/csharp/qr/";
string alphaNumericCode = "SKU12345-X";

// Creation of QR code from text
QrCode qrFromText = QrWriter.Write(textContent);
AnyBitmap imageFromTextQr = qrFromText.Save();
imageFromTextQr.SaveAs("HelloWorldQR.png");

// Creation of QR code from URL
QrCode qrFromUrl = QrWriter.Write(websiteUrl);
AnyBitmap imageFromUrlQr = qrFromUrl.Save();
imageFromUrlQr.SaveAs("WebsiteQR.png");

// Creation of QR code from alphanumeric string
QrCode qrFromAlphaNumeric = QrWriter.Write(alphaNumericCode);
AnyBitmap imageFromAlphaNumericQr = qrFromAlphaNumeric.Save();
imageFromAlphaNumericQr.SaveAs("AlphaNumericQR.png");
```

### Binary & Streams

IronQR also allows for the encoding of binary data and streams into QR codes, using similar methods as previous examples.

```csharp
using IronQr;
using IronSoftware.Drawing;
using System.Text;

// Encoding URL as byte array
byte[] binaryData = Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/qr/");

// Creating QR code from binary data
QrCode binaryDataQr = QrWriter.Write(binaryData);
AnyBitmap binaryQrImage = binaryDataQr.Save();
binaryQrImage.SaveAs("BinaryDataQR.png");

class Program
{
    static void Main()
    {
        // Initializing a new QR code writer
        QrWriter qrWriter = QrWriter.CreateQrCode();

        // Example binary data for a QR code
        byte[] exampleData = { 0x01, 0x02, 0x03, 0x04 };

        // Writing and saving binary data as a QR code
        qrWriter.Write(exampleData).SaveAs("ArrayDataQR.png");

        // Using memory stream for binary data
        using (MemoryStream memoryStream = new MemoryStream(exampleData))
        {
            qrWriter.Write(memoryStream).SaveAs("StreamDataQR.png");
        }
    }
}

// Demonstrates handling both byte arrays and streams with conversion into QR codes
using IronQr;
using IronSoftware.Drawing;
using System.IO;
using System.Text;

// Memory stream from string URL
MemoryStream inputStream = new MemoryStream(Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/qr/"));

// Creating QR from memory stream
QrCode streamDataQr = QrWriter.Write(inputStream);
AnyBitmap streamQrImage = streamDataQr.Save();
streamQrImage.SaveAs("StreamDataQR.png");
```

## Exporting QR Codes

Use the `SaveAs` method to store QR codes as JPG, PNG, GIF, or TIFF.

### Saving an Image

The `SaveAs` method in the `AnyBitmap` class picks the file format from the extension of the file path. For instance, a file path ending in `.png` is identified accordingly.

It's important to be aware that there isn't a pre-set default image format for the `SaveAs` method. Should you use a file extension that isn’t recognized, or if there’s an error in the extension you type, the file will nonetheless be saved, but it will have the wrong format.

```cs
using IronQr;
using IronSoftware.Drawing;

// Initialize a new QR code instance
QrCode newQrCode = QrWriter.Write("hello world");

// Generate a bitmap from the QR code
AnyBitmap generatedQrImage = newQrCode.Save();

// Persist the QR code image to a file
generatedQrImage.SaveAs("qr.png");
```

### System.Drawing.Images

Utilizing Microsoft's `System.Drawing.Images` object, developers have the ability to convert images and utilize the `Bitmap` class to store QR codes directly to a specified file location. In this illustration, the method `Save` stores the QR code as a PNG image in the filename `qrBitmap.png`.

Note: `System.Drawing.Common` library functions exclusively on the Windows platform.

```csharp
using IronQr;
using System.Drawing;

// Instantiate a new QR code
QrCode qrCode = QrWriter.Write("hello world");

// Convert the QR code into a bitmap image
Bitmap qrBitmap = qrCode.Save();

// Store the bitmap image to a file
qrBitmap.Save("qrBitmap.png");
```

### IronSoftware.Drawing Capabilities

The `System.Drawing.Common` library sometimes presents challenges in cross-platform environments, which could lead to issues when maintaining applications that need to function across different operating systems. To address these challenges, IronQR is designed to be compatible with both `System.Drawing.Common` and `IronSoftware.Drawing`.

IronQR leverages the `AnyBitmap` class from [`IronSoftware.Drawing`](https://ironsoftware.com/open-source/csharp/drawing/docs/), a Bitmap class built for cross-platform compatibility. This class is capable of implicit conversions to various image formats, including:

- `System.Drawing.Bitmap`
- `System.Drawing.Image`
- `SkiaSharp.SKBitmap`
- `SixLabors.ImageSharp`
- `Microsoft.Maui.Graphics.Platform.PlatformImage`

This open-source library lets IronQR run across .NET 8, .NET 7, .NET 6, .NET 5, .NET Core, .NET Standard, and .NET Framework 4.6.2 and above. For further details about the capabilities and integration of this library, visit the [IronSoftware.Drawing website](https://ironsoftware.com/open-source/csharp/drawing/).

### Affix QR Codes to PDF Documents

IronQR stamps QR codes onto existing PDFs, on a single page or across several, giving readers a quick route to a link or resource.

#### Stamping a Single Page with a QR Code

Once the QR code has been generated, utilize the `StampToExistingPdfPage` method available in the `QrCode` class. You will need to specify the file path, the coordinates (x and y) on the page where the QR code will be placed, the page number, and optionally, a password if the PDF document is protected. After inputting these parameters, the method will embed the QR code onto the specified PDF page and save the document.

This procedure operates with page numbers that initiate at 1, thereby the first page is numbered as 1 instead of 0.

```csharp
using IronQr;

// Initialize a QR code
QrCode qrCode = QrWriter.Write("hello world");

// Define PDF location and page attributes
string pdfPath = "example.pdf";
int xPos = 100;
int yPos = 150;
int pageNumber = 1;

// Apply the QR code at coordinates (100, 150) on the first page of the PDF
qrCode.StampToExistingPdfPage(pdfPath, xPos, yPos, pageNumber);
```

#### Applying Stamps Across Multiple Pages

Similar to the previously mentioned example, the key distinction here is that the `StampToExistingPdfPages` method accepts a list of page numbers, allowing you to apply the QR code stamp to multiple pages at once.

```cs
using IronQr;
using System.Collections.Generic;

// Initialize a new QR code
QrCode qrCode = QrWriter.Write("hello world");

string pdfPath = "example.pdf";
int xPos = 100;
int yPos = 150;
List<int> pageList = new List<int> { 1, 2, 3, 4 };

// Imprint the QR code at position (100, 150) on specified pages of the PDF
qrCode.StampToExistingPdfPages(pdfPath, xPos, yPos, pageList);
```

#### Results from Both Demonstrations

![alt text](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-writing/stamptoexistingpdfexample.gif)

## QR Code Customization

IronQR presents a wide array of customization capabilities that allow you to precisely adjust the behavior and performance of QR codes. The `QrOptions` class controls QR code version, encoding format, character encoding, and error correction standard. Each is covered below.

### Encoding

IronQR accommodates various QR code formats for creation and scanning. Here are the formats it supports:

- `QRCode`: The traditional QR code widely recognized and utilized, capable of storing as many as 7,089 numeric characters or 4,296 alphanumeric characters.
- `MicroQRCode`: A concise form of the typical QR code, able to hold up to 35 numeric characters or 21 alphanumeric characters.
- `RMQRCode`: This variant, known as the Rectangular Micro QR Code, supports flexible aspect ratios, and is a more compact form of the traditional QR code.

```cs
using IronQr;
using IronSoftware.Drawing;

// Setting up new QR code options
QrOptions options = new QrOptions
{
    // Specifying the encoding type as micro QR code for smaller size
    Encoding = IronQr.Enum.QrEncoding.MicroQRCode,
};

// Generating the QR code with specific options
QrCode qr = QrWriter.Write("1234", options);

// Storing the generated QR code into a bitmap instance
AnyBitmap qrImage = qr.Save();

// Writing the QR image to a file with specified format
qrImage.SaveAs("qrImage.png");
```

### Error Correction Capabilities in IronQR

IronQR applies standard error correction so generated QR codes stay readable in poor conditions. It also provides full flexibility in adjusting the error correction levels to refine the output according to specific needs.

IronQR supports four distinct levels of error correction accessible through the `QrErrorCorrectionLevel` enum:

- `Highest`: Offers up to 30% error correction.
- `High`: Provides up to 25% error correction.
- `Medium`: Delivers up to 15% error correction.
- `Low`: Allows for 7% error correction. 

These options ensure that QR codes remain functional and decipherable, even if they are partially damaged or obscured.

```csharp
using IronQr;
using IronSoftware.Drawing;

// Configure QR code with medium error correction level
QrOptions qrSettings = new QrOptions
{
    ErrorCorrectionLevel = QrErrorCorrectionLevel.Medium, // Set error correction to medium
};

// Generate a QR code with specified options
QrCode generatedQrCode = QrWriter.Write("1234", qrSettings);

// Convert the QR code into a bitmap image
AnyBitmap bitmapOfQr = generatedQrCode.Save();

// Store the bitmap as a PNG file
bitmapOfQr.SaveAs("qrImage.png");
```

Higher error correction keeps QR codes readable at lower resolutions. This feature enables QR codes to remain functional despite potential distortions or damages. Experiment with different levels to see which best fits your specific requirements.

![alt text](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-writing/correctionlevels.jpg)

### Adjusting QR Code Version

Modifying the version of QR codes allows for the storage of varying amounts of data. Higher version numbers are perfect for extensive data applications such as logistics and inventory management. Conversely, lower versions suit compact data needs, such as encoding short URLs efficiently. To customize this, alter the `Version` property within the `QrOptions` class and use it with the `Write` method to create the QR code tailored to your specific needs.

```cs
using IronQr;
using IronSoftware.Drawing;

// Adjust the QR code version to the maximum level, which is 40
QrOptions qrOptions = new QrOptions
{
    Version = 40  // Sets the version level to 40, maximizing data capacity
};

// Generate a new QR code with specified version
QrCode highCapacityQr = QrWriter.Write("1234", qrOptions);

// Store QR code as an image
AnyBitmap highCapacityQrImage = highCapacityQr.Save();

// Export the QR code image to a PNG file
highCapacityQrImage.SaveAs("highCapacityQrImage.png");
```

![alt text](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-writing/versionDifference.jpg)

The illustrated comparison clearly demonstrates that QR code version 40 is substantially more intricate and packed with data than version 5.

Scanning lower versions of QR codes demands more accuracy, often necessitating the use of high-resolution scanners. On the other hand, QR codes of higher versions are more user-friendly as they can be effectively scanned with more commonly available lower-resolution cameras. For additional insights into selecting the appropriate QR code version according to data needs, you can visit the [detailed QR version guide](https://www.qrcode.com/en/about/version.html).

### Character Encoding Options

Character encoding plays a critical role in how data is incorporated into QR codes. In the provided instance, we switched the encoding to `UTF-32`. Originally, the encoding defaults to `ISO-8859-1`. This setting influences how text and data are formatted and recognized within the QR code itself.

```cs
using IronQr;
using IronSoftware.Drawing;

// Setting up QR code options with different character encoding
QrOptions settings = new QrOptions
{
    // Use UTF-32 encoding for the QR code
    CharacterEncoding = "UTF-32"
};

// Generate a QR code with the specified settings
QrCode generatedQr = QrWriter.Write("1234", settings);

// Convert the QR code into a bitmap image
AnyBitmap qrAsBitmap = generatedQr.Save();

// Output the QR code image to a file named 'qrImage.png'
qrAsBitmap.SaveAs("qrImage.png");
```

## Customizing QR Codes with IronQR

The `QrStyleOptions` class controls the appearance of a QR code. The options are covered below.

This flexibility in design and input handling makes IronQR a powerful tool for creating distinctive and effective QR codes. Here, we'll take a closer look at how to utilize these styling features effectively.

### Resizing the QR Code

Adjusting the size of the QR code is straightforward. By modifying the `Dimensions` attribute of the `QrStyleOptions` class and directing it to the `Save` function, you can customize the size of the QR code output. The default dimension is set at 300px, but in our demonstration, we've doubled this to 600px for a clearer and larger QR code.

```cs
using IronQr;
using IronSoftware.Drawing;

// Define style options for the QR code
QrStyleOptions options = new QrStyleOptions()
{
    // Set QR code size to 600 pixels
    Dimensions = 600,
};

// URL that will be encoded into the QR code
string targetUrl = "https://ironsoftware.com/csharp/qr/";

// Generating the QR code
QrCode generatedQr = QrWriter.Write(targetUrl);

// Generate and apply the styling options
AnyBitmap styledQrImage = generatedQr.Save(options);

// Exporting the styled QR code as a PNG file
styledQrImage.SaveAs("qrURLResized.png");
```

![alt text](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-writing/resizeQRexample.jpg)

### Margins & Borders

Modifying the margins and borders is straightforward using the `Margins` attribute within the `QrStyleOptions` class. This attribute governs the QR code's edge spacing on each side, which is preset to 10 pixels. In our demonstration, we've adjusted this margin specification to 20 pixels.

```cs
using IronQr;
using IronSoftware.Drawing;

// Define styling options for the QR code
QrStyleOptions qrStyles = new QrStyleOptions()
{
    // Set the outer margins to 20 pixels
    Margins = 20
};

// Specify the URL to encode
string link = "https://ironsoftware.com/csharp/qr/";

// Generate the QR code
QrCode generatedQr = QrWriter.Write(link);

// Convert the QR code to a bitmap using the specified styles
AnyBitmap qrCodeBitmap = generatedQr.Save(qrStyles);

// Output the bitmap as a PNG file
qrCodeBitmap.SaveAs("qrURLMarginMultiple.png");
```

![alt image](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-writing/qrMarginmultiple.jpg)

#### Customizing Margins Individually

IronQR offers the capability to set distinct margins for each edge of the QR code, affording developers more precise control over its appearance. This feature is particularly useful for creating QR codes that need specific alignment or distinctive styling within various application layouts.

```cs
using IronQr;
using IronSoftware.Drawing;

// Define styling options for the QR code
QrStyleOptions qrStyling = new QrStyleOptions()
{
    // Set custom margins on each side
    MarginBottom = 30,
    MarginTop = 100,
    MarginRight = 40,
    MarginLeft = 20,
};

// URL to encode into QR code
string targetURL = "https://ironsoftware.com/csharp/qr/";

// Generate the QR code
QrCode generatedQrCode = QrWriter.Write(targetURL);

// Render the QR code as a bitmap with the specified styling
AnyBitmap qrBitmap = generatedQrCode.Save(qrStyling);

// Output the QR code bitmap to a file
qrBitmap.SaveAs("qrURLMarginMultiple.png");
```

### QR Code Color Customization

By utilizing the `QrStyleOptions` class, you can inject vibrant colors into the QR code and its surrounding background, adding a personalized touch that makes it stand out. These aesthetic enhancements are achieved through the `Color` and `BackgroundColor` properties. Remember to include the `IronSoftware.Drawing` in your imports to access a broad spectrum of color options available for customization.

```cs
using IronQr;
using IronSoftware.Drawing;

// Import the logo image
AnyBitmap logoImage = AnyBitmap.FromFile("sample.png");

// Incorporate the logo into QR code customization settings
QrStyleOptions qrCustomization = new QrStyleOptions()
{
    Logo = new QrLogo(logoImage, 50, 50, 10) // Set the logo with specific dimensions and padding
};

string websiteUrl = "https://ironsoftware.com/csharp/qr/";

// Generate the QR code with the specified URL
QrCode qrCode = QrWriter.Write(websiteUrl);

// Convert the QR code to bitmap using custom style settings
AnyBitmap qrCodeBitmap = qrCode.Save(qrCustomization);

// Save the styled QR code to a file
qrCodeBitmap.SaveAs("qrURLColored.png");
```

![alt text](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-writing/qrURLColored.png)

### Incorporating a Logo

You can enhance your QR codes by embedding your company's logo, making it instantly identifiable to your audience. The `Logo` property places the logo into the QR code’s design.

```cs
using IronQr;
using IronSoftware.Drawing;

// Load a logo image to include in the QR code
AnyBitmap logoImage = AnyBitmap.FromFile("sample.png");

// Initialize QR styling options with a logo
QrStyleOptions qrStylingOptions = new QrStyleOptions()
{
    Logo = new QrLogo(logoImage, 50, 50, 10), // setting logo with dimensions and margin
};

// Specify the URL to encode in the QR code
string targetUrl = "https://ironsoftware.com/csharp/qr/";

// Generate the QR code with the specified URL
QrCode generatedQrCode = QrWriter.Write(targetUrl);

// Render the QR code as an image using the styling specifications
AnyBitmap renderedQrImage = generatedQrCode.Save(qrStylingOptions);

// Output the QR code image to a file
renderedQrImage.SaveAs("qrURLColored.png");
```

![alternative text](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-writing/qrURLLogo.png)

#### Logo Customization Options

The `QrLogo` class provides extensive options to tailor the look of your logo. Here are the adjustable properties:

- `Bitmap`: This property specifies the graphic file you'd like to use for the logo.
- `Width`: This defines the width of the logo, with a default set to 0.
- `Height`: This sets the height of the logo, with a default also set to 0.
- `CornerRadius`: This property determines the radius for the corners of the logo, enabling you to create rounded corners. The default radius is 0, which results in square corners.

```csharp
using IronQRCode;
using IronSoftware.Drawing;

class Program
{
    static void Main()
    {
        // Create style options for the QR code
        QrStyleOptions options = new QrStyleOptions
        {
            Logo = new QrLogo
            {
                Bitmap = AnyBitmap.FromBitmap("path/to/logo.png"),
                Width = 50,  // Logo width set to 50 pixels
                Height = 50, // Logo height set to 50 pixels
                CornerRadius = 5 // Rounded corners with a radius of 5 pixels
            }
        };

        // Instantiate the QR code writer and write a code with a custom logo
        QrCode customizedQrCode = QrWriter.CreateQrCode().Write("Customized Logo Example");

        // Save the QR code with the customized logo to a file
        customizedQrCode.SaveAs("example-customized-logo-qr.png", options);
    }
}
```

## Assessing Fault Tolerance 

IronQR also carries debugging and error-handling facilities for managing exceptions and writing unit tests against QR generation.

### Checksums

Even though QR codes can become impaired, IronQR comes equipped with integrated checksums and data correction capabilities, ensuring their functionality. It employs the [Reed-Solomon error correction algorithm](https://en.wikipedia.org/wiki/Reed%E2%80%93Solomon_error_correction) to maintain the reliability and fault-tolerance of the QR codes.

### Detailed Error Handling

IronQR enhances user experience by delivering comprehensive error reporting that aids in swiftly pinpointing and resolving issues. It provides specific exceptions, which simplifies the debugging process and facilitates efficient problem resolution. Here is an overview of the notable `IronQrException` types utilized by the library:

- `IronQrEncodingException`: As a specific type of `IronQrException`, this error manifests when there are difficulties during the QR code generation process. This exception is typically raised if a QR code is attempted to be created from an input that lacks content.

![alt text](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-writing/nullErrorException.gif)

- `IronQrFileException`: This subclass of `IronQrException` is triggered by file handling errors.

- `IronQrPdfPasswordExcception`: Also a subclass of `IronQrException`, this error occurs when trying to stamp a password-protected PDF without providing a password or using an incorrect one. This exception encompasses other issues related to PDF access and handling as indicated in the example below.

![alt text](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-writing/passwordException.gif)

## Conclusion

IronQR creates and customizes QR codes in .NET applications, across data encodings, styles, and error correction levels. It writes to several file formats and stamps codes into existing documents, covering both plain QR codes and heavily customized designs.

For additional information, explore the [IronQR documentation](https://ironsoftware.com/csharp/qr/docs/), begin experimenting with a [free trial](https://ironsoftware.com/csharp/qr/trial-license), and evaluate the [licensing options](https://ironsoftware.com/csharp/qr/licensing/) available to determine the best fit for your projects.

