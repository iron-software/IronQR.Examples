# Building a QR Code Generator in C#

> Full guide: [Building a QR Code Generator in C#](https://ironsoftware.com/csharp/qr/tutorials/csharp-qr-code-generator/?utm_source=github)

<div class="alert alert-info iron-variant-1" role="alert">
Discover the capabilities of <a href="https://ironsoftware.com/csharp/qr/?utm_source=github">IronQR</a>, the latest .NET library from Iron Software designed for QR code generation and decoding. It decodes QR codes from any orientation using machine learning, at a reported 99.99% accuracy, and generates styled codes of your own. Start with IronQR <a href="https://ironsoftware.com/csharp/qr/tutorials/csharp-qr-code-generator/?utm_source=github">here</a>.
</div>

Welcome to our tutorial on how to create [QR codes](https://en.wikipedia.org/wiki/QR_code) with C#! As QR codes and .NET barcodes become increasingly essential for quick and efficient information distribution, whether through apps, websites, or simple information sharing, the demand for easy-to-generate QR solutions grows. In this guide, we'll explore how to generate QR codes using [IronQR](https://ironsoftware.com/csharp/qr/?utm_source=github), designed to simplify the process for anyone using C#. We'll guide you through each step, providing all the necessary tools to start generating your own QR codes, whether for embedding in your apps or for learning purposes. Let’s dive in.

First, let's install the **IronQR** NuGet Package.

```shell
Install-Package IronQR
```

## Setting Up the QR Code Generator Library in C#

---

Before we can begin generating QR codes in C#, it’s essential to add the Iron Software’s **IronQR** library to our project. To do this, incorporate the library by installing the NuGet package for IronQR.

```shell
Install-Package IronQR
```

To install the **IronQR** library, simply run the following command in your console:

```shell
Install-Package IronQR
```

## IronQR: Comprehensive C# QR Library Integration

[Explore IronQR](https://ironsoftware.com/csharp/qr/?utm_source=github), a C# QR code library for .NET applications. It supports C#, VB.NET, F#, .NET Core, .NET Standard, and .NET Framework, on Windows, Linux, macOS, iOS, and Android.

IronQR stands out with its rich set of advanced functionalities, enabling not only the [reading](https://ironsoftware.com/csharp/qr/examples/read-qr-code/?utm_source=github) and [generation](https://ironsoftware.com/csharp/qr/examples/generate-qr-code/?utm_source=github) of QR codes but also offering comprehensive support for various image formats. It provides ample customization options, allowing for adjustments in size, style, and even the incorporation of logos into QR codes.

## Key Capabilities of IronQR

IronQR enhances the capabilities of typical QR code creation by offering an array of advanced features tailored for diverse QR code functions. Explore these features and their example codes, which are ready for integration into various .NET application frameworks, including console apps.

### QR Code Decoding with IronQR

IronQR stands out in its ability to decode QR codes, offering a direct method to retrieve the data encoded within them. This capability allows you to efficiently and precisely access data from QR codes, whether they involve straightforward URLs or more sophisticated embedded content.

```cs
using IronQr;
using IronSoftware.Drawing;
using System;
using System.Collections.Generic;

// Assign the license key to activate the IronQR library
IronQr.License.LicenseKey = "License-Key";

// Load the QR code image from a specific file
var qrCodeImage = AnyBitmap.FromFile("QRCode.png");

// Configure the image for QR code detection
QrImageInput qrImageToProcess = new QrImageInput(qrCodeImage);

// Establish a new QR code reader
QrReader reader = new QrReader();

// Begin the process of reading the QR code from the image
IEnumerable<QrResult> qrDecodeResults = reader.Read(qrImageToProcess);

// Iterate through each result found in the QR code reading
foreach (var qrResult in qrDecodeResults)
{
    // Output the data encoded in each QR code
    Console.WriteLine(qrResult.Value);
}
```

To initiate the QR code scanning process, start by including essential namespaces: `IronQr` for QR code functionalities and `IronSoftware.Drawing` for image manipulations—specifically, you need to utilize the `Color` class from `IronSoftware.Drawing` for handling color transformations.

The first practical step involves validating your software license by assigning your unique license key to the property `IronQr.License.LicenseKey`. Following this, the QR code image is loaded from a file with `AnyBitmap.FromFile("QRCode.png")`.

Once the image is successfully loaded, it needs to be prepared for QR detection. This is achieved by crafting a `QrImageInput` instance which effectively packages the image for processing.

The actual detection work is performed by an instance of the `QrReader` class. Upon its execution, the class scrutinizes the prepared image, identifying any and all QR codes present. This process yields a set of `QrResult` instances, each corresponding to a QR code detected in the image.

To make practical use of the detected QR codes, the application iterates through each `QrResult` in a `foreach` loop. The crucial data, such as the QR code’s content, is extracted and can be displayed as needed. Each `QrResult` provides direct access to properties, including the encoded value of the QR code.

### Varied QR Code Reading Modes

IronQR carries several reading modes for different scanning conditions.

- **Mixed Scan Mode**: Optimizes for both speed and precision, suitable for QR codes that are less visible or partially obscured.
  
- **Machine Learning (ML) Scan Mode**: Utilizes sophisticated machine learning algorithms to decode QR codes that are distorted or challenging to read, perfect for scenarios where QR codes are not easily detectable.
  
- **Basic Scan Mode**: Offers a quick and direct approach for reading QR codes that are clean and uncomplicated.

```cs
// Import necessary libraries and namespaces for QR code processing
using IronQr;
using IronQr.Enum;
using IronSoftware.Drawing;
using System.Collections.Generic;

// Set the license key for IronQR usage
IronQr.License.LicenseKey = "License-Key";

// Fetch the image file containing the QR Code
var qrCodeImage = AnyBitmap.FromFile("QRCode.png");

// Prepare the image to be scanned using different QR scanning models
QrImageInput mixedModeInput = new QrImageInput(qrCodeImage, QrScanMode.OnlyDetectionModel);
IEnumerable<QrResult> resultsFromMixedMode = new QrReader().Read(mixedModeInput);

QrImageInput mlModeInput = new QrImageInput(qrCodeImage, QrScanMode.OnlyDetectionModel);
IEnumerable<QrResult> resultsFromMLMode = new QrReader().Read(mlModeInput);

QrImageInput basicModeInput = new QrImageInput(qrCodeImage, QrScanMode.OnlyBasicScan);
IEnumerable<QrResult> resultsFromBasicMode = new QrReader().Read(basicModeInput);
```

### Advanced QR Code Scanning with IronQR

IronQR's scanning and decoding features extract data from QR codes that standard readers struggle with.

```cs
using IronQr;
using IronSoftware.Drawing;
using System;
using System.Collections.Generic;

// Setting the license key for IronQR
IronQr.License.LicenseKey = "License-Key";

// Loading the image to be scanned
var imageForScanning = AnyBitmap.FromFile("QRCode.png");

// Preparing the image for QR reading by creating a QrImageInput object
QrImageInput qrImageInput = new QrImageInput(imageForScanning);

// Initializing the QR Code reader
QrReader qrCodeReader = new QrReader();

// Performing the QR Code reading operation
IEnumerable<QrResult> resultsFromScanning = qrCodeReader.Read(qrImageInput);

// Iterating through each result after QR code detection
foreach (QrResult qrCodeResult in resultsFromScanning)
{
    // Printing the value and URL from the QR code to the console
    Console.WriteLine(qrCodeResult.Value);
    Console.WriteLine(qrCodeResult.Url);

    // Displaying the coordinates of detected QR code corners
    foreach (IronSoftware.Drawing.PointF point in qrCodeResult.Points)
    {
        Console.WriteLine($"{point.X}, {point.Y}");
    }
}
```

To develop a QR Code generator using the IronQR library within a C# application, carefully adhere to these instructions. This tutorial will guide you through configuring a Windows Forms application, incorporating the IronQR library, formulating the code necessary to produce a QR code, and comprehending the resulting output.

## Step 1: Begin a Windows Application in Visual Studio

1. Open Visual Studio on your computer.

2. Hit the "Create a New Project" button.

3. From the list of project types, choose **Windows Forms App** and ensure the language set is C#.

   ![Windows Forms App](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-code-generator-application/choose-project.webp)

4. Provide a name for your project and decide on a save location. Continue to the next page, select the .NET framework as your target, and then press **Create**.

   ![Project Configuration](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-code-generator-application/choose-project.webp)

## Step 2: Setting Up the IronQR Library

Next, we'll proceed with adding the IronQR library to your project. There are various methods available for installing this library.

### Installation via NuGet Package Manager

1. In the Solution Explorer, right-click on your project and choose **Manage NuGet Packages**.

2. In the search bar, enter `IronQR` and hit **Enter**.

   ![Manage NuGet Packages](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-code-generator-application/manage-nuget-package.webp)

3. Locate the **IronQR** package from the results and click **Install**.

   ![Install IronQR](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-code-generator-application/install-ironqr.webp)

### Installation via NuGet Package Manager Console

1. Access the **Tools > NuGet Package Manager > Package Manager Console** from the menu.

<div class="content-img-align-center">
<img src="/static-assets/qr/tutorials/csharp-qr-code-generator-application/nuget-package-manager.webp" alt="NuGet Package Manager"  class="img-responsive add-shadow img-margin">
</div>

2. Enter `Install-Package IronQR` in the command line and hit Enter.

<div class="content-img-align-center">
<img src="/static-assets/qr/tutorials/csharp-qr-code-generator-application/install-ironqr-via-pm.webp" alt="Install IronQR"  class="img-responsive add-shadow img-margin">
</div>

## Step 3: Frontend Design

This section covers the frontend design for the QR code generator application.

### 3.1 Header with Application Title

When you open the QR Code Generator, the first thing you'll notice is the prominently placed header, "QR Generator IronQR," styled in a bold and impactful font.

### 3.2 Input Fields

#### QR Code Data Entry

This input allows users to type in the data they want to encode within the QR code.

#### Logo Upload Option

Users have the ability to upload a logo that integrates directly into the QR code, adding a custom touch.

![Select Logo](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-code-generator-application/select-logo.webp)

#### Color Customization Tools

Users can personalize their QR code by choosing colors for both the foreground and background of their codes.

![Background Color](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-code-generator-application/background-color.webp)

### 3.3 Configuration of Style Elements

#### Dimension Configuration

This setting allows users to adjust the overall dimensions of the QR code.

#### Margin Adjustment

This control lets users define the amount of white margin around the QR code.
  
### 3.4 Preview Area

Here, users can see a real-time preview of the QR code as adjustments are made, ensuring satisfaction with appearance before finalizing.

![QR Code Preview](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-code-generator-application/qr-code-generator.webp)

### 3.5 Control Buttons

#### Generate Button

This button initiates the QR creation process based on the user's configurations and input.

![Generate QR Code](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-code-generator-application/qr-code-in-csharp.webp)

#### Save Button

This functionality offers users the option to save their finalized QR code to their device.

![Save QR Code](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-code-generator-application/save.webp)

#### Reset Button

This button clears all inputs and selections, allowing users to start fresh quickly.

![Reset Form](https://ironsoftware.com/static-assets/qr/tutorials/csharp-qr-code-generator-application/reset.webp)

In sum, this step walks through setting up the visual user interface of the application, focusing on usability and ease of user interaction to ensure a smooth experience.

<div class="content-img-align-center">
<img src="/static-assets/qr/tutorials/csharp-qr-code-generator-application/qr-code-generator.webp" alt="QR Code Generator"  class="img-responsive add-shadow img-margin">
</div>

## Step 4: Develop Backend Functionality

### 4.1 Configuration and Setup

This section involves importing essential namespaces, specifically `IronQr` and `IronSoftware.Drawing`, to ensure successful implementation and operation within the application.

```cs
using IronQr;
using IronSoftware.Drawing;
using Color = IronSoftware.Drawing.Color;
```

```cs
public QR_Generator()
{
    InitializeComponent(); // Initialize form components
    SetLicenseKey(); // Set the license key for IronQR
    EnsureDirectoryExists(qrCodesDirectory); // Verify that the directory for QR codes exists
}
```

### 4.2 Setting up the License Key

Configures the IronQR library with an appropriate license key:

```csharp
private static void SetLicenseKey() {
    IronQr.License.LicenseKey = "YOUR_LICENSE_KEY";
}
```

Replace `"YOUR_LICENSE_KEY"` with the actual license key you have obtained.

```csharp
private static void ActivateLicense() {
    IronQr.License.LicenseKey = "YOUR_LICENSE_KEY";
}
```

Substitute `"YOUR_LICENSE_KEY"` with your genuine license key.

### 4.3 Managing Directories

This step involves verifying the presence of required directories or establishing them if they don't exist.

```cs
private static void CheckAndCreateDirectory(string directoryPath)
{
    if (!System.IO.Directory.Exists(directoryPath))
    {
        System.IO.Directory.CreateDirectory(directoryPath);
    }
}
```

The location for storing QR codes is specified within the constructor of the `QR_Generator` class as `qrCodesDirectory`. This directory combines the startup path of the application with a directory specifically named "QR Codes":

```cs
string qrCodesDirectory = System.IO.Path.Combine(Application.StartupPath, "QR Codes Storage");
```

### 4.4 Configuring Color Selection

This segment introduces components for color dialogue and utility functions essential for customizing color options.

```cs
// This method converts a System.Drawing.Color object to a hexadecimal color string
private string ConvertColorToHex(System.Drawing.Color color)
{
    return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
}
```

The `UpdateColor` method transforms the selected color into the `IronSoftware.Drawing.Color` format by using a hexadecimal string representation. It adjusts the QR code's foreground or background color based on user choice. Furthermore, this method refreshes the user interface to display the newly chosen color.

```cs
private void ModifyColor(ref Color chosenColor, Control control, bool backgroundFlag)
{
    if (select_color.ShowDialog() == DialogResult.OK)
    {
        string hexRepresentation = ColorToHex(select_color.Color);
        chosenColor = new Color(hexRepresentation);
        control.BackColor = select_color.Color;
    }
}
```

### 4.5 Logo Incorporation

Enables users to choose and add a logo to their QR code.

```cs
private void btn_logo_Click(object sender, EventArgs e)
{
    // Display the logo selection dialog
    if (select_logo.ShowDialog() == DialogResult.OK)
    {
        try
        {
            // Load and display the logo from the selected file
            logoBmp = new AnyBitmap(select_logo.FileName);
            selected_logo.Image = Image.FromFile(select_logo.FileName);
        }
        catch (Exception ex)
        {
            // Handle exceptions by displaying an error message
            ShowError("Failed to load the logo", ex.Message);
        }
    }
}
```

### 4.6 Creating QR Codes

This section outlines the methodology for crafting QR codes in response to user specifications.

```cs
private void btn_generate_Click(object sender, EventArgs e)
{
    GenerateQRCode();
}
```

The `GenerateQRCode` method encapsulates the core functionality necessary to produce QR codes. It utilizes user inputs to customize QR codes, ensuring they meet specific requirements.

```cs
private void GenerateQRCode()
{
    try
    {
        var options = new QrOptions(QrErrorCorrectionLevel.High);
        var myQr = QrWriter.Write(txt_QR.Text, options);
        var style = CreateStyleOptions();
        var qrImage = myQr.Save(style);
        var fileName = $"{DateTime.Now:yyyyMMddHHmmssfff}_QR.png";
        var fullPath = System.IO.Path.Combine(qrCodesDirectory, fileName);
        qrImage.SaveAs(fullPath);
        pictureBox.Image = Image.FromFile(fullPath);
    }
    catch (Exception ex)
    {
        ShowError("A problem occurred during the creation or storage of the QR code", ex.Message);
    }
}
```

The `GenerateQRCode` function initiates by setting high error correction levels for the QR code, which enhances its readability even when partially obscured. It then processes the text input (`txt_QR.Text`) from the user into a QR code, applies styling options from `CreateStyleOptions`, and saves the result. This QR code is then stored as an image file named based on the current date and time, ensuring uniqueness. The image gets displayed directly in the application via `pictureBox.Image`. Errors during generation or saving are caught and reported to the user.

```cs
// Event handler for the "Generate" button
private void GenerateButton_Click(object sender, EventArgs e)
{
    CreateQRCode(); // Call the method to generate QR Code
}
```

Within the QR code generation process, the `QrOptions` object is key in specifying the error correction level, so the QR code survives damage or partial obstruction. Subsequently, the `CreateStyleOptions` method is invoked to create an instance of `QrStyleOptions`. This instance embodies various customization preferences set by the user, encompassing aspects such as color schemes, sizing dimensions, and the incorporation of a logo. Below is a detailed look at how this method functions:

```cs
private QrStyleOptions ConfigureQrAppearanceOptions()
{
    if (txt_dimension.Value <= 0)
        throw new ArgumentException("Please provide valid dimensions.");

    return new QrStyleOptions
    {
        BackgroundColor = this.bgColor,
        Color = this.color,
        Dimensions = Convert.ToInt32(txt_dimension.Value),
        Margins = Convert.ToInt32(txt_margin.Value),
        Logo = logoBmp != null ? new QrLogo(logoBmp, 50, 50, 5) : null
    };
}
```

### 4.7 QR Code Storage

This section focuses on the functionality for storing the QR code that has been generated.

```cs
private void btn_save_Click(object sender, EventArgs e)
{
    SaveQRCode();
}

private void SaveQRCode()
{
    if (pictureBox.Image == null)
    {
        MessageBox.Show("There is no QR code to save.", "Error");
        return;
    }

    saveFileDialog.Filter = "PNG Files|*.png|JPEG Files|*.jpg";
    saveFileDialog.Title = "Save QR Code";
    saveFileDialog.FileName = "QRCode";

    if (saveFileDialog.ShowDialog() == DialogResult.OK)
    {
        try
        {
            pictureBox.Image.Save(saveFileDialog.FileName, DetermineImageFormat(saveFileDialog.FileName));
            MessageBox.Show("QR Code has been saved!", "Success");
        }
        catch (Exception ex)
        {
            ShowError("An error occurred while saving the QR code", ex.Message);
        }
    }
}

private System.Drawing.Imaging.ImageFormat DetermineImageFormat(string filePath)
{
    return System.IO.Path.GetExtension(filePath).ToLower() == ".jpg" ? System.Drawing.Imaging.ImageFormat.Jpeg : System.Drawing.Imaging.ImageFormat.Png;
}
```

This portion of the code provides the mechanisms for the user to save the QR codes they have created. The `SaveQRCode` method initiates a dialog that allows the user to choose the file format and save location. It sets specific file types for saving, ensuring the QR code is stored in either PNG or JPEG format. If the user confirms the save operation, the image of the QR code is then saved to the chosen location. Additionally, appropriate error handling is included to alert the user if there's no QR code to save or if an error occurs during the saving process.

```cs
private void btn_save_Click(object sender, EventArgs e)
{
    ExecuteSaveOperation();
}

private void ExecuteSaveOperation()
{
    // Check if there is a QR code available for saving
    if (pictureBox.Image == null)
    {
        MessageBox.Show("No QR code is available to save.", "Error");
        return;
    }

    // Set up the save dialog properties
    saveFileDialog.Filter = "PNG Files|*.png|JPEG Files|*.jpg";
    saveFileDialog.Title = "Save the QR Code";
    saveFileDialog.FileName = "QRCode";

    // Display the save dialog and attempt to save the QR Code
    if (saveFileDialog.ShowDialog() == DialogResult.OK)
    {
        try
        {
            // Save the image file using the determined image format
            pictureBox.Image.Save(saveFileDialog.FileName, IdentifyImageFormat(saveFileDialog.FileName));
            MessageBox.Show("The QR Code has been successfully saved!", "Success");
        }
        catch (Exception ex)
        {
            DisplayError("Error occurred while attempting to save the QR code", ex.Message);
        }
    }
}
```

```cs
private System.Drawing.Imaging.ImageFormat GetImageFormatFromExtension(string filePath)
{
    // Extract the file extension and convert it to lowercase
    string fileExtension = System.IO.Path.GetExtension(filePath).ToLower();
    
    // Return the corresponding ImageFormat based on the file extension
    if (fileExtension == ".jpg") {
        return System.Drawing.Imaging.ImageFormat.Jpeg;
    } else {
        return System.Drawing.Imaging.ImageFormat.Png;
    }
}
```

### 4.8 Application Reset Process

This section describes how to clear all user inputs and return the application to its initial state.

```cs
// Button click event to reset the QR generator form
private void btn_reset_Click(object sender, EventArgs e)
{
    ClearAllFields();
}

// Method to clear all input fields and reset settings to default
private void ClearAllFields()
{
    txt_QR.Text = ""; // Clear the QR Code text input
    txt_dimension.Value = 200; // Set default dimension
    txt_margin.Value = 0; // Set default margin
    bgColor = Color.White; // Reset background color to white
    color = Color.Black; // Reset QR code color to black
    txt_selected_color.BackColor = System.Drawing.Color.White; // Update color display to white
    txt_selected_bgcolor.BackColor = System.Drawing.Color.Black; // Update background color display to black
    logoBmp = null; // Clear any selected logo
    selected_logo.Image = null; // Clear logo image display
    pictureBox.Image = null; // Clear the QR code display image
}
```

### 4.9 Managing Application Errors

Provides feedback through error messages to inform users of any issues encountered.

```cs
private static void DisplayError(string heading, string content)
{
    MessageBox.Show($"{heading}: {content}", "Error");
}
```

### 4.10 Comprehensive Code Sample

You can find the complete code that incorporates all the previously discussed features in the sample file linked to your project. It brings the pieces above together in one Windows Forms application.

```cs
using IronQr;
using IronSoftware.Drawing;
using Color = IronSoftware.Drawing.Color;

namespace IronQR_QR_Generator_WinForms
{
    public partial class QR_Generator : Form
    {
        // Define the directory for storing QR codes, using the startup path
        string qrCodesDirectory = System.IO.Path.Combine(Application.StartupPath, "QR Codes");
        Color bgColor = Color.White; // Default background color
        Color color = Color.Black;   // Default color for QR codes
        AnyBitmap? logoBmp = null;   // Optional logo bitmap

        public QR_Generator()
        {
            InitializeComponent();
            InitializeLicense();
            CheckAndCreateDirectory(qrCodesDirectory);
        }

        private static void InitializeLicense()
        {
            // Apply the IronQR license key
            IronQr.License.LicenseKey = "License-Key";
        }

        private static void CheckAndCreateDirectory(string directoryPath)
        {
            // Ensure the QR codes directory exists
            if (!System.IO.Directory.Exists(directoryPath))
            {
                System.IO.Directory.CreateDirectory(directoryPath);
            }
        }

        private void HandleColorButtonClick(object sender, EventArgs e)
        {
            // Update the QR code color
            UpdateColor(ref color, txt_selected_color, false);
        }

        private void HandleBackgroundButtonClick(object sender, EventArgs e)
        {
            // Update the background color
            UpdateColor(ref bgColor, txt_selected_bgcolor, true);
        }

        private string ConvertColorToHex(System.Drawing.Color color)
        {
            // Convert System.Drawing.Color to hex format
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        private void UpdateColor(ref Color targetColor, Control displayControl, bool isBackground)
        {
            // Show the color dialog and update the selected color
            if (select_color.ShowDialog() == DialogResult.OK)
            {
                var hexColor = ConvertColorToHex(select_color.Color);
                targetColor = new Color(hexColor);
                displayControl.BackColor = select_color.Color;
            }
        }

        private void HandleLogoButtonClick(object sender, EventArgs e)
        {
            // Handle the event for selecting a logo
            if (select_logo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    logoBmp = new AnyBitmap(select_logo.FileName);
                    selected_logo.Image = Image.FromFile(select_logo.FileName);
                }
                catch (Exception ex)
                {
                    DisplayError("Error loading the logo", ex.Message);
                }
            }
        }

        private void HandleGenerateButtonClick(object sender, EventArgs e)
        {
            // Generate the QR code based on user inputs
            CreateQRCode();
        }

        private void CreateQRCode()
        {
            try
            {
                var qrOptions = new QrOptions(QrErrorCorrectionLevel.High);
                var qrCode = QrWriter.Write(txt_QR.Text, qrOptions);
                var styleOptions = DefineStyleOptions();
                var qrImage = qrCode.Save(styleOptions);
                var fileName = $"{DateTime.Now:yyyyMMddHHmmssfff}_QR.png";
                var fullPath = System.IO.Path.Combine(qrCodesDirectory, fileName);
                qrImage.SaveAs(fullPath);
                pictureBox.Image = Image.FromFile(fullPath);
            }
            catch (Exception ex)
            {
                DisplayError("Error during QR code generation or saving", ex.Message);
            }
        }

        private QrStyleOptions DefineStyleOptions()
        {
            // Define style options for the QR code
            return new QrStyleOptions
            {
                BackgroundColor = bgColor,
                Color = color,
                Dimensions = txt_dimension.Value > 0 ? Convert.ToInt32(txt_dimension.Value) : throw new ArgumentException("Dimensions invalid! Please select a valid size."),
                Margins = Convert.ToInt32(txt_margin.Value),
                Logo = logoBmp != null ? new QrLogo { Bitmap = logoBmp, Width = 50, Height = 50, CornerRadius = 5 } : null
            };
        }

        private void HandleSaveButtonClick(object sender, EventArgs e)
        {
            // Save the generated QR code
            SaveGeneratedQRCode();
        }

        private void SaveGeneratedQRCode()
        {
            if (pictureBox.Image == null)
            {
                MessageBox.Show("No QR code available to save.", "Error");
                return;
            }

            saveFileDialog.Filter = "PNG Files|*.png|JPEG Files|*.jpg";
            saveFileDialog.Title = "Save QR Code";
            saveFileDialog.FileName = "QRCode";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox.Image.Save(saveFileDialog.FileName, GetImageFormat(saveFileDialog.FileName));
                    MessageBox.Show("QR Code successfully saved!", "Success");
                }
                catch (Exception ex)
                {
                    DisplayError("Error saving the QR code", ex.Message);
                }
            }
        }

        private System.Drawing.Imaging.ImageFormat GetImageFormat(string filePath)
        {
            // Determine the image format based on file extension
            return System.IO.Path.GetExtension(filePath).ToLower() == ".jpg" ? System.Drawing.Imaging.ImageFormat.Jpeg : System.Drawing.Imaging.ImageFormat.Png;
        }

        private void HandleResetButtonClick(object sender, EventArgs e)
        {
            // Reset all fields to default
            ClearFields();
        }

        private void ClearFields()
        {
            txt_QR.Text = string.Empty;
            txt_dimension.Value = 200;     // Default dimension
            txt_margin.Value = 0;          // Default margin
            bgColor = Color.White;         // Reset background color
            color = Color.Black;           // Reset QR code color
            txt_selected_color.BackColor = bgColor;
            txt_selected_bgcolor.BackColor = color;
            logoBmp = null;                // Clear logo
            selected_logo.Image = null;    // Clear logo image
            pictureBox.Image = null;       // Clear displayed image
        }

        private static void DisplayError(string title, string message)
        {
            // Display error messages to users
            MessageBox.Show($"{title}: {message}", "Error");
        }
    }
}
```

## Step 5: Launch and Test Your Application

Upon running the application, you'll see the main interface neatly organized into distinct areas for data input, styling options, output display, and operational controls. Utilize the user interface to input the desired data, personalize your QR code, execute the generation process, and save the final QR code as needed.

## Conclusion

This tutorial covered QR code generation with IronQR in a C# application: creating the project in Visual Studio, adding the library, building the interface, and writing the backend code.

IronQR offers a [free trial](https://ironsoftware.com/csharp/qr/try-it?utm_source=github). If you choose to implement IronQR in your projects, licensing begins at `$liteLicense`, ensuring an affordable route to top-tier QR code generation capabilities.

