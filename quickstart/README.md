# Getting Started with IronQR

***Based on <https://ironsoftware.com/docs/docs/>***


## IronQR: The QR Code Solution for .NET Applications

**IronQR** from Iron Software is your comprehensive solution for reading and writing QR codes. This library leverages a sophisticated Machine Learning Model to read QR codes, supporting a variety of platforms including Mobile, Desktop, and Cloud.

### Compatibility

IronQR is compatible with a wide range of environments across different platforms:

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

## Installation

### IronQR Library

To install the IronQR library is straightforward. Execute the following command:

```shell
Install-Package IronQR
```

You can also download it directly from [IronQR's official NuGet page](https://www.nuget.org/packages/IronQR).

Begin by adding `using IronQR;` in your C# project to introduce QR functionalities.

### IronQR.Slim Library

For users that prefer a lighter package without the advanced Machine Learning capabilities for QR reading, IronQR.Slim is the best option. It supports basic QR code generation and reading:

```shell
Install-Package IronQR.Slim
```

Choosing IronQR.Slim won’t impact QR generation but will limit QR reading with simpler detection capabilities.

## Code Examples

### Generating a QR Code

```csharp
using IronSoftware.Drawing;
using IronQR;
namespace ironqr.Quickstart
{
    public class Section1
    {
        public void Run()
        {
            // Instantiate a QR Code with the desired content
            QrCode myQr = QrWriter.Write("hello world");
            
            // Generate a Bitmap of the QR Code
            AnyBitmap qrImage = myQr.Save();
            
            // Output the QR Code Bitmap to a File
            qrImage.SaveAs("qr.png");
        }
    }
}
```

### Reading a QR Code

```csharp
using System.Collections.Generic;
using IronQR;
namespace ironqr.Quickstart
{
    public class Section2
    {
        public void Run()
        {
            // Read a QR Code from an image file
            var inputBmp = AnyBitmap.FromFile("IMAGE_TO_READ.png");
            
            // Load the bitmap for QR analysis
            QrImageInput imageInput = new QrImageInput(inputBmp);
            
            // Initialize a QR Code reader
            QrReader reader = new QrReader();
            
            // Decode the image to find QR content
            IEnumerable<QrResult> results = reader.Read(imageInput);
        }
    }
}
```

## Support Resources

### More Information

For detailed information about Iron Software and its products, visit our [website](https://ironsoftware.com/).

### Customer Support

For assistance or technical queries, you can reach out to us via email at: [support@ironsoftware.com](mailto:support@ironsoftware.com)