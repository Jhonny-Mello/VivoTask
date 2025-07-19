using SkiaSharp;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Vivo_Task.Models;
using Newtonsoft.Json;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Maui.Alerts;

#if ANDROID
using Android;
using Android.Content.PM;
using AndroidX.Core.App;
using AndroidX.Core.Content;
#endif

namespace Vivo_Task.Pages;

public partial class MopUpShowImage
{


    private bool _isBusy = true;
    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            _isBusy = value;
            if (!value)
                Close();
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Close();
    }
    private async void ShareButton(object sender, EventArgs e)  
    {
        var button = (Button)sender;
        Cards_data imageSource = button?.BindingContext as Cards_data;

#if ANDROID
        await RequestReadPermissionAsync();
        await RequestWritePermissionAsync();
#endif

        if (imageSource is not null)
        {
            try
            {
                byte[] byteArray = Convert.FromBase64String(imageSource.content);
                MemoryStream ms = new MemoryStream(byteArray);
                var filePath = await _fileSaver.SaveAsync("Cards-Image.png", ms, CancellationToken.None);
                filePath.EnsureSuccess();
                //await Task.Delay(1000);
                if (filePath.IsSuccessful)
                {
                    await Share.Default.RequestAsync(new ShareFileRequest
                    {
                        Title = "Card Qualidade",
                        File = new ShareFile(filePath.FilePath),
                    });
                }

            }
            catch (Exception ex)
            {
                // Lidar com exceções, se houver
                App.Current.MainPage.ShowPopup(new MopUpAlert("Por favor garanta que o app tenha todas as permissões necessárias para executar esta ação, não é possível sem elas"));
                return;

            }
        }
    }

#if ANDROID
    public async Task<bool> RequestReadPermissionAsync()
    {
        var activity = Platform.CurrentActivity ?? throw new NullReferenceException("Current activity is null");

        if (ContextCompat.CheckSelfPermission(activity, Manifest.Permission.ReadExternalStorage) == Permission.Granted)
        {
            return true;
        }

        if (ActivityCompat.ShouldShowRequestPermissionRationale(activity, Manifest.Permission.ReadExternalStorage))
        {
            await Toast.Make("Please grant access to external storage", ToastDuration.Short, 12).Show();
        }

        ActivityCompat.RequestPermissions(activity, new[] { Manifest.Permission.ReadExternalStorage }, 1);

        return false;
    }


    public async Task<bool> RequestWritePermissionAsync()
    {
        var activity = Platform.CurrentActivity ?? throw new NullReferenceException("Current activity is null");

        if (ContextCompat.CheckSelfPermission(activity, Manifest.Permission.WriteExternalStorage) == Permission.Granted)
        {
            return true;
        }

        if (ActivityCompat.ShouldShowRequestPermissionRationale(activity, Manifest.Permission.WriteExternalStorage))
        {
            await Toast.Make("Please grant access to external storage", ToastDuration.Short, 12).Show();
        }

        ActivityCompat.RequestPermissions(activity, new[] { Manifest.Permission.WriteExternalStorage }, 1);

        return false;
    }
#endif


    private CommunityToolkit.Maui.Storage.IFileSaver _fileSaver;
    public MopUpShowImage(Cards_data Image, CommunityToolkit.Maui.Storage.IFileSaver fileSaver)
    {
        _fileSaver = fileSaver;
        InitializeComponent();
        BindingContext = Image;
    }

}



