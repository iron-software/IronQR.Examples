using IronQr;
using IronSoftware.Drawing;
using Color = IronSoftware.Drawing.Color;

namespace IronQR_QR_Generator_WinForms
{
    public partial class QR_Generator : Form
    {
        string qrCodesDirectory = System.IO.Path.Combine(Application.StartupPath, "QR Codes");
        Color bgColor = Color.White;
        Color color = Color.Black;
        AnyBitmap? logoBmp = null;

        public QR_Generator()
        {
            InitializeComponent();
            SetLicenseKey();
            EnsureDirectoryExists(qrCodesDirectory);
        }

        private static void SetLicenseKey()
        {
            IronQr.License.LicenseKey = "License-Key";
        }

        private static void EnsureDirectoryExists(string path)
        {
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
        }

        private void btn_color_Click(object sender, EventArgs e)
        {
            UpdateColor(ref color, txt_selected_color, false);
        }

        private void btn_background_Click(object sender, EventArgs e)
        {
            UpdateColor(ref bgColor, txt_selected_bgcolor, true);
        }

        private string ColorToHex(System.Drawing.Color color)
        {
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }
        private void UpdateColor(ref Color targetColor, Control display, bool isBackground)
        {
            if (select_color.ShowDialog() == DialogResult.OK)
            {

                var hexColor = ColorToHex(select_color.Color);
                targetColor = new Color(hexColor);
                display.BackColor = select_color.Color;
            }
        }

        private void btn_logo_Click(object sender, EventArgs e)
        {
            if (select_logo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    logoBmp = new AnyBitmap(select_logo.FileName);
                    selected_logo.Image = Image.FromFile(select_logo.FileName);
                }
                catch (Exception ex)
                {
                    ShowError("An error occurred while loading the logo", ex.Message);
                }
            }
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            GenerateQRCode();
        }

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

        private QrStyleOptions CreateStyleOptions()
        {
            return new QrStyleOptions
            {
                BackgroundColor = bgColor,
                Color = color,
                Dimensions = txt_dimension.Value > 0 ? Convert.ToInt32(txt_dimension.Value) : throw new ArgumentException("Please select valid dimensions!"),
                Margins = Convert.ToInt32(txt_margin.Value),
                Logo = logoBmp != null ? new QrLogo { Bitmap = logoBmp, Width = 50, Height = 50, CornerRadius = 5 } : null
            };
        }

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

        private System.Drawing.Imaging.ImageFormat DetermineImageFormat(string filePath)
        {
            return System.IO.Path.GetExtension(filePath).ToLower() == ".jpg" ? System.Drawing.Imaging.ImageFormat.Jpeg : System.Drawing.Imaging.ImageFormat.Png;
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void ResetFields()
        {
            txt_QR.Text = string.Empty;
            txt_dimension.Value = 200;
            txt_margin.Value = 0;
            bgColor = Color.White;
            color = Color.Black;
            txt_selected_color.BackColor = bgColor;
            txt_selected_bgcolor.BackColor = color;
            logoBmp = null;
            selected_logo.Image = null;
            pictureBox.Image = null;
        }

        private static void ShowError(string title, string message)
        {
            MessageBox.Show($"{title}: {message}", "Error");
        }
    }
}