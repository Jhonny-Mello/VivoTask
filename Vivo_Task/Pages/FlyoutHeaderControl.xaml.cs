using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Dispatching;
using Mopups.Services;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using Vivo_Task.Models;

namespace Vivo_Task.Pages;

public partial class FlyoutHeaderControl
{
    //private string _imageBase64Data;
    public UserBasicDetail User { get; set; } = new();

    public FlyoutHeaderControl(UserBasicDetail user)
    {
        User = user;
        InitializeComponent();
        BindingContext = this;

        //expText.Text = $"{exp.Minutes}:{(exp.Seconds.ToString().Count() != 1 ? $"{exp.Seconds}" : $"0{exp.Seconds}")}";
    }


    private async void image_Clicked(object sender, EventArgs e)
    {
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            App.Current.MainPage.ShowPopup(new MopUpGenericUserInfo(new Model_DTO.ACESSOS_MOBILE_DTO
            {
                CANAL = User.Canal,
                CARGO = User.Cargo,
                MATRICULA = User.Matricula,
                EMAIL = User.Email,
                NOME = User.Name,
                PDV = User.Pdv,
                REGIONAL = User.Regional,
                UserAvatar = User.UserAvatar == null ? [] : Convert.FromBase64String(User.UserAvatar)
            }));
        });
    }
}