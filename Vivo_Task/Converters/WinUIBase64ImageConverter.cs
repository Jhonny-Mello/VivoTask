

using SkiaSharp;
using System.Text.RegularExpressions;

namespace Vivo_Task.Converters
{
    public class WinUIBase64ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            var s = value as string;
            byte[] bytesarray;
            string resultarray;

            if (s != "usericon.png")
            {
                var bytes = System.Convert.FromBase64String(s.Replace("data:image/png;base64,", ""));
                var stream = new MemoryStream(bytes);

                SKBitmap bitmap = SKBitmap.Decode(stream);

                SKBitmap resizedBitmap;

                if (DeviceInfo.Platform == DevicePlatform.WinUI)
                {
                    resizedBitmap = bitmap.Resize(new SKImageInfo(bitmap.Width / 4, bitmap.Height / 4), SKFilterQuality.Low);
                }
                else
                {
                    resizedBitmap = bitmap;
                }

                // Save the bitmap to a stream or file as a JPEG with 80% quality

                using (SKData ms = resizedBitmap.Encode(SKEncodedImageFormat.Jpeg, 100))
                {
                    bytesarray = ms.ToArray();
                }

                resultarray = System.Convert.ToBase64String(bytesarray);

                return ImageSource.FromStream(() => new MemoryStream(System.Convert.FromBase64String(resultarray)));
            }

            return s;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
