using CommunityToolkit.Maui.Views;
using Newtonsoft.Json;
using PanCardView.Controls;
using System.IdentityModel.Tokens.Jwt;
using Vivo_Task.Models;
using Vivo_Task.ViewModels;

namespace Vivo_Task.Pages;

public partial class Cards_Qualidade : ContentPage
{
    private CardsViewModel _vm;
    private CommunityToolkit.Maui.Storage.IFileSaver _fileSaver;
    public Cards_Qualidade(CardsViewModel vm, CommunityToolkit.Maui.Storage.IFileSaver fileSaver)
    {
        _fileSaver = fileSaver;
        _vm = vm;
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        await _vm.LoadData();
        BindingContext = _vm;

        base.OnAppearing();
        carouselViewQualidade.Children.Add(new IndicatorsControl
        {
            ToFadeDuration = 1000,
        });
        carouselViewPessoas.Children.Add(new IndicatorsControl
        {
            ToFadeDuration = 1000,
        });
        carouselViewProcessos.Children.Add(new IndicatorsControl
        {
            ToFadeDuration = 1000,
        });
        carouselViewOfertas.Children.Add(new IndicatorsControl
        {
            ToFadeDuration = 1000,
        });
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var item = button?.BindingContext as Cards_data;

        if (item != null)
        {
            MainThread.InvokeOnMainThreadAsync(() =>
            {
                App.Current.MainPage.ShowPopup(new MopUpShowImage(item, _fileSaver));
            });
        }
    }

    private void Image_Clicked(object sender, TappedEventArgs e)
    {
        var item = e?.Parameter as Cards_data;

        if (item != null)
        {
            MainThread.InvokeOnMainThreadAsync(() =>
            {
                Shell.Current.CurrentPage.ShowPopup(new MopUpShowImage(item, _fileSaver));
            });
        }
    }

    protected override void OnDisappearing()
    {

        base.OnDisappearing();
    }
}