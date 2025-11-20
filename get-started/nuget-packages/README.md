# IronQR NuGet Packages Overview

***Based on <https://ironsoftware.com/get-started/nuget-packages/>***


IronQR is a robust library designed for creating and scanning QR codes, specifically tailored for .NET developers. It offers modular NuGet packages to accommodate various platforms while ensuring a minimal installation footprint. Suitable for desktop, mobile, Linux, macOS, or cloud environments, IronQR provides a specific package to meet the needs of each developer's specific platform requirements.

Below, we'll explore the various **IronQR NuGet packages** to assist you in selecting the most appropriate one for your project.

## IronQR

![Windows Logo](https://img.icons8.com/color/72/000000/windows-logo.png)
![Nuget](https://img.icons8.com/windows/72/000000/nuget.png)
![Docker](https://img.icons8.com/color/72/000000/docker.png)
![Azure](https://img.icons8.com/fluency/72/000000/azure-1.png)
![AWS](https://img.icons8.com/color/72/000000/amazon-web-services.png)
![Ubuntu](https://img.icons8.com/color/72/000000/ubuntu--v1.png)

A versatile package that is well-suited for a majority of .NET desktop, server, and web applications across Windows platforms.

[**PM> Install-Package IronQR**](https://www.nuget.org/packages/IronQR)

Features include:
* Fundamental capabilities (`IronQR.Slim`)
* Machine learning-based QR code recognition
* Enhancements specific to Windows environments

## IronQR.Slim

![Nuget](https://img.icons8.com/windows/72/000000/nuget.png)

Simplified and streamlined, IronQR.Slim is devoid of advanced machine learning features and specific platform dependencies. It's perfect for:
* Projects where reduced size and enhanced performance are crucial
* Multi-platform development across:
  * Windows
  * Linux
  * macOS (Intel and ARM)
  * iOS and Android through MAUI or Xamarin
* Use cases that only require QR code generation or scanning of clear, high-resolution images

To utilize this package, you will need the platform-specific `IronSoftware.ReaderInternals` package. For instance, for Linux, you would use [IronSoftware.ReaderInternals.Linux](https://www.nuget.org/packages/IronSoftware.ReaderInternals.Linux/).

[**PM> Install-Package IronQR.Slim**](https://www.nuget.org/packages/IronQR.Slim)

Excludes:
* Advanced QR detection based on images
* Platform-dependent enhancements (like GPU acceleration or specific libraries)

All other packages such as `IronQR`, `IronQR.Linux`, and `IronQR.iOS` internally depend on `IronQR.Slim`. If minimal dependencies are a goal, starting with IronQR.Slim is recommended.

## IronQR.Linux

![Linux Logo](https://img.icons8.com/color/72/000000/linux--v1.png)
![Debian](https://img.icons8.com/color/72/000000/debian.png)
![Ubuntu](https://img.icons8.com/color/72/000000/ubuntu.png)
![CentOS](https://img.icons8.com/color/72/000000/centos.png)
![Nuget](https://img.icons8.com/windows/72/000000/nuget.png)
![Azure](https://img.icons8.com/fluency/72/000000/azure-1.png)
![AWS](https://img.icons8.com/color/72/000000/amazon-web-services.png)
![Docker](https://img.icons8.com/color/72/000000/docker.png)

Catered for Linux server environments, including those using containers or CI/CD pipelines:
* Docker environments
* AWS Lambda with Linux
* Azure Functions configured for Linux

[**PM> Install-Package IronQR.Linux**](https://www.nuget.org/packages/IronQR.Linux)

Features include:
* `IronQR.Slim` core package
* Machine learning-based detection engine
* Linux-specific native libraries

## IronQR.MacOs / IronQR.MacOs.ARM

![MacOS Client](https://img.icons8.com/color/72/000000/mac-client.png)
![Nuget](https://img.icons8.com/windows/72/000000/nuget.png)

Packages tailored for macOS desktop environments, also extending support to Apple's ARM architecture:
* .NET MAUI applications on macOS
* Native .NET apps using macOS (both Intel and ARM chip architectures)

[**PM> Install-Package IronQR.MacOs**](https://www.nuget.org/packages/IronQR.MacOs)<br>[**PM> Install-Package IronQR.MacOs.ARM**](https://www.nuget.org/packages/IronQR.MacOs.ARM)

Included features:
* `IronQR.Slim`
* Machine learning-based code detection
* Native macOS dependencies

## IronQR.iOS / IronQR.Android

![iOS Icon](https://img.icons8.com/?size=72&id=20822&format=png&color=000000)
![Nuget](https://img.icons8.com/windows/72/000000/nuget.png)
![Android Icon](https://img.icons8.com/?size=72&id=P2AnGyiJxMpp&format=png&color=000000)

Mobile-oriented versions of IronQR suitable for native or hybrid mobile application development:
* Xamarin frameworks
* .NET MAUI for mobile apps
* Native Android and iOS development environments

[**PM> Install-Package IronQR.iOS**](https://www.nuget.org/packages/IronQR.iOS)<br>[**PM> Install-Package IronQR.Android**](https://www.nuget.org/packages/IronQR.Android)

Features include:
* `IronQR.Slim`
* Mobile-adapted native internals

---

> **Tip:** Begin with the **IronQR** package unless your deployment scenario involves specific constraints such as mobile devices or limited runtime conditions.