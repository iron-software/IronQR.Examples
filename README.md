# IronQR.Examples

Runnable C# examples for [IronQR](https://ironsoftware.com/csharp/qr/?utm_source=github), a .NET QR code library that generates and reads QR Code, Micro QR, and Rectangular Micro QR (rMQR), with a machine-learning detection model for damaged, rotated, and low-contrast scans.

## Install

```bash
dotnet add package IronQR
```

## Quickstart

```csharp
using IronQr;
using IronSoftware.Drawing;

// Generate a QR code and save it
QrCode myQr = QrWriter.Write("hello world");
AnyBitmap qrImage = myQr.Save();
qrImage.SaveAs("qr.png");

// Read it back
QrImageInput input = new QrImageInput(AnyBitmap.FromFile("qr.png"));
IEnumerable<QrResult> results = new QrReader().Read(input);
```

`QrOptions` controls the format and error correction — `new QrOptions(QrErrorCorrectionLevel.High, 20)`, or `new QrOptions { Encoding = QrEncoding.MicroQRCode }` to switch symbology. `QrStyleOptions` adds dimensions, margins, colour, and an embedded `QrLogo`. When reading, `QrImageInput` takes a `QrScanMode`: `Auto` runs the detection model alongside the basic scan, `OnlyDetectionModel` is machine learning only, and `OnlyBasicScan` skips it.

For production use, set a license key via `License.LicenseKey = "YOUR-KEY"`. Without one, generated QR codes include a watermark.

## What's in this repo

Each folder contains a self-contained .NET project you can open and run:

- `examples/` — focused snippets demonstrating individual features
- `get-started/` — license keys, NuGet packages, supported QR formats, and AWS deployment
- `how-to/` — task-oriented guides for generating and reading QR codes
- `quickstart/` — an end-to-end project scaffold
- `tutorials/` — longer walkthroughs, including a complete QR generator application

## Common tasks covered

- Generating QR Code, Micro QR, and Rectangular Micro QR (rMQR) symbols
- Error correction levels: Low, Medium, High, and Highest
- Styling: dimensions, margins, colour, and embedded logos with rounded corners
- Reading QR codes from images, with coordinates and value for each result
- Machine-learning detection for damaged, rotated, or low-contrast codes
- Choosing a scan mode to trade accuracy against speed
- Saving to PNG and other image formats through `AnyBitmap`
- Deploying to AWS

## Platform support

.NET Standard 2.0 — so .NET 8, 7, 6, 5, .NET Core 2.0+, and .NET Framework 4.6.1+. Windows, macOS, Linux, Docker, Azure, and AWS. `IronQR.Slim` is available when the machine-learning detection model is not needed. See the [documentation](https://ironsoftware.com/csharp/qr/docs/?utm_source=github) for environment-specific notes.

## Documentation and support

- Full documentation: [ironsoftware.com/csharp/qr/docs](https://ironsoftware.com/csharp/qr/docs/?utm_source=github)
- API reference: [ironsoftware.com/csharp/qr/object-reference/api](https://ironsoftware.com/csharp/qr/object-reference/api/?utm_source=github)
- Issues with these examples: file directly on this repository
- Product support: [support@ironsoftware.com](mailto:support@ironsoftware.com)

## About

This repository is maintained by [Iron Software](https://ironsoftware.com/?utm_source=github). IronQR is a commercial library — see [licensing](https://ironsoftware.com/csharp/qr/licensing/?utm_source=github) for terms and trial details.
