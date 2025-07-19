
using Vivo_Task.Shared_Static_Class.Converters;
using System.Globalization;
using Vivo_Task.Shared_Static_Class.Enums;

namespace Vivo_Task.Converters;
public class EnumToDisplayNameConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        var saida = value as Enum;
        return saida.GetDisplayName();
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}