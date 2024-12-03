using IronQR;
namespace ironqr.CsharpQrCodeGeneratorApplication
{
    public class Section14
    {
        public void Run()
        {
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
        }
    }
}