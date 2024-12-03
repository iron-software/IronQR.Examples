using IronQR;
namespace ironqr.CsharpQrCodeGeneratorApplication
{
    public class Section16
    {
        public void Run()
        {
            private System.Drawing.Imaging.ImageFormat DetermineImageFormat(string filePath)
            {
                return System.IO.Path.GetExtension(filePath).ToLower() == ".jpg" ? System.Drawing.Imaging.ImageFormat.Jpeg : System.Drawing.Imaging.ImageFormat.Png;
            }
        }
    }
}