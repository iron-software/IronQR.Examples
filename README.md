![Nuget](https://img.shields.io/nuget/v/IronQR?color=informational&label=latest)![Installs](https://img.shields.io/nuget/dt/IronQR?color=informational&label=installs&logo=nuget)![Passed](https://img.shields.io/badge/build-%20%E2%9C%93%20522%20tests%20passed%20(0%20failed)%20-107C10?logo=visualstudio)[![livechat](https://img.shields.io/badge/Live%20Chat-8%20Engineers%20Active%20Today-purple?logo=googlechat&logoColor=white)](https://ironsoftware.com/csharp/qr/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield#helpscout-support)

## Introducing IronQR: Your C# QR Code Solution

[![IronQR NuGet Trial Banner Image](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronQR-readme/nuget-trial-banner.png)](https://ironsoftware.com/csharp/qr/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topbanner#trial-license)

Designed by Iron Software, IronQR is a robust library for C# developers enabling the detection, reading, and generation of QR Codes within .NET applications and websites, utilizing a state-of-the-art custom Machine Learning model.

#### Key capabilities of IronQR include:

  * Barcode Detection and Reading from Images or Scans
  * Custom QR Code Creation with Logos and Personalized Colors

#### IronQR is compatible across multiple platforms:

  * **.NET 8**, .NET 7, .NET 6 and .NET 5, Core 2x & 3x, Standard 2, and Framework 4.6.2+
  * Supports Windows, macOS, Linux, iOS, Android, Docker, Azure, AWS

[![IronQr Cross Platform Compatibility Support Image](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronQR-readme/cross-platform-compatibility.png)](https://ironsoftware.com/csharp/qr/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=crossplatformbanner)

Our comprehensive [API reference](https://ironsoftware.com/csharp/qr/object-reference/api/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs) and [complete licensing details](https://ironsoftware.com/csharp/qr/licensing/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs#trial-license) are readily accessible on our website.

### Getting Started with IronQR

To install the IronQR NuGet package, simply run the following command:

    PM> Install-Package IronQR
    

After installation, integrate IronQR by adding `using IronQr;` at the beginning of your C# code. Below are some sample and advanced examples to help you get started:

    using IronQr;
    using IronSoftware.Drawing;
    
    // Creating a QR Code
    QrCode myQr = QrWriter.Write("hello world"); // String embedded in QR
    AnyBitmap qrBitmap = myQr.Save(); // Bitmap object ready for exporting
    qrBitmap.SaveAs("qr.png"); // Save QR image to disk
    
    // Reading a QR Code
    var qrReader = new QrReader(settings: optionalQrReaderSettings); // Instantiate reader
    IEnumerable<QrResult> results = qrReader.Read(new QrImageInput("image.jpg")); // Process image to find QR
    IEnumerable<QrResult> asyncResults = await qrReader.ReadAsync(new QrImageInput("image.jpg")); // Async operation
    
    // Advanced QR Code Creation
    var optionalOptions = new QrOptions(QrErrorCorrectionLevel.High, 20); // Enhanced QR Creation settings
    
    QrCode myQr = QrWriter.Write("hello world", options: optionalOptions); // Generate QR with specific options
    
    var fancyBrandedQrSettings = new QrStyleOptions // Branding and styling options
    {
        Dimensions = 300, // size in px
        Margins = 10, // margin in px
        Color = Color.Black,
        Logo = new QrLogo
        {
            Bitmap = new AnyBitmap(new Uri("website.com/image.svg")),
            Width = 50,
            Height = 50,
            CornerRadius = 2
        }
    };
    AnyBitmap qrWithBranding = myQr.Save(fancyBrandedQrSettings);
    qrWithBranding.SaveAs("qr_fancy.png");
    

### Feature Highlights

##### Advanced QR Code Detection:

  * Proprietary Machine Learning Model optimizes monthly for enhanced detection 
  * Efficient scanning bypasses background noise
  * Precise QR Code interpretation with built-in Error Correction

##### QR Code Reading Features:

  * Supports numerous image formats and system objects
  * Image optimization filters like Contrast and Binarize for clearer results
  * Asynchronous and Multithreading capabilities, plus a lightweight detection mode

##### QR Code Writing Capabilities:

  * Broad document format support including images and web formats
  * Embed various data types: Text, URLs, IDs, numbers, and binary data
  * Customizable QR Code styles: Resize, modify borders, adjust colors, and integrate logos

### Licensing & Support Options

To explore code examples, tutorials, and detailed documentation, visit [Iron Software's QR Code library page](https://ironsoftware.com/csharp/qr/).

For direct support, reach out to us at support@ironsoftware.com

### Documentation Resources

  * API Reference: [API documentation](https://ironsoftware.com/csharp/qr/object-reference/api/)
  * Licensing Information: [License Details](https://ironsoftware.com/csharp/qr/licensing/)

Contact our development team at support@ironsoftware.com for personalized assistance on licensing and extensive support for your commercial project deployments.