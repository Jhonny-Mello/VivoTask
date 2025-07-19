
using System.Globalization;

namespace Vivo_Task.Converters
{
    public class ToTitleCaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            var s = value as string;
            s = textInfo.ToTitleCase(s.ToLower());

            return s;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
