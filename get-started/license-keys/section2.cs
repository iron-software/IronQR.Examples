using IronQR;
namespace IronQR.Examples.GettingStarted.LicenseKeys
{
    public static class Section2
    {
        public static void Run()
        {
            // Validate the license key
            bool result = IronQR.License.IsValidLicense("IronQR-MYLICENSE-KEY-1EF01");
            
            // Check if IronQR is licensed successfully
            bool isLicensed = IronQR.License.IsLicensed;
        }
    }
}