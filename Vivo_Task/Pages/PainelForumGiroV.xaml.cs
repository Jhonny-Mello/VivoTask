using Microsoft.Maui.Controls;
using Vivo_Task.ViewModels;

namespace Vivo_Task.Pages;

public partial class PainelForumGiroV : ContentPage
{
    private ForumRTCZViewModel Vm;
    public PainelForumGiroV(ForumRTCZViewModel _vm)
    {
        Vm = _vm;
        BindingContext = Vm;
        InitializeComponent();
    }

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.Navigation.RemovePage(this);
        Shell.Current.GoToAsync("./");
        return base.OnBackButtonPressed();
    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("./");
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }

    private void NavigateToForum(object sender, EventArgs e) => Shell.Current.GoToAsync($"./Jornada/{nameof(ForumGiroV)}?entry=/Forum");
    private void NavigateToMinhasPubli(object sender, EventArgs e) => Shell.Current.GoToAsync($"./Jornada/{nameof(ForumGiroV)}?entry=/get/publicacao/user");
    private void NavigateToPubliAnalista(object sender, EventArgs e) => Shell.Current.GoToAsync($"./Jornada/{nameof(ForumGiroV)}?entry=/get/publicacao/analista");
}