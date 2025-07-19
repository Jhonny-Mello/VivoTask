using Vivo_Task.ViewModels;

namespace Vivo_Task.Pages;

public partial class AvaliacoesXaml : ContentPage
{
    private ResultadosProvaViewModel _vm;
    public AvaliacoesXaml(ResultadosProvaViewModel vm)
    {
        _vm = vm;
        BindingContext = _vm;
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        blazorWebView.RootComponents.Clear();
        _vm.LoadData();
        base.OnNavigatedTo(args);
    }


    protected override void OnDisappearing()
    {
        
        base.OnDisappearing();
    }

    //async void RefreshView_Refreshing(object sender, EventArgs e)
    //{
    //    //var navigationManager = RefreshablePageBase.Current.NavigationManager;
    //    //navigationManager.NavigateTo(navigationManager.Uri, false, true);
    //    RefreshView.IsRefreshing = true;

    //    if (!AvaliacaoPageBase.Current.modalVisible)
    //    {
    //        await AvaliacaoPageBase.Current.RefreshPage();
    //    }

    //    RefreshView.IsRefreshing = false;
    //}

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Home/Home.VivoTask/Home.RTCZ");
    }
}