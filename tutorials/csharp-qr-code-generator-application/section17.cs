using IronQR;
namespace ironqr.CsharpQrCodeGeneratorApplication
{
    public class Section17
    {
        public void Run()
        {
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
                txt_selected_color.BackColor = System.Drawing.Color.White;
                txt_selected_bgcolor.BackColor = System.Drawing.Color.Black;
                logoBmp = null;
                selected_logo.Image = null;
                pictureBox.Image = null;
            }
        }
    }
}