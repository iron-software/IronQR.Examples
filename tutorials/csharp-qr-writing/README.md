# Generate QR Codes in C&num;

***Based on <https://ironsoftware.com/tutorials/csharp-qr-writing/>***


## Overview

IronQR empowers developers to craft QR codes supported by a variety of image formats and allows for personalization through background colors, margins, logos, and integration into PDFs. Additionally, it provides advanced features for adjusting error correction and QR code versions.

In this guide, we'll cover the essential functionalities of IronQR, demonstrate its capabilities through examples, and discuss how to leverage these features in your C# projects properly.

## Contents

- **Input Data Handling**
  - [Text, URLs, Numerical Data](#anchor-text-urls-numbers)
  - [Binary Data and Streams](#anchor-binary-streams)
- **Output QR Codes**
  - [Image File Saving](#anchor-save-as-image)
  - [Utilizing System.Drawing.Images](#anchor-system-drawing-images)
  - [Using IronSoftware.Drawing](#anchor-ironsoftware-drawing)
  - [Embedding in PDFs](#anchor-stamp-on-pdf)
- **Configuration of QR Codes**
  - [Encoding Methods](#anchor-encoding)
  - [Error Handling](#anchor-error-correction)
  - [Selecting QR Code Versions](#anchor-qr-code-version)
  - [Character Encoding Options](#anchor-character-encoding)
- **Customizing QR Code Appearance**
  - [Adjusting Size](#anchor-resize)
  - [Setting Margins and Borders](#anchor-margins-borders)
  - [Changing Colors](#anchor-recolor)
  - [Incorporating a Logo](#anchor-add-a-logo)

## Introduction

IronQR enables developers to generate QR codes in various popular image formats while providing options for customization like background colors, margins, logos, and integration into PDF files. For those needing more sophisticated features, IronQR also allows detailed control over error correction and QR code versions.

In this guide, we will delve into the essential functionalities of IronQR, showcasing examples to demonstrate how you can utilize this tool to create QR codes in C# and effectively incorporate it into your development projects.

## Contents Summary

- **Input Data**
  - [Text, URLs, Numbers](#anchor-text-urls-numbers)
  - [Binary & Streams](#anchor-binary-streams)

- **Export QR Codes**
  - [Image Saving Options](#anchor-save-as-image)
  - [System.Drawing.Images Integration](#anchor-system-drawing-images)
  - [Utilizing IronSoftware.Drawing](#anchor-ironsoftware-drawing)
  - [PDF Stamp Features](#anchor-stamp-on-pdf)

- **QR Code Configuration**
  - [Encoding Techniques](#anchor-encoding)
  - [Error Correction Levels](#anchor-error-correction)
  - [Selecting QR Code Versions](#anchor-qr-code-version)
  - [Character Encoding Settings](#anchor-character-encoding)

- **Designing QR Codes**
  - [Resize Functionality](#anchor-resize)
  - [Setting Margins & Borders](#anchor-margins-borders)
  - [Recoloring Options](#anchor-recolor)
  - [Logo Integration](#anchor-add-a-logo)

## Input Data

### Text, URLs, Numbers

IronQR adeptly transforms a variety of data formats, such as text, URLs, and numerical codes, into QR codes, making it an invaluable tool for diverse applications like marketing, inventory management, and data transmission. The API is streamlined, featuring the `QrWriter` class which supports several input formats, simplifying the coding process and enhancing productivity.

```cs
using IronQr;
using IronSoftware.Drawing;

// Define data to encode
string text = "Hello, World!";
string url = "https://ironsoftware.com/csharp/qr/";
string alphanumeric = "WATERSKU-12356";

// Generate QR codes for each type of data
QrCode textQr = QrWriter.Write(text);

// Convert to bitmap and save
AnyBitmap textQrImage = textQr.Save();
textQrImage.SaveAs("textQr.png");

QrCode urlQr = QrWriter.Write(url);
AnyBitmap urlQrImage = urlQr.Save();
urlQrImage.SaveAs("urlQr.png");

QrCode alphanumericQr = QrWriter.Write(alphanumeric);
AnyBitmap alphanumericQrImage = alphanumericQr.Save();
alphanumericQrImage.SaveAs("alphanumericQr.png");
```

### Binary Data and Streams

IronQR also includes functionality to encode binary data and streams to QR codes using the `Write` method seen before, extending versatility across different data handling needs.

```cs
using IronQr;
using IronSoftware.Drawing;
using System.Text;

// Encoding URL as byte array
byte[] bytes = Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/qr/");

// QR code generation for binary data
QrCode bytesQr = QrWriter.Write(bytes);

// Save as bitmap and then as a file
AnyBitmap qrImage = bytesQr.Save();
qrImage.SaveAs("bytesQr.png");
```

When handling streams, converting a byte array to a `MemoryStream` and then encoding it into a QR code bridges the gap between data security and memory efficiency.

```cs
using IronQr;
using IronSoftware.Drawing;
using System.IO;
using System.Text;

// Prepare memory stream from byte array
MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/qr/"));

// Generate and save QR code from binary stream
QrCode streamQr = QrWriter.Write(stream);
AnyBitmap streamQrImage = streamQr.Save();
streamQrImage.SaveAs("streamQr.png");
```

### Text, URLs, Numbers

IronQR excels in transforming various data forms, such as text, URLs, and numerical values, into QR codes. Whether your goal is to develop QR code links for promotional purposes, encode textual messages for communications, or generate numeric codes for inventory systems, IronQR offers comprehensive support for all these needs.

Moreover, the API is designed for ease of use. The `QrWriter` class provides numerous method overloads, which allow for the incorporation of diverse data types as inputs. This reduces the complexity and facilitates a more streamlined coding experience.

```cs
using IronQr;
using IronSoftware.Drawing;

string message = "Hello, World!";
string website = "https://ironsoftware.com/csharp/qr/";
string code = "WATERSKU-12356";

// Generate a QR code from a simple text message
QrCode qrCodeForText = QrWriter.Write(message);
// Convert the QR code to a bitmap image
AnyBitmap qrBitmapFromText = qrCodeForText.Save();
// Output the bitmap image as a PNG file
qrBitmapFromText.SaveAs("helloWorldQr.png");

// Generate a QR code from a URL
QrCode qrCodeForUrl = QrWriter.Write(website);
// Convert the QR code to a bitmap image
AnyBitmap qrBitmapFromUrl = qrCodeForUrl.Save();
// Output the bitmap image as a PNG file
qrBitmapFromUrl.SaveAs("websiteQr.png");

// Generate a QR code from alphanumeric data
QrCode qrCodeForCode = QrWriter.Write(code);
// Convert the QR code to a bitmap image
AnyBitmap qrBitmapFromCode = qrCodeForCode.Save();
// Output the bitmap image as a PNG file
qrBitmapFromCode.SaveAs("codeQr.png");
```

### Binary Data and Streams Conversion

Likewise, using the previously mentioned `Write` method allows for the transformation of both binary data and streams into QR codes. This seamless process ensures you can handle various data types effectively for QR code generation.

```cs
using IronQr;
using IronSoftware.Drawing;
using System.Text;

// Convert the URL string to a byte array
byte[] dataBytes = Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/qr/");

// Generate a QR code from the byte array
QrCode encodedQr = QrWriter.Write(dataBytes);

// Convert the QR code into a bitmap image
AnyBitmap bitmapImage = encodedQr.Save();

// Export the QR code image to a PNG file
bitmapImage.SaveAs("encodedBytesQr.png");
```

The `Write` method provides versatility by supporting both byte arrays and streams. You can initiate a `MemoryStream` using a byte array to generate a QR code efficiently. This approach is particularly advantageous for handling data segments precisely and conserving memory.

Here's the paraphrased section of code:

```cs
// Import necessary namespaces for QR code generation
using IronQr;
using IronSoftware.Drawing;
using System.IO;
using System.Text;

// Convert a URL string into a memory stream
byte[] urlBytes = Encoding.UTF8.GetBytes("https://ironsoftware.com/csharp/qr/");
MemoryStream urlStream = new MemoryStream(urlBytes);

// Generate a QR code from the memory stream
QrCode qrCodeFromStream = QrWriter.Write(urlStream);

// Convert the QR code into a bitmap image
AnyBitmap bitmapFromQrCode = qrCodeFromStream.Save();

// Store the QR code bitmap as a PNG file
bitmapFromQrCode.SaveAs("streamQr.png");
```

<hr>

## Exporting QR Codes

IronQR accommodates a variety of scenarios, offering the ability to store QR codes in diverse file formats including JPG, PNG, GIF, and TIFF. This flexibility is made possible through the use of the `SaveAs` method, catering to different requirements for file types.

### Saving an Image

The `SaveAs` method in the **AnyBitmap** class can automatically identify the file format by looking at the file name extension you specify, such as .png for PNG images.

It's important to remember that `SaveAs` doesn't have a predetermined image format. If the file extension you provide is unrecognized or misspelled, the file will be saved with that erroneous extension.

```cs
using IronQr;
using IronSoftware.Drawing;

// Initialize a new QR code with "hello world" as the content
QrCode myQrCode = QrWriter.Write("hello world");

// Generate an image representation of the QR code
AnyBitmap qrCodeImage = myQrCode.Save();

// Output the QR code image to a PNG file
qrCodeImage.SaveAs("qr.png");
```

### System.Drawing.Images

When transforming images into the **System.Drawing.Images** object provided by Microsoft, you gain access to the **Bitmap** class, which facilitates the saving of QR codes directly to a specified file path. In the demonstration below, we utilize the `Save` method to store the QR code in the PNG format under the filename 'qrBitmap.png.'

It's important to note that **System.Drawing.Common** has compatibility limited exclusively to the Windows operating system.

```cs
using IronQr;
using System.Drawing;

// Initialize a QR code instance
QrCode qrCodeInstance = QrWriter.Write("hello world");

// Convert the QR code to a bitmap
Bitmap bitmapOfQr = qrCodeInstance.Save();

// Store the bitmap image to a file
bitmapOfQr.Save("qrBitmap.png");
```

### IronSoftware.Drawing Integration

The **System.Drawing.Common** library, while widely used, presents challenges with cross-platform compatibility, which can complicate the maintenance of applications across different operating systems. To address this, IronQR empowers developers by supporting both **System.Drawing.Common** and the versatile **IronSoftware.Drawing**.

IronQR leverages the robust **AnyBitmap** class from [IronSoftware.Drawing](https://ironsoftware.com/open-source/csharp/drawing/docs/), which is designed to be universally compatible. This class seamlessly integrates with various bitmap types, including:

- System.Drawing.Bitmap
- System.Drawing.Image
- SkiaSharp.SKBitmap
- SixLabors.ImageSharp
- Microsoft.Maui.Graphics.Platform.PlatformImage

Thanks to this comprehensive open-source library, IronQR provides extensive support across a multitude of platforms, including .NET 8, .NET 7, .NET 6, .NET 5, .NET Core, .NET Standard, and .NET Framework 4.6.2 and above. For detailed information about IronSoftware.Drawing, visit the [IronSoftware.Drawing website](https://ironsoftware.com/open-source/csharp/drawing/).

### Embedding QR Codes in PDFs

IronQR empowers developers to embed QR codes into existing PDF files, enhancing access to URLs or supplementary information. This feature supports embedding on a single page or across multiple pages.

#### Stamping a QR Code onto a Single PDF Page

Upon generating your QR code, utilize the `StampToExistingPdfPage` method accessible through the **QrCode** class. This function mandates specifics such as the file path, x and y coordinates on the page, and the page number to which the QR code will be applied. Should your PDF require a password for modifications, this can also be included. Following the provision of these details, the QR is seamlessly stamped onto the specified page of the PDF document.

It's important to note that the page indexing for this method begins at 1, ensuring the first page is not overlooked as would be the case with zero-based indexing.

```cs
// Import the IronQr namespace to work with QR codes
using IronQr;

// Initialize a new QR code
QrCode myQrCode = QrWriter.Write("hello world");

// Define the path of the PDF file
string targetPdfPath = "example.pdf";
// Set coordinates for the QR code's placement on the PDF
int xPos = 100;
int yPos = 150;
// Specify the page number where the QR code will be stamped
int targetPage = 1;

// Apply the QR code onto the specified page of the PDF document
myQrCode.StampToExistingPdfPage(targetPdfPath, xPos, yPos, targetPage);
```

#### Stamping on Multiple PDF Pages

As previously discussed, the key distinction here is that the `StampToExistingPdfPages` method accepts a collection of page numbers, allowing for the stamping of a QR code across multiple pages rather than just one.

```cs
using IronQr;
using System.Collections.Generic;

// Initialize a new QR code
QrCode myQrCode = QrWriter.Write("hello world");

// Define the PDF file path and position for stamping
string targetPdf = "example.pdf";
int posX = 100;
int posY = 150;
List<int> pageList = new List<int> {1, 2, 3, 4};

// Apply the QR code stamp to specified pages in the PDF
myQrCode.StampToExistingPdfPages(targetPdf, posX, posY, pageList);
```

#### Example Outputs

![alt text](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-writing/stamptoexistingpdfexample.gif)

<hr>

## QR Code Configuration Options

IronQR is equipped with a wealth of configuration settings, allowing you to fine-tune the behavior and functionality of QR codes to suit specific needs. Utilizing the **QrOptions** class, developers can adjust various settings including the version of the QR code, the type of encoding, character encoding specifics, and levels of error correction. These configurations are further explored below to give you a better understanding of how they can enhance your QR code generation tasks.

### Encoding Options in IronQR

IronQR is designed to accommodate different QR code formats for both creation and scanning. Here are the formats supported:

- **QRCode**: This standard QR code is widely recognized and utilized. It has the capacity to hold up to 7,089 numeric characters or 4,296 alphanumeric characters.
  
- **MicroQRCode**: This is a compact variant of the regular QR code, capable of storing up to 35 numeric characters or 21 alphanumeric characters.
  
- **RMQRCode**: Known as the Rectangular Micro QR Code, this format provides a compact QR code solution with adjustable aspect ratios, making it versatile for various applications.

```cs
using IronQr;
using IronSoftware.Drawing;

// Configure QR code creation options
QrOptions qrSettings = new QrOptions
{
    // Set the QR code type to MicroQRCode
    Encoding = IronQr.Enum.QrEncoding.MicroQRCode,
};

// Generate a MicroQR code storing "1234"
QrCode microQrCode = QrWriter.Write("1234", qrSettings);

// Convert the generated QR code to a bitmap
AnyBitmap bitmapImage = microQrCode.Save();

// Store the bitmap image as a PNG file
bitmapImage.SaveAs("qrImage.png");
```

### Error Correction

IronQR implements robust error correction to guarantee the reliability and readability of QR codes under various environmental conditions. To tailor QR codes to specific needs, IronQR enables the adjustment of error correction levels.

The **QrErrorCorrectionLevel** provides four distinct levels of error correction to choose from:

- **Highest**: Ensures maximum durability with 30% error correction capacity
- **High**: Offers high resilience with 25% error correction
- **Medium**: Provides a balanced option with 15% error correction
- **Low**: Optimal for maximum data capacity with 7% error correction

Below is the paraphrased section from the article, concerning the generation and saving of a QR code with medium error correction using IronQR:

```cs
// Include necessary namespaces from Iron Software for QR code generation and image processing.
using IronQr;
using IronSoftware.Drawing;

// Configure options for the QR code, setting the error correction level to medium.
QrOptions qrOptions = new QrOptions
{
    // Modifies the QR code's error correction to medium, providing balanced fault tolerance.
    ErrorCorrectionLevel = QrErrorCorrectionLevel.Medium,
};

// Generate a QR code with the specific settings.
QrCode generatedQrCode = QrWriter.Write("1234", qrOptions);

// Convert the QR code into a bitmap image.
AnyBitmap bitmapImage = generatedQrCode.Save();

// Output the QR code image to a file.
bitmapImage.SaveAs("qrImage.png");
```

In this rewritten segment, extra explanatory comments are added, providing clarity on each operation within the code block, making it easier for developers to understand the functionality.

Enhanced error correction levels in QR codes significantly improve their reliability, particularly in environments where they might be scanned at lower resolutions. By opting for a higher error correction setting, QR codes become more resilient and easier to decode accurately, even if they are not perfectly clear. Tailoring the error correction level to specific requirements or scenarios in your applications can be highly beneficial.

![alt text](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-writing/correctionlevels.jpg)

### Adjusting QR Code Versions

The version of a QR code determines its data capacity. For applications requiring extensive information, such as logistics or inventory tracking, higher version codes are recommended. Conversely, compact data like short URLs function well with lower version codes. This adjustment can be managed by modifying the `Version` property within the `QrOptions` class and then invoking the `Write` method to produce the desired QR code.

```cs
using IronQr;
using IronSoftware.Drawing;

// Configure QR code options with a high version setting
QrOptions highVersionOptions = new QrOptions
{
    // Set the QR code version to 40 for larger data capacity
    Version = 40,
};

// Generate a QR code using the specified settings
QrCode highVersionQr = QrWriter.Write("1234", highVersionOptions);

// Convert the generated QR code into a bitmap image
AnyBitmap highVersionQrBitmap = highVersionQr.Save();

// Export and save the bitmap as a PNG file
highVersionQrBitmap.SaveAs("qrImage.png");
```

![alt text](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-writing/versionDifference.jpg)

From the image, it's evident that version 40 QR codes are considerably more intricate and compact than version 5.

Smaller version QR codes demand higher precision during scanning and may pose challenges if scanned with basic equipment. Conversely, the larger version QR codes are more user-friendly, offering better readability with less sophisticated scanning technology. To gain further insights into selecting the appropriate QR code version for different data requirements, you can consult the detailed [QR version list](https://www.qrcode.com/en/about/version.html) available online.

### Character Encoding

This setting specifies the encoding scheme for the QR code. For instance, we have modified the encoding to 'UTF-32' in this illustration, whereas the default setting is 'ISO-8859-1.'

Here's the paraphrased content with the markdown and links resolved to `ironsoftware.com`.

```cs
using IronQr;
using IronSoftware.Drawing;

// Set up options for encoding the QR code
QrOptions encodingOptions = new QrOptions
{
    // Specify UTF-32 for character encoding
    CharacterEncoding = "UTF-32"
};

// Generate the QR code with specified options
QrCode generatedQrCode = QrWriter.Write("1234", encodingOptions);

// Convert the QR code into a bitmap image
AnyBitmap qrBitmap = generatedQrCode.Save();

// Output the QR code bitmap to a png file
qrBitmap.SaveAs("qrImage.png");
```

<hr>

## Styling QR Codes with IronQR

IronQR not only simplifies the process of QR code generation but also provides extensive measures for customization, allowing you to style QR codes in a manner that makes them distinct and aligned with your brand or requirements. The `QrStyleOptions` class is at the heart of these customizing capabilities, offering a broad range of parameters to modify the appearance of QR codes. Here, we delve into these styling possibilities.

### Adjusting QR Code Size

To modify the size of the QR code, adjust the `Dimensions` property within the `QrStyleOptions` object. This adjustment is then applied in the `Save` method. Normally, the default dimension is 300 pixels. In the provided example, the dimension is increased to 600 pixels, doubling the standard size.

```cs
using IronQr;
using IronSoftware.Drawing;

// Define the style options for the QR code
QrStyleOptions qrStyle = new QrStyleOptions()
{
    // Set the size to 600 pixels
    Dimensions = 600,
};

// URL to encode in the QR code
string targetUrl = "https://ironsoftware.com/csharp/qr/";

// Generate the QR code
QrCode newQrCode = QrWriter.Write(targetUrl);

// Retrieve the QR code as a bitmap image
AnyBitmap qrImageBitmap = newQrCode.Save(qrStyle);

// Store the QR code image in a PNG file
qrImageBitmap.SaveAs("qrURLResized.png");
```

![alt text](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-writing/resizeQRexample.jpg)

### Margins and Borders

For modifying the margins and borders of a QR code, the `Margins` attribute in the `QrStyleOptions` class is utilized. This feature regulates the QR code's margins on every edge, where the default margin is set to 10px. In the demonstrated scenario, the margins have been increased to 20px.

```cs
using IronQr;
using IronSoftware.Drawing;

// Define style options with customized margins
QrStyleOptions styleOpts = new QrStyleOptions()
{
    // Set margins to 20 pixels
    Margins = 20
};

string url = "https://ironsoftware.com/csharp/qr/";

// Generate a QR code from URL
QrCode qrCode = QrWriter.Write(url);

// Convert QR code to a bitmap utilizing the styling options
AnyBitmap bitmapImage = qrCode.Save(styleOpts);

// Export the QR code bitmap to a file
bitmapImage.SaveAs("qrURLMarginMultiple.png");
```

![alt text](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-writing/qrMarginmultiple.jpg)

#### Customize Margins Individually

IronQR gives users the ability to set distinct margins for each side of the QR code, offering more detailed customization options.

Here's the paraphrased and enhanced section of the code:

```cs
using IronQr;
using IronSoftware.Drawing;

// Setting custom margin sizes for QR code
QrStyleOptions options = new QrStyleOptions()
{
    MarginTop = 100,       // top margin of 100px
    MarginBottom = 30,     // bottom margin of 30px
    MarginRight = 40,      // right margin of 40px
    MarginLeft = 20        // left margin of 20px
};

// Define the URL to encode in the QR code
string targetUrl = "https://ironsoftware.com/csharp/qr/";

// Generate the QR code from the URL
QrCode customMarginQr = QrWriter.Write(targetUrl);

// Render the QR code into a bitmap using the custom styling options
AnyBitmap styledQrImage = customMarginQr.Save(options);

// Export the generated QR code as a PNG file with a detailed naming
styledQrImage.SaveAs("customStyledQr.png");
```

In this revised version:
- Variable names are made more descriptive to improve code readability.
- Comments have been added and enhanced to clarify each step's purpose, especially the custom styling application.

### Recoloring QR Codes

The `QrStyleOptions` class allows for the personalization of QR codes by adjusting their color scheme. This feature not only enhances the visual appeal but also helps in branding the QR code distinctly. Modify the foreground and background colors using the `Color` and `BackgroundColor` properties respectively. For a variety of color options, remember to include the `IronSoftware.Drawing` namespace in your project.

```cs
using IronQr;
using IronSoftware.Drawing;

// Setting up the style options for QR code
QrStyleOptions options = new QrStyleOptions {
    BackgroundColor = Color.Blue, // Set background color to blue
    Color = Color.Red             // Set QR code color to red
};

string targetUrl = "https://ironsoftware.com/csharp/qr/";

// Generating the QR code
QrCode generatedQrCode = QrWriter.Write(targetUrl);

// Saving the generated QR code as a bitmap object with custom styles
AnyBitmap qrBitmap = generatedQrCode.Save(options);

// Exporting the styled QR code image to a PNG file
qrBitmap.SaveAs("qrURLColored.png");
```

![alt text](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-writing/qrURLColored.png)

### Incorporate Your Brand's Logo

Adding your brand's logo to a QR code not only enhances its appearance but also instantly makes it identifiable as associated with your brand. Utilizing the **Logo** property simplifies the process of tailoring a QR code to include your company's logo, offering a personalized touch that aligns with your brand identity.

```cs
using IronQr;
using IronSoftware.Drawing;

// Define styling options for QR
QrStyleOptions qrStyle = new QrStyleOptions()
{
    // Set custom colors
    BackgroundColor = Color.Blue, // Set the background to blue
    Color = Color.Red // Set the QR code color to red
};

// URL for the QR code
string targetUrl = "https://ironsoftware.com/csharp/qr/";

// Generating the QR code
QrCode generatedQrCode = QrWriter.Write(targetUrl);

// Converting the QR code to a bitmap image with custom styles
AnyBitmap styledQrImage = generatedQrCode.Save(qrStyle);

// Output the styled QR code image to a file
styledQrImage.SaveAs("customColoredQrCode.png");
```

![alt text](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-writing/qrURLLogo.png)

#### Logo Personalization

Using the `QrLogo` class, there are several properties available to enhance and modify the presentation of a logo within the QR code. The properties include:

- **Bitmap**: This property defines the image to be displayed as the logo.
  
- **Width**: This denotes the width of the logo. It is set to 0 by default, which indicates no predefined width.
  
- **Height**: This marks the height of the logo. Like width, its default value is also 0.
  
- **CornerRadius**: This specifies the corner radius for creating rounded edges on the logo. A default value of 0 means the corners of the logo are sharp and not rounded.

<hr>

## Testing for Robustness

IronQR excels not only in offering a wide range of file format options and customization features but also in robust error-handling capabilities. Developers are equipped with numerous resources through IronQR to manage exceptions effectively and conduct unit testing to ensure the integrity of their applications.

### Checksums

Occasionally, QR codes might sustain damage or errors, yet IronQR incorporates integrated checksums and error correction techniques that maintain their operability. Utilizing the [Reed-Solomon error correction algorithm](https://www.cs.cmu.edu/guyb/realworld/reedsolomon/reed_solomon_codes.html), IronQR ensures the resilience and fault tolerance of QR codes.

### Enhanced Error Reporting

IronQR enhances the troubleshooting process with comprehensive error messages that swiftly pinpoint issues. The library categorizes these issues under specific exceptions, simplifying the debugging and problem resolution steps. Here’s an overview of the primary **IronQrException** categories utilized by IronQR.

- **IronQrEncodingException**: This is a specific type of **IronQrException** that occurs during the QR code generation process. It typically arises if you attempt to generate a QR code from an empty string or invalid content.

  ![alt text](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-writing/nullErrorException.gif)

- **IronQrFileException**: This exception addresses errors related to file operations and is another subclass of **IronQrException**.

- **IronQrPdfPasswordExcception**: When dealing with PDFs that are password-protected, this exception is triggered if an incorrect or no password is provided. It manages other PDF-related complexities as well, such as issues encountered while opening the PDF file.

  ![alt text](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-writing/passwordException.gif)

## Conclusion

IronQR equips developers with a full range of functionalities to generate and tailor QR codes for .NET frameworks. Its strong capabilities allow for the creation of QR codes with different data encodings, aesthetic designs, and levels of error correction. The library's ability to support a variety of file formats and integrate effortlessly into pre-existing documents establishes it as a flexible resource for any QR code application. IronQR caters to all requirements, from simple QR codes to sophisticated, brand-specific configurations, providing the tools necessary for effective and efficient QR code integration.

For additional information, visit the [IronQR documentation](https://ironsoftware.com/csharp/qr/docs/), begin experimenting with a [free trial](https://ironsoftware.com/csharp/qr/#trial-license), and explore the [licensing options](https://ironsoftware.com/csharp/qr/licensing/) to determine the best fit for your project needs.

