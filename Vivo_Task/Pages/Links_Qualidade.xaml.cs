using CommunityToolkit.Maui.Views;
using Newtonsoft.Json;
using PanCardView.Controls;
using System.Formats.Tar;
using System.IdentityModel.Tokens.Jwt;
using Vivo_Task.Models;
using Vivo_Task.ViewModels;

namespace Vivo_Task.Pages;

public partial class Links_Qualidade : ContentPage
{
    private LinksViewModel _vm;
    public Links_Qualidade(LinksViewModel vm)
    {
        _vm = vm;
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        await _vm.LoadData();
        BindingContext = _vm;
        base.OnAppearing();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var item = button?.BindingContext as Links_data;

        if (item != null)
        {
            MainThread.InvokeOnMainThreadAsync(async () =>
            {
                try
                {
                    Uri uri = new Uri(item.Link);
                    await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
                }
                catch (Exception ex)
                {
                }
            });
        }
    }

    protected override void OnDisappearing()
    {

        base.OnDisappearing();
    }
}