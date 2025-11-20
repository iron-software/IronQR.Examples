# Utilizing IronQR License Keys

***Based on <https://ironsoftware.com/get-started/license-keys/>***


## Acquiring a License Key

Implementing an IronQR license key in your project enables deployment without any feature restrictions or watermarks.

You can [purchase a license key here](https://ironsoftware.com/csharp/qr/licensing/) or obtain a [free 30-day trial key here](https://ironsoftware.com/trial-license).

--------------------------------------------------------------------------------

## Step 1: Acquire the Most Recent IronQR Release

### Installation via NuGet

To ensure you have the newest IronQR feature set, install the IronQR NuGet package with this command:

```shell
Install-Package IronQR
```

For additional details, refer to the [IronQR NuGet package page](https://www.nuget.org/packages/IronQR/).

### Installation via DLL

Alternatively, the [IronQR DLL is available for download](https://ironsoftware.com/csharp/qr/packages/IronQR.zip) so that you can manually add it to your project.

--------------------------------------------------------------------------------

## Step 2: Implement Your License Key

### Via Code

Initiate your application by configuring the IronQR license key as follows to ensure the library is properly licensed from the start:

```csharp
// Initialize IronQR with a license key
IronQR.License.LicenseKey = "IronQR-MYLICENSE-KEY-1EF01";
```

--------------------------------------------------------------------------------

### Via Web.Config or App.Config

For a global application-wide license setup using Web.Config or App.Config, insert the following into your config's `appSettings` section:

```xml
<configuration>
  ...
  <appSettings>
    <add key="IronQR.LicenseKey" value="IronQR-MYLICENSE-KEY-1EF01"/>
  </appSettings>
  ...
</configuration>
```

**Important:** There are usage concerns with IronQR versions before [version 2024.3.2](https://www.nuget.org/packages/IronQR/2024.3.2) for:
- **ASP.NET** implementations
- Projects using **.NET Framework version 4.6.2 and above**

In some cases, the `Web.config` file’s license keys may not be recognized. For solutions to these issues, visit [this guide](https://ironsoftware.com/csharp/qr/troubleshooting/license-key-web.config/).

Always verify your license state using `IronQR.License.IsLicensed` to make sure it returns `true`.

--------------------------------------------------------------------------------

### Via .NET Core appsettings.json

For global license settings in a .NET Core project:

- Include a `appsettings.json` file in the project root.
- Add the following setting with your license key:

  ```json
  {
      "IronQR.LicenseKey": "IronQR-MYLICENSE-KEY-1EF01"
  }
  ```
- Set the _Copy to Output Directory_ setting for this file to _Copy always_.

--------------------------------------------------------------------------------

## Step 3: Verify Your License

Confirm that the license key is active and functioning correctly using this code:

```csharp
// Check and confirm the IronQR license state
bool result = IronQR.License.IsValidLicense("IronQR-MYLICENSE-KEY-1EF01");
bool isLicensed = IronQR.License.IsLicensed;
```

--------------------------------------------------------------------------------

## Step 4: Initiate Your Project

Begin working on your project by following our guide on [How to Get Started with IronQR](https://ironsoftware.com/csharp/qr/docs/).

--------------------------------------------------------------------------------

## Need Assistance?

For further inquiries, please contact our support team at <support@ironsoftware.com>.