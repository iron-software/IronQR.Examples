using IronQR;
namespace ironqr.CsharpQrCodeGeneratorApplication
{
    public class Section13
    {
        public void Run()
        {
            private void GenerateQRCode()
            {
                try
                {
                    var options = new QrOptions(QrErrorCorrectionLevel.High);
                    var myQr = QrWriter.Write(txt_QR.Text, options);
                    var style = CreateStyleOptions();
                    var qrImage = myQr.Save(style);
                    var fileName = $"{DateTime.Now:yyyyMMddHHmmssfff}_QR.png";
                    var fullPath = System.IO.Path.Combine(qrCodesDirectory, fileName);
                    qrImage.SaveAs(fullPath);
                    pictureBox.Image = Image.FromFile(fullPath);
                }
                catch (Exception ex)
                {
                    ShowError("An error occurred during QR code generation or saving", ex.Message);
                }
            }
        }
    }
}