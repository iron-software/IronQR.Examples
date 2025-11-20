![Nuget Version](https://img.shields.io/nuget/v/IronQR?color=informational&label=latest)![Installs](https://img.shields.io/nuget/dt/IronQR?color=informational&label=installs&logo=nuget)![Tests Passed](https://img.shields.io/badge/build-%20%E2%9C%93%20522%20tests%20passed%20(0%20failed)%20-107C10?logo=visualstudio)![Windows Supported](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=data:image/svg%2bxml;base64,PHN2ZyByb2xlPSJpbWciIHZpZXdCb3g9IjAgMCAyNCAyNCIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4NCiAgPHRpdGxlPldpbmRvd3M8L3RpdGxlPg0KICA8cGF0aCBmaWxsPSJ3aGl0ZSIgZD0iTTAsMEgxMS4zNzdWMTEuMzcySDBaTTEyLjYyMywwSDI0VjExLjM3MkgxMi42MjNaTTAsMTIuNjIzSDExLjM3N1YyNEgwWm0xMi42MjMsMEgyNFYyNEgxMi42MjMiLz4NCjwvc3ZnPg==)![macOS Supported](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=apple)![Linux Supported](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=linux&logoColor=white)![iOS Supported](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=ios)![Android Supported](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=android&logoColor=white)![Docker Support](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=docker&logoColor=white)[![AWS](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=data:image/svg%2bxml;base64,PHN2ZyByb2xlPSJpbWciIHZpZXdCb3g9IjAgMCAyNCAyNCIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj48dGl0bGU+QW1hem9uIEFXUzwvdGl0bGU+PHBhdGggZmlsbD0id2hpdGUiICAgZD0iTTYuNzYzIDEwLjAzNmMwIC4yOTYuMDMyLjUzNS4wODguNzEuMDY0LjE3Ni4xNDQuMzY4LjI1Ni41NzYuMDQuMDYzLjA1Ni4xMjcuMDU2LjE4MyAwIC4wOC0uMDQ4LjE2LS4xNTIuMjRsLS41MDMuMzM1YS4zODMuMzgzIDAgMCAxLS4yMDguMDcyYy0uMDggMC0uMTYtLjA0LS4yMzktLjExMmEyLjQ3IDIuNDcgMCAwIDEtLjI4Ny0uMzc1IDYuMTggNi4xOCAwIDAgMS0uMjQ4LS40NzFjLS42MjIuNzM0LTEuNDA1IDEuMTAxLTIuMzQ3IDEuMTAxLS42NyAwLTEuMjA1LS4xOTEtMS41OTYtLjU3NC0uMzkxLS4zODQtLjU5LS44OTQtLjU5LTEuNTMzIDAtLjY3OC4yMzktMS4yMy43MjYtMS42NDQuNDg3LS40MTUgMS4xMzMtLjYyMyAxLjk1NS0uNjIzLjI3MiAwIC41N...

## IronQR - Your C# QR Code Solution

### **Seamlessly generate, read, and enhance QR Codes in your .NET projects**

![IronQR NuGet Trial Banner Image](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronQR-readme/nuget-trial-banner.png)

##### IronQR is an advanced library crafted by Iron Software that equips C# developers with the ability to effortlessly generate, interpret, and augment QR Codes within .NET applications and websites using a sophisticated, custom-built Machine Learning model.

### **[Begin Your Journey](https://ironsoftware.com/csharp/qr/docs/) in Three Simple Steps**

#### 1. Install the NuGet Package

```bash
PM> Install-Package IronQR
```

#### 2. Generate Your Initial QR Code

```csharp
using IronQr;
using IronSoftware.Drawing;

// Generating a new QR Code
QrCode qrCode = QrWriter.Write("hello world"); // String value is embedded here
AnyBitmap qrImage = qrCode.Save(); // Converts to Bitmap, can export as bytes or file
qrImage.SaveAs("qr.png"); // Saving to file system

// Reading a QR Code
var qrScanner = new QrReader(settings: optionalQrReaderSettings); // Initializes the QR reader
IEnumerable<QrResult> scanResults = qrScanner.Read(new QrImageInput("image.jpg")); // Uses ML Model for detection and reading
IEnumerable<QrResult> asyncScanResults = await qrScanner.ReadAsync(new QrImageInput("image.jpg")); // Asynchronous read

// Enhancing QR Code creation
var enhancedOptions = new QrOptions(QrErrorCorrectionLevel.High, 20); // Sets advanced generation options

QrCode enhancedQr = QrWriter.Write("hello world", options: enhancedOptions); // Generates QR with specified options

var stylishQrSettings = new QrStyleOptions // Customize with logos, colors, and more
{
    Dimensions = 300, // Size in pixels
    Margins = 10, // Margin in pixels
    Color = Color.Black,
    Logo = new QrLogo
    {
        Bitmap = new AnyBitmap(new Uri("https://ironsoftware.com/image.svg")),
        Width = 50,
        Height = 50,
        CornerRadius = 2
    }
};
AnyBitmap qrStyled = enhancedQr.Save(stylishQrSettings);
qrStyled.SaveAs("qr_stylish.png");
```

#### 3. Delve Deeper

Explore the extensive guides and examples available:

  * **[Tutorials](https://ironsoftware.com/csharp/qr/tutorials/csharp-qr-code-generator/)**: Detailed walkthroughs to launch your first QR Code integration.

  * **[Code Samples](https://ironsoftware.com/csharp/qr/examples/qr-quickstart/)**: Quick, direct code examples for rapid execution and testing.

  * **[How-To Guides](https://ironsoftware.com/csharp/qr/how-to/read-qr-codes-from-image/)**: Direct, solution-focused help for specific operational needs.

  * **[Demo](https://ironsoftware.com/csharp/qr/#booking-demo)**: In-depth demonstrations of how IronQR functions.

  * **[API Reference](https://ironsoftware.com/csharp/qr/object-reference/api/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)**: Comprehensive documentation outlining the IronQR capabilities.

### **Core Features**

  * [**Code Reading**](https://ironsoftware.com/csharp/qr/how-to/read-qr-codes-from-image/): Skillfully decodes QR codes from images and PDFs, even those of subpar quality.

  * [**Code Generation**](https://ironsoftware.com/csharp/qr/how-to/create-qr-code-image/): Enables the creation of customizable QR codes with options for shape, color, and embeddable logos.

  * [**Types of QR Codes**](https://ironsoftware.com/csharp/qr/get-started/supported-qr-formats/): Supports a variety of QR code configurations, such as QR Code, Micro QR Code, and RMQRCode, for diverse application use.

### **Versatility and Compatibility**

#### Constructed for contemporary .NET environments, IronQR supports extensive project types and operating systems.

  * **Platforms Supported**: **.NET 10**, .NET 9, .NET 8, .NET 7, .NET 6, .NET 5, Core 2x & 3x, Standard 2

  * **Operating Systems Supported**: Windows, macOS, Linux (various distributions), iOS, Android

  * **Software Dev Environments**: Microsoft Visual Studio, Jetbrains ReSharper & Rider

  * **Deployment**: Integrated support for environments like Azure, [AWS](https://ironsoftware.com/csharp/qr/get-started/aws/), and Docker

### **Seamlessly Create, Read, and Personalize QR Codes in Your .NET Projects**

[![IronQR NuGet Trial Banner Image](https://ironsoftware.com/iron-nuget-assets/main/IronQR-readme/nuget-trial-banner.png)](https://ironsoftware.com/csharp/qr/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topbanner#trial-license)

##### IronQR is a product created and supported by Iron Software, designed to assist C# developers in identifying, interpreting, and generating QR Codes within .NET environments through an advanced, proprietary Machine Learning algorithm.

### **[Begin Your Journey](https://ironsoftware.com/csharp/qr/docs/) in Three Simple Steps**

Kickstart your .NET project by integrating the capabilities of IronQR in just three concise steps:

#### 1. Install the IronQR NuGet Package

```plaintext
PM> Install-Package IronQR
```

#### 2. Generate and Read Your Initial QR Code

```csharp
using IronQr;
using IronSoftware.Drawing;

// Generating a QR Code
QrCode myQr = QrWriter.Write("hello world"); // Input string to encode
AnyBitmap qrBitmap = myQr.Save(); // Generates a bitmap object
qrBitmap.SaveAs("qr.png"); // Saves the bitmap as a PNG file

// Scanning a QR Code
var qrReader = new QrReader(settings: optionalQrReaderSettings); // Initializes the reader with optional settings
IEnumerable<QrResult> results = qrReader.Read(new QrImageInput("image.jpg")); // Reads the QR Code from an image
IEnumerable<QrResult> asyncResults = await qrReader.ReadAsync(new QrImageInput("image.jpg")); // Asynchronous version of the read function

// Advanced QR Code Generation
var advancedOptions = new QrOptions(QrErrorCorrectionLevel.High, 20); // Set error correction level and version

QrCode advancedQr = QrWriter.Write("hello world", options: advancedOptions); // Create QR code with advanced options

var customQrSettings = new QrStyleOptions
{
    Dimensions = 300, // Resolution in pixels
    Margins = 10, // Margin size in pixels
    Color = Color.Black, // Color of the QR Code
    Logo = new QrLogo
    {
        Bitmap = new AnyBitmap(new Uri("https://ironsoftware.com/image.svg")), // URL to a logo image
        Width = 50, // Width of logo
        Height = 50, // Height of logo
        CornerRadius = 2 // Corner radius of the logo
    }
};
AnyBitmap qrStyled = advancedQr.Save(customQrSettings);
qrStyled.SaveAs("qr_custom.png"); // Save the styled QR code to a file
```

#### 3. Deepen Your Knowledge

Enhance your understanding with our comprehensive materials:
  
  - **[Tutorials](https://ironsoftware.com/csharp/qr/tutorials/csharp-qr-code-generator/)**: Detailed tutorials to guide your first application.
  
  - **[Sample Code](https://ironsoftware.com/csharp/qr/examples/qr-quickstart/)**: Practical code samples to jumpstart your implementation.

  - **[How-To Guides](https://ironsoftware.com/csharp/qr/how-to/read-qr-codes-from-image/)**: Direct how-to articles catering to specific tasks.

  - **[Demo](https://ironsoftware.com/csharp/qr/#booking-demo)**: In-depth technical overview of IronQR's capabilities.

  - **[API References](https://ironsoftware.com/csharp/qr/object-reference/api/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)**: Comprehensive technical documentation illustrating the functionality of IronQR.

#### 1. Installing the NuGet Package

```plaintext
PM> Install-Package IronQR
```

#### 2. Generate Your Initial QR Code

```csharp
using IronQr;
using IronSoftware.Drawing;

// Generating a new QR Code
QrCode initialQr = QrWriter.Write("hello world"); // Encoding string into QR
AnyBitmap qrImage = initialQr.Save(); // Saving as a bitmap object
qrImage.SaveAs("qr.png"); // Outputting bitmap as a PNG file on disk

// Scanning a QR Code
var qrCodeReader = new QrReader(settings: optionalQrReaderSettings); // Initializing the QR reader
IEnumerable<QrResult> scanResults = qrCodeReader.Read(new QrImageInput("image.jpg")); // Using ML Model for QR detection and reading
IEnumerable<QrResult> asyncScanResults = await qrCodeReader.ReadAsync(new QrImageInput("image.jpg")); // Asynchronous read

// Custom QR Code Generation
var enhancedOptions = new QrOptions(QrErrorCorrectionLevel.High, 20); // Setting high error correction level and version

QrCode customQr = QrWriter.Write("hello world", options: enhancedOptions); // Generating QR with custom settings

var customQrSettings = new QrStyleOptions // Custom styling for the QR code
{
    Dimensions = 300, // Pixel size
    Margins = 10, // Pixel margins
    Color = Color.Black, // Base color of QR
    Logo = new QrLogo
    {
        Bitmap = new AnyBitmap(new Uri("https://ironsoftware.com/image.svg")), // Adding a logo
        Width = 50,
        Height = 50,
        CornerRadius = 2 // Rounded corners for the logo
    }
};
AnyBitmap qrCodeWithCustomStyle = customQr.Save(customQrSettings);
qrCodeWithCustomStyle.SaveAs("qr_fancy.png"); // Saving the customized QR code
```
This section guides you through creating and customizing your first QR code, scanning it, and enhancing it with advanced options and personalized styling in your .NET applications using IronQR.

#### 3. Explore More

Delve into our comprehensive guides and examples to enhance your understanding:

  * **[Tutorials](https://ironsoftware.com/csharp/qr/tutorials/csharp-qr-code-generator/)**: Detailed tutorials provide step-by-step instructions to help you embark on creating your first QR Code application.

  * **[Code Examples](https://ironsoftware.com/csharp/qr/examples/qr-quickstart/)**: A collection of concise code snippets that are ready to run, designed to demonstrate practical implementation.

  * **[How-To Guides](https://ironsoftware.com/csharp/qr/how-to/read-qr-codes-from-image/)**: These guides offer targeted, task-oriented advice for addressing specific programming challenges using IronQR.

  * **[Demo](https://ironsoftware.com/csharp/qr/#booking-demo)**: Comprehensive demonstrations that provide an in-depth look at IronQR's capabilities and how to integrate them into your applications.

  * **[API Reference](https://ironsoftware.com/csharp/qr/object-reference/api/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)**: In-depth documentation that explores each function and feature of IronQR, illustrating the complete capabilities of the library.

### **Essential Features**

* [**Read QR Code**](https://ironsoftware.com/csharp/qr/how-to/read-qr-codes-from-image/): Seamlessly scan and decode QR Codes from various sources like images and PDF documents, ensuring readability even from those of inferior quality.

* [**Generate QR Code**](https://ironsoftware.com/csharp/qr/how-to/create-qr-code-image/): Effortlessly create and personalize QR codes, giving you complete control over aspects such as size, color, and branding, while allowing you to save them as images.

* [**QR Code Types**](https://ironsoftware.com/csharp/qr/get-started/supported-qr-formats/): Fully support a variety of standard QR code types like QR Code, Micro QR Code, and RMQRCode, applicable for both scanning and generating codes.

* **Supported Applications**: Ideal for numerous platforms and integrations, encompassing desktop, web, and mobile applications.

### **System Requirements**

#### IronQR is engineered for modern .NET environments and is compatible with a variety of project types and platforms.

  * **Supported Versions**: IronQR works seamlessly with **.NET 10**, .NET 9, .NET 8, .NET 7, .NET 6, .NET 5, Core 2x & 3x, as well as Standard 2.

  * **Frameworks**: Effective with .NET Framework 4.6.2 and newer versions.

  * **Application Types**: Suitable for Console, Web, and Desktop Applications.

  * **Operating Systems**: Operates on multiple operating platforms including Windows, macOS, Linux (Debian, CentOS, Ubuntu), as well as mobile systems like iOS and Android.

  * **Cloud and Container Solutions**: Optimized for cloud services such as Azure, [AWS](https://ironsoftware.com/csharp/qr/get-started/aws/), and containerization with Docker.

  * **Development Environments**: Fully compatible with development environments like Microsoft Visual Studio, Jetbrains ReSharper & Rider.

![IronQr Cross Platform Compatibility Support Image](https://ironsoftware.com/iron-nuget-assets/main/IronQR-readme/cross-platform-compatibility.png)

#### Compatibility with Modern .NET Environments

IronQR is meticulously engineered to be compatible with a broad array of project types and operating systems, catering to the needs of the modern .NET ecosystem.

  * **Platforms Supported**: **.NET 10**, .NET 9, .NET 8, .NET 7, .NET 6, .NET 5, Core 2x & 3x, Standard 2

  * **Framework Compatibility**: Supports .NET Framework 4.6.2 and newer versions.

  * **Application Models**: Compatible with Console, Web, and Desktop Applications

  * **Supported Operating Systems**: Works across multiple OS including Windows, macOS, and Linux variants such as Debian, CentOS, and Ubuntu, as well as iOS and Android.

  * **Cloud and Container Environments**: Seamlessly integrates with cloud services like Azure, [AWS](https://ironsoftware.com/csharp/qr/get-started/aws/), and can be containerized using Docker.

  * **Development Environments**: Fully compatible with development environments such as Microsoft Visual Studio, Jetbrains ReSharper, and Rider.

[![IronQr Cross Platform Compatibility Support Image](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronQR-readme/cross-platform-compatibility.png)](https://ironsoftware.com/csharp/qr/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=crossplatformbanner)

### **Licensing Information**

IronQR is offered under a commercial license.

- **Trial License**: Obtain a complimentary developer key to thoroughly assess the capabilities of the full library without any obligations. This is perfect for development and testing stages. Initiate your trial [HERE](https://ironsoftware.com/csharp/qr/licensing/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs#trial-license).

- **Purchase a License**: Activate the library for your commercial projects and gain complete access to our dedicated technical support. Secure your license [HERE](https://ironsoftware.com/csharp/qr/licensing/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs).

### **Assistance and Support**

Encountering a problem or have inquiries?

  * **Email Assistance**: Directly contact our support team via support@ironsoftware.com.

  * **Instant Message Support**: Get quick help using our live chat feature at [https://ironsoftware.com/csharp/qr/#helpscout-support](https://ironsoftware.com/csharp/qr/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield#helpscout-support).

  * **Bug Reporting**: If you discover an issue, please report it through [https://ironsoftware.com/ticket-submission/](https://ironsoftware.com/ticket-submission/).

  * **Join Our Community**: Connect with other developers and our team on our Slack channel at [https://ironsoftware.com/company/iron-slack-community/](https://ironsoftware.com/company/iron-slack-community/).

