using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Dispatching;
using Mopups.Services;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using Vivo_Task.Models;

namespace Vivo_Task.Pages;

public partial class FlyoutFooterControl : StackLayout
{
    //private string _imageBase64Data;
    public UserBasicDetail User = new();
    IDispatcherTimer _timer;
    private TimeSpan exp;
    private DateTime now => DateTimeOffset.UtcNow.DateTime;

    public FlyoutFooterControl(UserBasicDetail user)
    {
        User = user;
        _timer = Application.Current.Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += OnDispatcherTimer;
        _timer.IsRepeating = true;
        _timer.Start();
        BindingContext = User;
        InitializeComponent();
        Version.Text = AppInfo.Current.VersionString;
        exp = (GetTokenExp(User.AccessToken) - now);
        if (exp > TimeSpan.Zero)
        {
            expText.Text = $"{exp.Minutes}:{(exp.Seconds.ToString().Count() != 1 ? $"{exp.Seconds}" : $"0{exp.Seconds}")}";
        }
        else
        {
            expText.Text = "Expirado";
        }
    }

    private async void image_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage.ShowPopup(new MopUpUserInfo(User));
    }

    private async void SingoutButton_Clicked(object sender, EventArgs e)
    {
        SecureStorage.RemoveAll();
        Setting.UserBasicDetail = null;
        await Shell.Current.GoToAsync("//Login");
    }

    async void OnDispatcherTimer(object sender, EventArgs e)
    {
        exp = (GetTokenExp(User.AccessToken) - now);
        if (exp > TimeSpan.Zero)
        {
            expText.Text = $"{exp.Minutes}:{(exp.Seconds.ToString().Count() != 1 ? $"{exp.Seconds}" : $"0{exp.Seconds}")}";
        }
        else
        {
            expText.Text = "Expirado";
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

    public static DateTime GetTokenExp(string token)
    {
        var tokenTicks = GetTokenExpirationTime(token);
        return DateTimeOffset.FromUnixTimeSeconds(tokenTicks).DateTime;
    }

}