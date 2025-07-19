using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using Vivo_Task.Models;
using Vivo_Task.ViewModels;
using SkiaSharp;
using System.Diagnostics;
using System.IO.Compression;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Vivo_Task.Shared_Static_Class.Converters;
using System.Collections;

namespace Vivo_Task.Pages;

public partial class EditUser : ContentPage
{
    private byte[] _imageBase64Data;
    private EdituserViewModel vm;

    public EditUser(EdituserViewModel _vm)
    {
        vm = _vm;
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        BindingContext = vm;
    }

    SKBitmap RotateBitmap(SKBitmap bitmap)
    {
        SKBitmap rotatedBitmap = new SKBitmap(bitmap.Height, bitmap.Width);
        using (var surface = new SKCanvas(rotatedBitmap))
        {
            surface.Translate(rotatedBitmap.Width, 0);
            surface.RotateDegrees(90);
            surface.DrawBitmap(bitmap, 0, 0);
        }
        return rotatedBitmap;
    }

    private async void Photo_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
                byte[] LoadedImage = [];

                if (photo != null)
                {
                    if (DeviceInfo.Platform == DevicePlatform.WinUI)
                    {
                        var stream = await photo.OpenReadAsync();
                        SKBitmap bitmap = SKBitmap.Decode(stream);

                        SKBitmap resizedBitmap = bitmap.Resize(new SKImageInfo(bitmap.Width / 2, bitmap.Height / 2), SKFilterQuality.Low);

                        // Save the bitmap to a stream or file as a JPEG with 80% quality

                        using (SKData ms = resizedBitmap.Encode(SKEncodedImageFormat.Jpeg, 60))
                        {
                            LoadedImage = ms.ToArray();
                        }

                        double sizeInKB = LoadedImage.Length / 1024.0;
                        if (sizeInKB < 5500)
                        {
                            _imageBase64Data = SharedConverter.ConvertFile(LoadedImage);
                            vm.User.ChangeAvatar = true;
                        }
                        else
                        {
                            await MainThread.InvokeOnMainThreadAsync(() =>
                            {
                                App.Current.MainPage.ShowPopup(new MopUpAlert("Imagem muito grande, por favor selecione outra"));
                            });
                        }
                    }
                    else
                    {
                        var stream = await photo.OpenReadAsync();
                        //SKBitmap resizedBitmap = bitmap.Resize(new SKImageInfo(bitmap.Width / 3, bitmap.Height / 3), SKFilterQuality.Low);
                        // Save the bitmap to a stream or file as a JPEG with 80% quality

                        //using (SKData ms = resizedBitmap.Encode(SKEncodedImageFormat.Jpeg, 70))
                        //{
                        //    LoadedImage = ms.ToArray();
                        //}
                        SKBitmap bitmap = RotateBitmap(SKBitmap.Decode(stream));

                        SKBitmap resizedBitmap = bitmap.Resize(new SKImageInfo(bitmap.Width, bitmap.Height), SKFilterQuality.Low);

                        // Save the bitmap to a stream or file as a JPEG with 80% quality

                        using (SKData ms = resizedBitmap.Encode(SKEncodedImageFormat.Jpeg, 60))
                        {
                            LoadedImage = ms.ToArray();

                            //stream.CopyTo(memoryStream);


                            //LoadedImage = memoryStream.ToArray();

                            double sizeInKB = LoadedImage.Length;
                            if (sizeInKB < 3182218)
                            {
                                _imageBase64Data = SharedConverter.CompressFile(LoadedImage);
                                vm.User.UserAvatar = SharedConverter.CompressFileString(LoadedImage);
                                vm.User.ChangeAvatar = true;
                            }
                            else
                            {
                                await MainThread.InvokeOnMainThreadAsync(() =>
                                {
                                    App.Current.MainPage.ShowPopup(new MopUpAlert("Imagem muito grande, por favor tire outra foto"));
                                });
                            }
                        }
                    }
                }
            }
        }
        //Caio Victor Pereira Martins
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Erro!", "Algum erro ocorreu ao tentar tirar a foto!", "OK");
        }
    }

    private async void Get_Local_image(object sender, EventArgs e)
    {
        var photo = await MediaPicker.Default.PickPhotoAsync();
        if (photo != null)
        {
            byte[] LoadedImage = [];
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            var stream = await photo.OpenReadAsync();

            SKBitmap bitmap = SKBitmap.Decode(stream);

            SKBitmap resizedBitmap = bitmap.Resize(new SKImageInfo(bitmap.Width / 4, bitmap.Height / 4), SKFilterQuality.Low);

            // Save the bitmap to a stream or file as a JPEG with 80% quality

            using (SKData ms = resizedBitmap.Encode(SKEncodedImageFormat.Jpeg, 60))
            {
                LoadedImage = ms.ToArray();
            }

            if (LoadedImage.Length < 3182218)
            {
                _imageBase64Data = SharedConverter.ConvertFile(LoadedImage);
                vm.User.ChangeAvatar = true;
            }
            else
            {
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    App.Current.MainPage.ShowPopup(new MopUpAlert("Imagem muito grande, por favor selecione outra"));
                });
            }

        }
    }

    private async void Take_photo_image(object sender, EventArgs e)
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            var photo = await MediaPicker.Default.CapturePhotoAsync();
            if (photo != null)
            {
                byte[] LoadedImage = [];
                var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                var stream = await photo.OpenReadAsync();

                SKBitmap bitmap = SKBitmap.Decode(stream);

                SKBitmap resizedBitmap = bitmap.Resize(new SKImageInfo(bitmap.Width / 4, bitmap.Height / 4), SKFilterQuality.Low);

                // Save the bitmap to a stream or file as a JPEG with 80% quality

                using (SKData ms = resizedBitmap.Encode(SKEncodedImageFormat.Jpeg, 60))
                {
                    LoadedImage = ms.ToArray();
                }

                if (LoadedImage.Length < 3182218)
                {
                    _imageBase64Data = SharedConverter.ConvertFile(LoadedImage);
                    vm.User.ChangeAvatar = true;
                }
                else
                {
                    await MainThread.InvokeOnMainThreadAsync(() =>
                    {
                        App.Current.MainPage.ShowPopup(new MopUpAlert("Imagem muito grande, por favor selecione outra"));
                    });
                }
            }
        }
    }


    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        vm.IsBusy = true;
        var result = await vm.service.UpdateAvatarImage(_imageBase64Data, Setting.UserBasicDetail.Matricula);
        if (result.IsSuccess)
        {
            vm.User.ChangeAvatar = false; // precisa estar antes de setar no SecureStorage;
            if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                vm.User.UserAvatar = null;
            }

            string userBasicInfoStr = JsonConvert.SerializeObject(vm.User);

            await SecureStorage.SetAsync(nameof(Setting.UserBasicDetail), userBasicInfoStr);
            vm.User.UserAvatar = Convert.ToBase64String(_imageBase64Data);
            Setting.UserBasicDetail.UserAvatar = vm.User.UserAvatar;

            vm.IsBusy = false;
            App.Current.MainPage.ShowPopup(new MopUpSuccessAlert("Imagem de usuário alterada com sucesso!"));
            //await App.Current.MainPage.DisplayAlert("Tudo certo!", , "OK");
        }
        else
        {
            vm.IsBusy = false;
            App.Current.MainPage.ShowPopup(new MopUpAlert(result.ErrorMessage));
        }
        // Load new page
        await Shell.Current.GoToAsync("//Home", true);
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//Home");
    }
}