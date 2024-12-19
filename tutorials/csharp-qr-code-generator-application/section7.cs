using IronQR;
namespace IronQR.Examples.Tutorial.CsharpQrCodeGeneratorApplication
{
    public static class Section7
    {
        public static void Run()
        {
            private System.Drawing.Imaging.ImageFormat DetermineImageFormat(string filePath)
            {
                return System.IO.Path.GetExtension(filePath).ToLower() == ".jpg" ? System.Drawing.Imaging.ImageFormat.Jpeg : System.Drawing.Imaging.ImageFormat.Png;
            }
        }
    }
}