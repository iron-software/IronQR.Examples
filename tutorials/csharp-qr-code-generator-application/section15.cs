using IronQR;
namespace ironqr.CsharpQrCodeGeneratorApplication
{
    public class Section15
    {
        public void Run()
        {
            private void btn_save_Click(object sender, EventArgs e)
            {
                SaveQRCode();
            }
            
            private void SaveQRCode()
            {
                if (pictureBox.Image == null)
                {
                    MessageBox.Show("There is no QR code to save.", "Error");
                    return;
                }
            
                saveFileDialog.Filter = "PNG Files|*.png|JPEG Files|*.jpg";
                saveFileDialog.Title = "Save QR Code";
                saveFileDialog.FileName = "QRCode";
            
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox.Image.Save(saveFileDialog.FileName, DetermineImageFormat(saveFileDialog.FileName));
                        MessageBox.Show("QR Code has been saved!", "Success");
                    }
                    catch (Exception ex)
                    {
                        ShowError("An error occurred while saving the QR code", ex.Message);
                    }
                }
            }
        }
    }
}