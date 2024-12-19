using IronQR;
namespace IronQR.Examples.HowTo.LicenseKeys
{
    public static class Section2
    {
        public static void Run()
        {
            bool result = IronQR.License.IsValidLicense("IronQR-MYLICENSE-KEY-1EF01");
            
            // Check if IronQR is licensed successfully 
            bool is_licensed = IronQR.License.IsLicensed;
        }
    }
}