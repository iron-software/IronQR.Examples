# Utilizing IronQR License Keys

***Based on <https://ironsoftware.com/how-to/license-keys/>***


## Obtaining a License Key

To unlock the full capabilities of your project with IronQR without any deployment restrictions or watermarks, you need a valid license key.

You can [purchase a license here](https://ironsoftware.com/csharp/qr/licensing/) or obtain a [free 30-day trial key here](https://ironsoftware.com/csharp/qr/licensing/).

--------------------------------------------------------------------------------

## Step 1: Acquire the Most Recent Version of IronQR

### Installation via NuGet

To integrate the latest version of IronQR into your project, use the NuGet Package Manager.

```shell
Install-Package IronQR
```

Visit [NuGet's IronQR Page](https://www.nuget.org/packages/IronQR/).

### Manual Installation via DLL

Alternatively, you can [download the IronQR.Dll](https://ironsoftware.com/csharp/qr/packages/IronQR.zip), and manually add it to your project by referencing it.

--------------------------------------------------------------------------------

## Step 2: Activate Your License Key

### Applying the License via Code

Ensure to execute this line in the initialization code of your application, before any usage of IronQR.

```csharp
IronQR.License.LicenseKey = "YOUR_LICENSE_KEY_HERE";
```

--------------------------------------------------------------------------------

### Applying the License via Web.Config or App.Config

For a wide-reaching effect across your application, insert the license key into your appSettings section within Web.Config or App.Config.

```xml
<configuration>
...
  <appSettings>
    <add key="IronQR.LicenseKey" value="YOUR_LICENSE_KEY_HERE"/>
  </appSettings>
...
</configuration>
```

Be aware that IronQR versions earlier than [2024.3.2](https://www.nuget.org/packages/IronQR/2024.3.2) may have a bug affecting:
- **ASP.NET** projects
- **.NET Framework version ≥ 4.6.2**

Issues may arise where the key in a `Web.config` does not activate the product as expected. For solutions, see our discussion on '[Setting License Key in Web.config](https://ironsoftware.com/csharp/qr/troubleshooting/license-key-web.config/)'.

Check `IronQR.License.IsLicensed` to ensure it returns `true`.

--------------------------------------------------------------------------------

### Applying the License via .NET Core appsettings.json File

To globally apply the license key within a .NET Core project:

- Integrate a JSON file named `appsettings.json` at the root of your project.
- Include the following key-value pair in your JSON configuration:

```json
{
    "IronQR.LicenseKey":"YOUR_LICENSE_KEY_HERE"
}
```
Make sure the file's properties are set to _Copy to Output Directory: Copy always_.

--------------------------------------------------------------------------------

## Step 3: Verify Your License Key

Confirm the installation of your license key is successful.

```csharp
bool validationResult = IronQR.License.IsValidLicense("YOUR_LICENSE_KEY_HERE");

// Confirm that IronQR is properly licensed
bool licenseStatus = IronQR.License.IsLicensed;
```

--------------------------------------------------------------------------------

## Step 4: Kickstart Your Project

Begin your journey with IronQR by following our comprehensive tutorial on [How to Get Started with IronQR](https://ironsoftware.com/csharp/qr/docs/).

--------------------------------------------------------------------------------

## Need Assistance?

For any inquiries, contact us at <support@ironsoftware.com>.