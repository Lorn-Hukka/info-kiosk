using QRCoder;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace InfoKiosk.Modules.Common.Converters
{
    public class TextToQrCodeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not string text)
                throw new InvalidCastException();

            return GenerateQR(text);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private BitmapSource GenerateQR(string text)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            var qr = new QRCode(qrData);
            var bitmap = qr.GetGraphic(20, System.Drawing.Color.Black, System.Drawing.Color.LightGray, true);
            return bitmap.ToBitmapSource();
        }
    }
}
