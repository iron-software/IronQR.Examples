using IronQR;
namespace ironqr.CsharpQrCodeGeneratorApplication
{
    public class Section11
    {
        public void Run()
        {
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
        }
    }
}