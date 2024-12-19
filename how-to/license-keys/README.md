# Utilizing IronQR License Keys

***Based on <https://ironsoftware.com/how-to/license-keys/>***


## Obtaining a License Key

Implementing an IronQR license key in your project enables you to launch it commercially with no feature limitations or watermarks.

You can [purchase a license here](https://ironsoftware.com/csharp/qr/licensing/) or opt for a <a class='js-modal-open' data-modal-id='trial-license'>free 30-day trial key here</a>.

--------------------------------------------------------------------------------

## Step 1: Acquire the Latest IronQR Release

### Installation via NuGet

To ensure you have the most recent IronQR capabilities, install the latest NuGet package.

```shell
Install-Package IronQR
```

<https://www.nuget.org/packages/IronQR/>

### Installation via DLL

Alternatively, you can [download the IronQR.DLL](https://ironsoftware.com/csharp/qr/packages/IronQR.zip) and include it in your project as a reference.

--------------------------------------------------------------------------------

## Step 2: Configure Your License Key

### Configuring via code

To set up your application license, incorporate this snippet at the beginning of your app's execution sequence, prior to employing IronQR functionalities.

```csharp
IronQR.License.LicenseKey = "IronQR-MYLICENSE-KEY-1EF01";
```

--------------------------------------------------------------------------------

### Configuring via Web.Config or App.Config

For a global application-wide license setup using Web.Config or App.Config, insert the following into your config file under `appSettings`.

```xml
<configuration>
...
  <appSettings>
    <add key="IronQR.LicenseKey" value="IronQR-MYLICENSE-KEY-1EF01"/>
  </appSettings>
...
</configuration>
```

Note that IronQR releases prior to [2024.3.2](https://www.nuget.org/packages/IronQR/2024.3.2) may encounter licensing issues in:
- **ASP.NET** projects
- **.NET Framework version >= 4.6.2**

Licenses configured in a `Web.config` file may not be recognized. Visit the '[Setting License Key in Web.config](https://ironsoftware.com/csharp/qr/troubleshooting/license-key-web.config/)' guide for detailed troubleshooting.

Always verify your license status with `IronQR.License.IsLicensed` to confirm if it returns `true`.

--------------------------------------------------------------------------------

### Configuring via a .NET Core appsettings.json file

For .NET Core applications, perform these steps:

- Create a file named `appsettings.json` in your project’s root directory.
- Add a `IronQR.LicenseKey` entry in your JSON config file. Assign your license key as the value.
- Set the file properties to _Copy to Output Directory: Copy always_.

File: _appsettings.json_

```json
{
    "IronQR.LicenseKey":"IronQR-MYLICENSE-KEY-1EF01"
}
```

--------------------------------------------------------------------------------

## Step 3: Verify the License Key

Ensure your license key is active by checking if it has been properly applied.

```csharp
bool result = IronQR.License.IsValidLicense("IronQR-MYLICENSE-KEY-1EF01");

// Confirm if the licensing was successful
bool is_licensed = IronQR.License.IsLicensed;
```

--------------------------------------------------------------------------------

## Step 4: Initialize Your Project

Begin your project by following our [Start Guide for IronQR](https://ironsoftware.com/csharp/qr/docs/).

--------------------------------------------------------------------------------

## Need Help?

For any inquiries, please contact <support@ironsoftware.com>.