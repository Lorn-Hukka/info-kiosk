using QRCoder;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace InfoKiosk.Modules.Credits.Models
{
	public class Person
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string GitHub { get; set; }
		public string Email { get; set; }
		public BitmapSource qrCode { get; set; }

        public Person(string name, string surname, string github, string email, QRCodeGenerator qrGenerator)
		{
			Name = name;
			Surname = surname;
			GitHub = github;
			Email = email;
			QRCodeData qrData = qrGenerator.CreateQrCode(GitHub, QRCodeGenerator.ECCLevel.Q);
			QRCode qr = new QRCode(qrData);
			qrCode = Convert(qr.GetGraphic(20, System.Drawing.Color.Black, System.Drawing.Color.LightGray, true));
		}
		public static BitmapSource Convert(System.Drawing.Bitmap bitmap)
		{
			var bitmapData = bitmap.LockBits(
				new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
				System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);

			var bitmapSource = BitmapSource.Create(
				bitmapData.Width, bitmapData.Height,
				bitmap.HorizontalResolution, bitmap.VerticalResolution,
				PixelFormats.Bgr32, null,
				bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride);

			bitmap.UnlockBits(bitmapData);

			return bitmapSource;
		}
	}
}
