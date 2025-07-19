using Vivo_Task.ViewModels;

namespace Vivo_Task.Pages;

public partial class CriarFormularioXaml : ContentPage
{
    private CreateFormViewModel _vm;

    public CriarFormularioXaml(CreateFormViewModel vm)
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

    //async void RefreshView_Refreshing(object sender, EventArgs e)
    //{
    //        //var navigationManager = RefreshablePageBase.Current.NavigationManager;
    //        //navigationManager.NavigateTo(navigationManager.Uri, false, true);
    //        RefreshView.IsRefreshing = true;
    //        await RefreshablePageBase.Current.RefreshCriarFormularioPage();
    //        RefreshView.IsRefreshing = false;
    //}

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.Navigation.RemovePage(this);
        Shell.Current.GoToAsync("//Home/Home.VivoTask/Home.RTCZ");
        return base.OnBackButtonPressed();
    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Home/Home.VivoTask/Home.RTCZ");
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }
}