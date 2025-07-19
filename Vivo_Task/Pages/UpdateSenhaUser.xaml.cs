using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using Vivo_Task.Models;
using Vivo_Task.ViewModels;
using SkiaSharp;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Vivo_Task.Shared_Static_Class.FundamentalModels;

namespace Vivo_Task.Pages;

public partial class UpdateSenhaUser : ContentPage
{
    private EdituserViewModel vm;

    public UpdateSenhaUser(EdituserViewModel _vm)
    {
        vm = _vm;
        BindingContext = vm;
        InitializeComponent();
        Version.Text = AppInfo.Current.VersionString;

    }


    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(vm.Old) && !string.IsNullOrEmpty(vm.Newone) && !string.IsNullOrEmpty(vm.Confirmnewone))
        {
            vm.IsBusy = true;
            var result = await vm.service.UpdateSenhaUser(vm.Old, vm.Newone, vm.Confirmnewone, vm.User.Matricula);
            if (result.IsSuccess)
            {
                var saida = JsonConvert.DeserializeObject<Response<string>>(result.Content.ToString());
                if (saida.Succeeded)
                {
                    vm.IsBusy = false;
                    App.Current.MainPage.ShowPopup(new MopUpSuccessAlert(saida.Message));
                    await Shell.Current.GoToAsync("//Home", true);
                    return;
                }
                else
                {
                    vm.IsBusy = false;
                    App.Current.MainPage.ShowPopup(new MopUpAlert(saida.Message));
                    return;
                }
                //await App.Current.MainPage.DisplayAlert("Tudo certo!", , "OK");
            }
            else
            {
                vm.IsBusy = false;
                App.Current.MainPage.ShowPopup(new MopUpAlert(result.ErrorMessage));
                return;
            }
        }
        else
        {
            App.Current.MainPage.ShowPopup(new MopUpAlert("Por favor preencha todas as informações corretamente!"));
        }
    }

    private async void Button_Cancel_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Home", true);
    }
}