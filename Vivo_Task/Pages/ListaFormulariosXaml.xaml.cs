using Blazorise;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Vivo_Task.ViewModels;

namespace Vivo_Task.Pages;

public partial class ListaFormulariosXaml : ContentPage
{
    private ListaFormViewModel _service;
    public ListaFormulariosXaml(ListaFormViewModel service)
    {
        _service = service;
        BindingContext = _service;
        InitializeComponent();
    }
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        blazorWebView.RootComponents.Clear();
        await _service.LoadData();
        base.OnNavigatedTo(args);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.Navigation.RemovePage(this);
        Shell.Current.GoToAsync("//Home/Home.VivoTask/Home.RTCZ");
        return base.OnBackButtonPressed();
    }
    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Home/Home.VivoTask/Home.RTCZ");
    }
}