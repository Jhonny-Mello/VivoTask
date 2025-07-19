using Microsoft.AspNetCore.Components.WebView.Maui;
using Vivo_Task.ViewModels;

namespace Vivo_Task.Pages;
public partial class ForumGiroV : ContentPage, IQueryAttributable
{
    public string Entry { get; set; }
    private ForumRTCZViewModel Vm { get; set; }
    public ForumGiroV(ForumRTCZViewModel _vm)
    {
        Vm = _vm;
        BindingContext = Vm;
        Vm.IsBusy = true;
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Entry = query["entry"].ToString();
        OnPropertyChanged();
        blazorWebView.StartPath = Entry;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        blazorWebView.RootComponents.Clear();
        base.OnNavigatedTo(args);
    }

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.Navigation.RemovePage(this);
        Shell.Current.GoToAsync($"../Jornada/{nameof(PainelForumGiroV)}");
        return base.OnBackButtonPressed();
    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        Vm.ShowFilter = !Vm.ShowFilter;
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }
}