# Generate QR Codes in C#

***Based on <https://ironsoftware.com/tutorials/csharp-qr-writing/>***


## Introduction

IronQR empowers developers to craft QR codes, enabling them to incorporate popular image formats and personalize their design with various options such as background hues, margins, logos, and integration into PDFs. It also provides capabilities for advanced customization like error correction levels and version selection.

This guide will delve into the significant features of IronQR by demonstrating examples to assist you in understanding how to implement QR code generation in C# effectively in your projects.

## Introduction

IronQR empowers developers to generate QR codes in various common image formats while offering extensive customization options, including background colors, margins, and logos. Additionally, it allows QR codes to be incorporated into PDF documents. For sophisticated needs, IronQR provides the ability to manage error correction levels and versioning.

This discussion will delve into the principal functionalities of IronQR through practical examples. It is designed to assist you in mastering QR code creation in C# and integrating these capabilities proficiently into your development projects.

# Table of Contents

***Based on <https://ironsoftware.com/tutorials/csharp-qr-writing/>***


---

## Contents Outline

- **Data Input Options**
  - [Text, Web Links, and Numeric Data](#anchor-text-urls-numbers)
  - [Binary Data and Streams](#anchor-binary-streams)

- **QR Code Exporting Methods**
  - [Image File Saving](#anchor-save-as-image)
  - [Utilizing `System.Drawing.Images`](#anchor-system-drawing-images)
  - [Usage of `IronSoftware.Drawing`](#anchor-ironsoftware-drawing)
  - [PDF Document Stamping](#anchor-stamp-on-pdf)

- **Customizing QR Code Settings**
  - [Choice of QR Encoding](#anchor-encoding)
  - [Levels of Error Correction](#anchor-error-correction)
  - [Selecting QR Code Versions](#anchor-qr-code-version)
  - [Setting Character Encodings](#anchor-character-encoding)

- **Styling Options for QR Codes**
  - [Adjusting QR Code Size](#anchor-resize)
  - [Setting Margins and Borders](#anchor-margins-borders)
  - [Changing Color Schemes](#anchor-recolor)
  - [Incorporating Logos into QR Codes](#anchor-add-a-logo)

---

!!!--LIBRARY_START_TRIAL_BLOCK--!!!

## Input Data

### Text, URLs, Numbers

Utilizing IronQR, you can effortlessly transform various types of data such as text, URLs, and numerical values into QR codes. This functionality is ideal for generating QR codes that contain links, communicate information textually, manage inventory numbers, or embed any binary data into readable QR codes. IronQR streamlines the creation process through its `QrWriter` class which offers diverse methods capable of catering to different data inputs, simplifying the overall workflow.

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

### Text, URLs, Numbers

IronQR is adept at transforming a variety of data inputs—such as text, URLs, and numerical data—into readable QR codes. This capability is perfect for generating QR-based links, texts for marketing purposes, or even numeric identifiers for tracking inventory. IronQR caters to all these needs with ease.

Moreover, the API is designed for simplicity and ease of use. The `QrWriter` class provides multiple overloads, accommodating various data types as input. This functionality simplifies the QR creation process, making it less complex and more efficient.

```csharp
using IronQr;
using IronSoftware.Drawing;

// Define text, a URL, and an alphanumeric string
string text = "Hello, World!";
string url = "https://ironsoftware.com/csharp/qr/";
string alphanumericData = "WATERSKU-12356";

// Generate a QR code for the plain text
QrCode qrFromText = QrWriter.Write(text);
// Create a bitmap from the QR code
AnyBitmap bitmapFromText = qrFromText.Save();
// Save the bitmap to a PNG file
bitmapFromText.SaveAs("textQr.png");

// Generate a QR code for the URL
QrCode qrFromUrl = QrWriter.Write(url);
// Create a bitmap from the QR code
AnyBitmap bitmapFromUrl = qrFromUrl.Save();
// Save the bitmap to a PNG file
bitmapFromUrl.SaveAs("urlQr.png");

// Generate a QR code for the alphanumeric string
QrCode qrFromAlphanumeric = QrWriter.Write(alphanumericData);
// Create a bitmap from the QR code
AnyBitmap bitmapFromAlphanumeric = qrFromAlphanumeric.Save();
// Save the bitmap to a PNG file
bitmapFromAlphanumeric.SaveAs("alphanumericQr.png");
```

### Binary Data and Streams Conversion

Likewise, binary data and streams can be effortlessly transformed into QR codes using the identical `Write` method previously mentioned. This approach allows for the encoding of various forms of data into a scannable QR format with ease.

```csharp
using IronQr;
using IronSoftware.Drawing;
using System.Text;

// Convert the URL to a byte array
byte[] bytes = Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/qr/");

// Generate a QR code from the byte array
QrCode qrFromBytes = QrWriter.Write(bytes);

// Generate a bitmap from the QR code
AnyBitmap bitmapFromQr = qrFromBytes.Save();

// Export the bitmap as a PNG file
bitmapFromQr.SaveAs("bytesQr.png");
```

```csharp
class Program
{
    static void Main()
    {
        // Instantiate a new QR code creation object
        QrWriter writer = QrWriter.CreateQrCode();

        // Define binary data for QR code generation
        byte[] data = { 0x01, 0x02, 0x03, 0x04 };

        // Generate a QR code from binary data and save as an image
        writer.Write(data).SaveAs("binary-qr.png");

        // Generate a QR code from a memory stream and save it
        using (MemoryStream stream = new MemoryStream(data))
        {
            writer.Write(stream).SaveAs("stream-qr.png");
        }
    }
}
```

The method `Write` provides variations that enable usage of both byte arrays and streams for input. When using streams, a `MemoryStream` can be constructed using the byte array which is then transformed into a QR code. This approach is beneficial for those needing detailed control over data segments, as it allows for more efficient memory usage.

```cs
using IronQr;
using IronSoftware.Drawing;
using System.IO;
using System.Text;

// Initialize a stream with the URL for QR encoding
var encodedStream = new MemoryStream(Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/qr/"));

// Generate a QR code from the stream
QrCode qrFromStream = QrWriter.Write(encodedStream);

// Convert the QR code into a bitmap image
AnyBitmap bitmapImage = qrFromStream.Save();

// Write the bitmap image to a PNG file
bitmapImage.SaveAs("streamQr.png");
```

# Crafting QR Codes with IronQR in C#

***Based on <https://ironsoftware.com/tutorials/csharp-qr-writing/>***


## Introduction

IronQR provides a toolkit for developers to generate QR codes that can be customized with various features such as background colors, margins, logos, and integration into PDF documents. It also allows for the adjustment of error correction levels and QR code versions.

This guide will demonstrate how to effectively implement IronQR in your C# projects, enhancing your applications with the ability to generate and customize QR codes.

## Overview

- **Data to Encode**
  - [Text, URLs, Digits](#anchor-text-urls-numbers)
  - [Binary Content & Data Streams](#anchor-binary-streams)
- **QR Code Export Options**
  - [Image File Export](#anchor-save-as-image)
  - [Using System.Drawing.Images](#anchor-system-drawing-images)
  - [Utilizing IronSoftware.Drawing](#anchor-ironsoftware-drawing)
  - [Embedding onto PDFs](#anchor-stamp-on-pdf)
- **QR Code Configuration Options**
  - [Code Encoding Techniques](#anchor-encoding)
  - [Adjusting Error Prevention Levels](#anchor-error-correction)
  - [QR Code Model Versions](#anchor-qr-code-version)
  - [Setting Character Encoding Types](#anchor-character-encoding)
- **Customizing QR Code Appearance**
  - [Dimension Adjustments](#anchor-resize)
  - [Setting Margins & Borders](#anchor-margins-borders)
  - [Changing Color Themes](#anchor-recolor)
  - [Incorporating Logos](#anchor-add-a-logo)
  
## Data to Encode

### Text, URLs, Digits

With IronQR, you can easily transform text, URLs, and numerical information into QR codes. This is ideal for generating codes for marketing, inventory systems, or information sharing. IronQR simplifies the process through its user-friendly `QrWriter` class which supports various data inputs to minimize complexity.

```csharp
using IronQr;
using IronSoftware.Drawing;

string message = "Hello, World!";
string link = "https://ironsoftware.com/csharp/qr/";
string alphanumericData = "ITEM123456";

// Generate a QR code from text
QrCode messageQr = QrWriter.Write(message);
// Produce a bitmap of the QR code
AnyBitmap messageQrImage = messageQr.Save();
// Write the bitmap as a PNG file
messageQrImage.SaveAs("messageQr.png");

QrCode linkQr = QrWriter.Write(link);
AnyBitmap linkQrImage = linkQr.Save();
linkQrImage.SaveAs("linkQr.png");

QrCode alphanumericQr = QrWriter.Write(alphanumericData);
AnyBitmap alphanumericQrImage = alphanumericQr.Save();
alphanumericQrImage.SaveAs("alphanumericQr.png");
```

### Binary & Streams

IronQR also supports the conversion of binary data and data streams into QR codes using the aforementioned `Write` method.

```cs
using IronQr;
using IronSoftware.Drawing;
using System.Text;

byte[] binaryData = Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/qr/");

// Generate QR from binary data
QrCode binaryDataQr = QrWriter.Write(binaryData);

// Convert the QR code into a bitmap
AnyBitmap binaryDataQrImage = binaryDataQr.Save();

// Write the bitmap to a PNG file
binaryDataQrImage.SaveAs("binaryDataQr.png");

// Example using data streams
byte[] streamData = { 0x01, 0x02, 0x03, 0x04 };
using (MemoryStream memoryStream = new MemoryStream(streamData))
{
    QrCode streamQr = QrWriter.Write(memoryStream);
    streamQr.SaveAs("streamQr.png");
}
```

Write methods include support for byte arrays and streams, allowing for effective processing of chunked data, providing memory efficiency.

```cs
using IronQr;
using IronSoftware.Drawing;
using System.IO;
using System.Text;

MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/qr/"));

// Generate QR code from a memory stream
QrCode memoryStreamQr = QrWriter.Write(memoryStream);

// Convert the QR code to a bitmap
AnyBitmap memoryStreamQrImage = memoryStreamQr.Save();

// Output the bitmap to a PNG file
memoryStreamQrImage.SaveAs("memoryStreamQr.png");
```

## Exporting QR Codes

IronQR offers a versatile and adaptable approach to handling numerous file formats for diverse requirements. Utilize the `SaveAs` method to store QR codes in a variety of formats, including JPG, PNG, GIF, and TIFF.

### Saving an Image

The `SaveAs` method in the `AnyBitmap` class intuitively identifies the file format by examining the suffix of the specified file path. For instance, a file path ending in `.png` is identified accordingly.

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

Here is the paraphrased section of the article, with proper markdown formatting and code snippet enhancement:

----
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

IronQR leverages the `AnyBitmap` class from [`IronSoftware.Drawing`](https://ironsoftware.com/open-source/csharp/drawing/docs/), a versatile Bitmap class designed for universal compatibility. This class is capable of implicit conversions to various image formats, including:

- `System.Drawing.Bitmap`
- `System.Drawing.Image`
- `SkiaSharp.SKBitmap`
- `SixLabors.ImageSharp`
- `Microsoft.Maui.Graphics.Platform.PlatformImage`

This feature-rich open-source library ensures that IronQR can function seamlessly across multiple platforms, including .NET 8, .NET 7, .NET 6, .NET 5, .NET Core, .NET Standard, and .NET Framework 4.6.2 and above. For further details about the capabilities and integration of this library, visit the [IronSoftware.Drawing website](https://ironsoftware.com/open-source/csharp/drawing/).

### Affix QR Codes to PDF Documents

IronQR empowers developers to affix QR codes onto pre-existing PDFs, simplifying the process for users to swiftly access links or vital resources. The capability to apply QR codes to either individual or multiple pages is available, enhancing the flexibility of document interactions.

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

Here's the paraphrased section of the article with updated links:

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

IronQR presents a wide array of customization capabilities that allow you to precisely adjust the behavior and performance of QR codes. Leveraging the `QrOptions` class, developers can tweak various settings including QR code version, encoding format, character encoding, and error correction standards. We'll dive deeper into each of these adjustable parameters.

### Encoding

IronQR accommodates various QR code formats for creation and scanning. Here are the formats it supports:

- `QRCode`: The traditional QR code widely recognized and utilized, capable of storing as many as 7,089 numeric characters or 4,296 alphanumeric characters.
- `MicroQRCode`: A concise form of the typical QR code, able to hold up to 35 numeric characters or 21 alphanumeric characters.
- `RMQRCode`: This variant, known as the Rectangular Micro QR Code, is optimized for flexible aspect ratios, providing a streamlined version of the traditional QR code.

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

IronQR incorporates standard error correction methodologies to guarantee the reliability and robustness of all generated QR codes, even under adverse conditions. It also provides full flexibility in adjusting the error correction levels to refine the output according to specific needs.

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

Enhanced error correction increases the robustness of QR codes, improving their readability even at lower resolutions. This feature enables QR codes to remain functional despite potential distortions or damages. Experiment with different levels to see which best fits your specific requirements.

![alt text](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-writing/correctionlevels.jpg)

### Adjusting QR Code Version

Modifying the version of QR codes allows for the storage of varying amounts of data. Higher version numbers are perfect for extensive data applications such as logistics and inventory management. Conversely, lower versions suit compact data needs, such as encoding short URLs efficiently. To customize this, alter the `Version` property within the `QrOptions` class and use it with the `Write` method to create the QR code tailored to your specific needs.

Here's the paraphrased section with updated and resolved URLs:

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

# Write QR Codes in C&num;

***Based on <https://ironsoftware.com/tutorials/csharp-qr-writing/>***


## Introduction

IronQR empowers developers to craft QR codes in popular image formats while allowing for personalization with different colors, margins, logos, and placement on PDFs. The library includes settings for error correction and control over QR code versions, enhancing its utility.

This guide highlights IronQR's key features through examples, showing its application in generating QR codes using C# and leveraging it in software projects.

## Table of Contents

- **Input Data**
  - [Text, URLs, Numbers](#anchor-text-urls-numbers)
  - [Binary & Streams](#anchor-binary-streams)
- **Export QR Codes**
  - [Save as Image](#anchor-save-as-image)
  - [System.Drawing.Images](#anchor-system-drawing-images)
  - [IronSoftware.Drawing](#anchor-ironsoftware-drawing)
  - [Stamp on PDF](#anchor-stamp-on-pdf)
- **QR Code Options**
  - [Encoding](#anchor-encoding)
  - [Error Correction](#anchor-error-correction)
  - [QR Code Version](#anchor-qr-code-version)
  - [Character Encoding](#anchor-character-encoding)
- **QR Code Styling**
  - [Resize](#anchor-resize)
  - [Margins & Borders](#anchor-margins-borders)
  - [Recolor](#anchor-recolor)
  - [Add a Logo](#anchor-add-a-logo)

<!-- Start trial section for quick access -->
!!!--LIBRARY_START_TRIAL_BLOCK--!!!
## Input Data

### Text, URLs, Numbers
IronQR supports converting an array of data types such as text, URLs, and numerical information into QR codes. This is particularly useful for generating QR code links for promotional activities, creating numeric codes for inventory systems, or translating binary data or streams into scannable QR formats.

The API, through the `QrWriter` class, introduces several overloads allowing multiple types of data as input, thus simplifying the coding process.

```csharp
using IronQr;
using IronSoftware.Drawing;

string text = "Hello, World!";
string url = "https://ironsoftware.com/csharp/qr/";
string alphanumeric = "WATERSKU-12356";

// Generate a QR code from text
QrCode textQr = QrWriter.Write(text);
// Save the generated QR code as a bitmap
AnyBitmap textQrImage = textQr.Save();
// Store the QR code as an image file
textQrImage.SaveAs("textQr.png");

// Process a URL into a QR code
QrCode urlQr = QrWriter.Write(url);
AnyBitmap urlQrImage = urlQr.Save();
urlQrImage.SaveAs("urlQr.png");

// Encode alphanumeric data into a QR code
QrCode alphanumericQr = QrWriter.Write(alphanumeric);
AnyBitmap alphanumericQrImage = alphanumericQr.Save();
alphanumericQrImage.SaveAs("alphanumericQr.png");
```

### Binary & Streams

We can also transform binary data and streams into QR codes utilizing the same `Write` method previously mentioned.

```csharp
using IronQr;
using IronSoftware.Drawing;
using System.Text;

// Convert a string URL into bytes
byte[] bytes = Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/qr/");

// Encode bytes into a QR code
QrCode bytesQr = QrWriter.Write(bytes);
// Render and save QR as a bitmap 
AnyBitmap qrImage = bytesQr.Save();
// Output the QR code to a file
qrImage.SaveAs("bytesQr.png");
```

```csharp
using IronQr;
using IronSoftware.Drawing;
using System.IO;
using System.Text;

// Initialization of a memory stream with bytes
MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/qr/"));

// Writing the stream info into a QR code
QrCode streamQr = QrWriter.Write(stream);

// Saving the QR code as a bitmap
AnyBitmap streamQrImage = streamQr.Save();

// File output for the QR image
streamQrImage.SaveAs("streamQr.png");
```

Within the application, both byte arrays and streams can be processed into QR codes using the `Write` method. For more detailed data management, streams provide a more efficient memory use case, allowing refined control over large data sets.

## Customizing QR Codes with IronQR

IronQR not only simplifies the creation of QR codes but also empowers developers with robust customization options. By leveraging the `QrStyleOptions` class, you can tailor every aspect of your QR code to ensure it stands out and aligns with your needs. Let's delve into the customization possibilities available with IronQR. 

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

Here's the paraphrased section of the article:

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

You can enhance your QR codes by embedding your company's logo, making it instantly identifiable to your audience. This feature not only strengthens brand recognition but also personalizes the QR code. Utilizing the `Logo` property, you can effortlessly integrate your logo into the QR code’s design.

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

Below is the paraphrased section of the article:

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

In this revised version, explanatory comments have been added, and there has been a slight restructuring to enhance readability and understanding of the code example.

# Generating QR Codes with C#

***Based on <https://ironsoftware.com/tutorials/csharp-qr-writing/>***


## Overview

IronQR provides a robust framework for .NET developers to generate QR codes. It supports various image formats and allows customization like changing background colors, adding logos, margins, and enhanced details such as error correction levels and QR versions. This guide will help you leverage IronQR in your C# applications to efficiently create QR codes.

## Table of Contents

- **Input Formats**
  - [Text, URLs, Numeric Data](#anchor-text-urls-numbers)
  - [Binary Data & Streams](#anchor-binary-streams)
- **QR Code Output**
  - [Image Saving Options](#anchor-save-as-image)
  - [Images with System.Drawing](#anchor-system-drawing-images)
  - [Using IronSoftware.Drawing](#anchor-ironsoftware-drawing)
  - [PDF Applications](#anchor-stamp-on-pdf)
- **Customizing QR Codes**
  - [Data Encoding](#anchor-encoding)
  - [Adjusting Error Levels](#anchor-error-correction)
  - [Choosing QR Versions](#anchor-qr-code-version)
  - [Setting Encoding Characters](#anchor-character-encoding)
- **Styling QR Codes**
  - [Adjust Size](#anchor-resize)
  - [Margins and Borders](#anchor-margins-borders)
  - [Changing Colors](#anchor-recolor)
  - [Integrating Logos](#anchor-add-a-logo)

!!!!--LIBRARY_START_TRIAL_BLOCK--!!!
## Input Formats

### Text, URLs, Numeric Data

IronQR enables conversion of text, URLs, and numeric information into QR codes, ideal for various applications such as promotional campaigns, inventory systems, or data transmissions. With its `QrWriter` class, you can input different data types smoothly and with minimal complexity.

```csharp
using IronQr;
using IronSoftware.Drawing;

string textToEncode = "Hello, World!";
string websiteUrl = "https://ironsoftware.com/csharp/qr/";
string alphaNumericData = "WATERSKU-12356";

// Encode text to QR
QrCode qrForText = QrWriter.Write(textToEncode);
AnyBitmap imageForText = qrForText.Save();
imageForText.SaveAs("helloWorldQr.png");

// Encode a URL to QR
QrCode qrForUrl = QrWriter.Write(websiteUrl);
AnyBitmap imageForUrl = qrForUrl.Save();
imageForUrl.SaveAs("websiteQr.png");

// Encode alphanumeric data to QR
QrCode qrForAlphanumeric = QrWriter.Write(alphaNumericData);
AnyBitmap imageForAlphanumeric = qrForAlphanumeric.Save();
imageForAlphanumeric.SaveAs("alphaNumQr.png");
```

### Binary Data & Streams

IronQR simplifies the conversion of binary data into QR codes using the `Write` method. This method is compatible with byte arrays and stream inputs for versatile QR generation.

```cs
using IronQr;
using IronSoftware.Drawing;
using System.Text;

byte[] exampleBytes = Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/qr/");
QrCode qrFromBytes = QrWriter.Write(exampleBytes);
AnyBitmap imageFromBytes = qrFromBytes.Save();
imageFromBytes.SaveAs("binaryDataQr.png");
```

```cs
using IronQr;
using IronSoftware.Drawing;
using System.IO;
using System.Text;

// Stream example
byte[] dataForStream = { 0x01, 0x02, 0x03, 0x04 };
using (MemoryStream memoryStream = new MemoryStream(dataForStream))
{
    QrCode qrFromStream = QrWriter.Write(memoryStream);
    AnyBitmap imageFromStream = qrFromStream.Save();
    imageFromStream.SaveAs("streamDataQr.png");
}
```

---

## Assessing Fault Tolerance 

IronQR's extensive suite also prominently includes robust debugging and error-handling capabilities to complement its flexibility in file formats and customizations. This toolkit empowers developers with essential functionalities to manage exceptions effectively and to implement unit tests that ensure application reliability and robustness.

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

IronQR delivers an extensive array of functionalities for the creation and customization of QR codes within .NET applications. Featuring a robust set of features, this library enables developers to effortlessly generate QR codes with diverse data encodings, stylistic preferences, and various levels of error correction. Its capability to support multiple file formats and integrate smoothly into existing documents enhances its utility as a comprehensive tool for any QR code-related initiatives. Whether the requirement is for straightforward QR codes or complex, customized designs, IronQR is equipped to provide efficient and effective solutions tailored to your specific needs.

For additional information, explore the [IronQR documentation](https://ironsoftware.com/csharp/qr/docs/), begin experimenting with a [free trial](https://ironsoftware.com/csharp/qr/trial-license), and evaluate the [licensing options](https://ironsoftware.com/csharp/qr/licensing/) available to determine the best fit for your projects.

