

using Vivo_Task.Shared_Static_Class.Converters;
using System.IO.Compression;
using System.Text.RegularExpressions;
using Vivo_Task.Models;

namespace Vivo_Task.Converters;

public class ImageStringConverterOrDefault : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        try
        {

            if (value is null)
                return "usericon.png";

            var s = System.Convert.FromBase64String(value.ToString());

            if (!s.Any())
                return "usericon.png";
            byte[] Convertersarray = [];

            if (s is not null)
                Convertersarray = SharedConverter.ConvertFile(s);

            if (Convertersarray.Any())
            {
                return ImageSource.FromStream(() => new MemoryStream(Convertersarray));
            }
            else
            {
                return "usericon.png";
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return "usericon.png";
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class ImageByteConverterOrDefault : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        try
        {

            if (value is null)
                return ImageSource.FromFile("usericon.png");

            var s = value as byte[];
            if (!s.Any())
                return ImageSource.FromFile("usericon.png");

            byte[] Convertersarray = [];

            if (s is not null)
                Convertersarray = SharedConverter.ConvertFile(s);

            if (Convertersarray.Any())
            {
                return ImageSource.FromStream(() => new MemoryStream(Convertersarray));
            }
            else
            {
                return ImageSource.FromFile("usericon.png");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return ImageSource.FromFile("usericon.png");
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    //private async Task<byte[]> GetFileBytesAsync(string fileName)
    //{
    //    using (Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(fileName))
    //    {
    //        using (MemoryStream memoryStream = new MemoryStream())
    //        {
    //            await fileStream.CopyToAsync(memoryStream);
    //            return memoryStream.ToArray();
    //        }
    //    }
    //}
}
