
using System.Globalization;

namespace Vivo_Task.Converters
{
    public class ListElementConverter<T> : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IList<T> list && parameter is int index && index >= 0 && index < list.Count)
            {
                return list[index];
            }

            return default(T);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
