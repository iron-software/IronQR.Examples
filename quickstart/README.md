# Introduction to IronQR

***Based on <https://ironsoftware.com/docs/docs/>***


## Overview of IronQR: The QR Code Processing Library for .NET

**IronQR** stands as Iron Software’s specialized library designed for both creating and reading QR codes. It boasts a state-of-the-art Machine Learning Model and supports various platforms including Mobile, Desktop, and Cloud, ensuring seamless QR code detection and generation.

### System and Framework Support

**IronQR** provides comprehensive compatibility across multiple platforms:

#### Supported .NET Versions:

- **C#**, **VB.NET**, **F#**
- **.NET 7, 6**, 5, and Core 3.1+
- .NET Standard (2.0+)
- .NET Framework (4.6.2+)

#### Supported Operating Systems and Environments:

- **Windows** (10+, Server 2016+)
- **Linux** (Ubuntu, Debian, CentOS, etc.)
- **macOS** (10+)
- **iOS** (12+)
- **Android** API 21+ (v5 "Lollipop")
- **Docker** (Windows, Linux, Azure)
- **Azure** (VPS, WebApp, Function)
- **AWS** (EC2, Lambda)

#### Supported .NET Project Types:

- **Web** (Blazor & WebForms)
- **Mobile** (Xamarin & MAUI)
- **Desktop** (WPF & MAUI)
- **Console** (App & Library)

## Setting Up IronQR

### Main IronQR Library

The process to incorporate IronQR into your project is straightforward. Utilize the following command to install the library:

```shell
Install-Package IronQR
```

Or, directly acquire it from the [official NuGet repository for IronQR](https://www.nuget.org/packages/IronQR).

After installation, include `using IronQR;` in your C# code to begin using the library.

### IronQR.Slim Version

For a more streamlined version, `IronQR.Slim` offers basic QR code generation and reading facilities. While the main `IronQR` package includes advanced features like custom Machine Learning Models, `IronQR.Slim` is available for those preferring a smaller package without enhanced detection capabilities. Install the slim package using:

```shell
Install-Package IronQR.Slim
```

## Practical Examples

### Example of Generating a QR Code

```csharp
using IronQr;
using IronSoftware.Drawing;

// Initialize a QR Code generator
QrCode myQrCode = QrWriter.Write("hello world");

// Convert QR Code to a Bitmap object
AnyBitmap qrBitmap = myQrCode.Save();

// Export the Bitmap as a PNG file
qrBitmap.SaveAs("qr.png");
```

### Example of Reading a QR Code

```csharp
using IronQr;
using IronSoftware.Drawing;
using System.Collections.Generic;

// Load the image for QR code detection
var sourceImage = AnyBitmap.FromFile("IMAGE_TO_READ.png");

// Assign the image to the QR Reader
QrImageInput qrInput = new QrImageInput(sourceImage);

// Instantiate a QR code reader
QrReader qrReader = new QrReader();

// Execute reading and retrieve QR Codes
IEnumerable<QrResult> foundQrCodes = qrReader.Read(qrInput);
```

## Additional Information & Support

### Further Information

Visit the Iron Software homepage for more details: [Iron Software](https://ironsoftware.com/)

### Technical Support

For assistance and general queries, please contact Iron Software via email at: [support@ironsoftware.com](mailto:support@ironsoftware.com)