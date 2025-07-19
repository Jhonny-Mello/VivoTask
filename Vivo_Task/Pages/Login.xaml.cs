using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using CommunityToolkit.Maui.Views;
using Vivo_Task.Models;
using Vivo_Task.ViewModels;

namespace Vivo_Task.Pages;

public partial class Login : ContentPage
{
    private LoginViewModel _vm;
    public Login(LoginViewModel vm)
    {
        InitializeComponent();
        Version.Text = AppInfo.Current.VersionString;
        _vm = vm;
        BindingContext = vm;
        CheckUserLayout();
    }
    protected override async void OnAppearing()
    {
        try
        {

            var saida = await _vm.AppService.GetLatestVersionAvailableOnStore();
            if (!saida)
            {
                var result = await Application.Current.MainPage.ShowPopupAsync(new MopUpUpdateApp());
                if (!(bool)result)
                {
                    Exit();
                }
                else
                {
                    string playStoreUrl = "link to play store";

                    await Launcher.OpenAsync(new Uri(playStoreUrl));
                    Exit();
                }
            }
        }
        catch (Exception ex)
        {

        }


        base.OnAppearing();
    }


    public static void Exit()
    {
        Environment.Exit(0);
    }
    public async void CheckUserLayout()
    {
        string userDetailsStr = await SecureStorage.GetAsync(nameof(Setting.UserBasicDetail));

        if (!string.IsNullOrWhiteSpace(userDetailsStr))
        {
            var userBasicDetail = JsonConvert.DeserializeObject<UserBasicDetail>(userDetailsStr);
            if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                var result = JsonConvert.DeserializeObject<byte[]>(_vm.AppService.GetAvatarImageByMatricula(userBasicDetail.Matricula));
                if (result != null)
                {
                    userBasicDetail.UserAvatar = Convert.ToBase64String(result);
                }
                else
                {
                    userBasicDetail.UserAvatar = null;
                }
            }

            if (CheckTokenIsValid(userBasicDetail.AccessToken))
            {
                Setting.UserBasicDetail = userBasicDetail;

                await AppConstant.AddFlyoutMenusDetails();
            }
            else
            {
                SecureStorage.RemoveAll();
                Setting.UserBasicDetail = null;
            }
        }
        else
        {

        }
    }

    public static long GetTokenExpirationTime(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = handler.ReadJwtToken(token);
        var tokenExp = jwtSecurityToken.Claims.First(claim => claim.Type.Equals("exp")).Value;
        var ticks = long.Parse(tokenExp);
        return ticks;
    }

    public static bool CheckTokenIsValid(string token)
    {
        var tokenTicks = GetTokenExpirationTime(token);
        var tokenDate = DateTimeOffset.FromUnixTimeSeconds(tokenTicks).DateTime;

        var now = DateTimeOffset.UtcNow.DateTime;

        var valid = tokenDate >= now;

        return valid;
    }

}