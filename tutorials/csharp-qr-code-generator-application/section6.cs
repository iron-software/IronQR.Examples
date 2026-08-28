using IronQr;
namespace IronQR.Examples.Tutorial.CsharpQrCodeGeneratorApplication
{
    public static class Section6
    {
        public static void Run()
        {
            // Application.StartupPath is WinForms-only; AppContext.BaseDirectory is the
            // framework-agnostic equivalent and works in the console project too.
            string qrCodesDirectory = System.IO.Path.Combine(AppContext.BaseDirectory, "QR Codes");
        }
    }
}