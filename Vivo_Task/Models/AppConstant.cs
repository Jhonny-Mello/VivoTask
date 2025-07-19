using System.IO.Compression;
using Vivo_Task.Pages;

namespace Vivo_Task.Models
{
    public class AppConstant
    {
        public static Task AddFlyoutMenusDetails()
        {
            Shell.Current.FlyoutFooter = new FlyoutFooterControl(Setting.UserBasicDetail); // Insere o footer no flyout com as informações de usuário
            Shell.Current.FlyoutHeader = new FlyoutHeaderControl(Setting.UserBasicDetail); // Insere o header no flyout com as informações de usuário
            //Shell.Current.FlyoutContent

            if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                Shell.Current.Dispatcher.Dispatch(() =>
                {
                    Shell.Current.GoToAsync($"//Home");

                });
            }
            else
            {
                Shell.Current.GoToAsync($"//Home");
            }

            return Task.CompletedTask;
        }

        public static byte[] ConvertFile(byte[] Unconvertedfiles)
        {
            try
            {
                byte[] decompressedBytes;
                using (MemoryStream memoryStream = new MemoryStream(Unconvertedfiles))
                {
                    using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                    {
                        using (MemoryStream decompressedStream = new MemoryStream())
                        {
                            gzipStream.CopyTo(decompressedStream);
                            decompressedBytes = decompressedStream.ToArray();
                        }
                    }
                }

                return decompressedBytes;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
