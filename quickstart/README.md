# Getting Started with IronQR

***Based on <https://ironsoftware.com/docs/docs/>***


## IronQR: The QR Code Generator and Reader for .NET

**IronQR** offers a robust library from Iron Software, specialized in both generating and decoding QR Codes. Leveraging an advanced Machine Learning model, it ensures optimal performance across various platforms including Mobile, Desktop, and Cloud environments.

### System Requirements

**IronQR** supports a wide range of platforms which include:

#### .NET Version Compatibility:
- **C#**, **VB.NET**, **F#**
- **.NET 7, 6**, 5, and Core 3.1+
- .NET Standard (2.0+)
- .NET Framework (4.6.2+)

#### Supported Operating Systems and Environments:
- **Windows** (10+, Server 2016+)
- **Linux** (Ubuntu, Debian, CentOS, etc.)
- **macOS** (Version 10+)
- **iOS** (Version 12+)
- **Android** API 21+ (Version 5 "Lollipop")
- **Docker** (Compatible with Windows, Linux, Azure setups)
- **Azure** (VPS, WebApp, Function facilities)
- **AWS** (EC2, Lambda configurations)

#### .NET Project Types Coverage:
- **Web** (Blazor & WebForms)
- **Mobile** (Xamarin & MAUI)
- **Desktop** (WPF & MAUI)
- **Console** (Applications & Libraries)

## Installation Process

### Installing the IronQR Library

To install the IronQR library, use the following command in your package manager:

```shell
Install-Package IronQR
```

You can also access it directly on the [NuGet website for IronQR](https://www.nuget.org/packages/IronQR).

After installation, include `using IronQR;` at the beginning of your C# files to start utilizing the library.

### IronQR.Slim Description

The IronQR.Slim version focuses on QR Code Generation and basic QR Code Reading capabilities.

While it lacks the comprehensive Machine Learning model and its adapters present in the full `IronQR` package, **IronQR.Slim** is an excellent alternative for those looking to maintain a smaller package footprint without the enhanced detection capabilities. To install the slim version, enter the following:

```shell
:InstallCmd Install-Package IronQR.Slim
```



## Sample Code Usage

### Example: Generating a QR Code

```csharp
using IronQr;
using IronSoftware.Drawing;

// Initialize a new QR Code object
QrCode myQr = QrWriter.Write("hello world");

// Convert QR Code to a Bitmap image
AnyBitmap qrImage = myQr.Save();

// Output the QR Code Bitmap as a file
qrImage.SaveAs("qr.png");
```

### Example: Reading a QR Code

```csharp
using IronQr;
using IronSoftware.Drawing;
using System.Collections.Generic;

// Load an image file to decode QR Codes from
var inputBmp = AnyBitmap.FromFile("IMAGE_TO_READ.png");

// Prepare the image for QR decoding
QrImageInput imageInput = new QrImageInput(inputBmp);

// Instantiate a QR Code reader
QrReader reader = new QrReader();

// Decode the QR Codes embedded in the image
IEnumerable<QrResult> results = reader.Read(imageInput);
```

## Support Information

### General Information

For additional details about Iron Software, please head to our official site: <https://ironsoftware.com/>

### Customer Support

For any support or technical questions, feel free to contact us via email at: <mailto:support@ironsoftware.com>