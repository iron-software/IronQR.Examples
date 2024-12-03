using IronQR;
namespace ironqr.CsharpQrCodeGeneratorApplication
{
    public class Section10
    {
        public void Run()
        {
            private void UpdateColor(ref Color targetColor, Control display, bool isBackground)
            {
                if (select_color.ShowDialog() == DialogResult.OK)
                {
                    var hexColor = ColorToHex(select_color.Color);
                    targetColor = new Color(hexColor);
                    display.BackColor = select_color.Color;
                }
            }
        }
    }
}