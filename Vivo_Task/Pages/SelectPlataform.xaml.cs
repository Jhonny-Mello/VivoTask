using System.ComponentModel;
using Vivo_Task.Models;
using System.Reflection;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using MauiIcons.Core;

namespace Vivo_Task.Pages;

//[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class SelectPlataform : Shell
{

    private UserBasicDetail _userBasicDetails = new();

    public SelectPlataform()
    {
        InitializeComponent();
        _ = new MauiIcon();
        //Páginas Principais
        Routing.RegisterRoute("Home.RTCZ", typeof(JornadaXrotaCruzada));
        Routing.RegisterRoute("Cards/CardsConsumer", typeof(Cards_Qualidade));
        Routing.RegisterRoute("Cards/LinksConsumer", typeof(Links_Qualidade));
        Routing.RegisterRoute("Home.Mais", typeof(Cards_Qualidade));

        //Páginas Jornada x Rota Cruzada
        Routing.RegisterRoute("Jornada/Avaliacoes", typeof(AvaliacoesXaml));
        Routing.RegisterRoute("Jornada/CriarFormulario", typeof(CriarFormularioXaml));
        Routing.RegisterRoute("Jornada/ListaFormularios", typeof(ListaFormulariosXaml));

        //Páginas Gerais
        Routing.RegisterRoute($"Jornada/{nameof(PopUpProvaDetails)}", typeof(PopUpProvaDetails));
        Routing.RegisterRoute($"Jornada/{nameof(PopUpFormularioDetails)}", typeof(PopUpFormularioDetails));
        Routing.RegisterRoute($"Jornada/{nameof(RegisterPage)}", typeof(RegisterPage));

        //Páginas FÓRUM
        Routing.RegisterRoute($"Jornada/{nameof(PainelForumGiroV)}", typeof(PainelForumGiroV));
        Routing.RegisterRoute($"Jornada/{nameof(ForumGiroV)}", typeof(ForumGiroV));

        //Painel da Fixa
        //Routing.RegisterRoute(nameof(DemandaByIDXaml), typeof(DemandaByIDXaml));
        //Routing.RegisterRoute(nameof(PainelPrumaXaml), typeof(PainelPrumaXaml));
        //Routing.RegisterRoute(nameof(PainelRotaXaml), typeof(PainelRotaXaml));
        //Routing.RegisterRoute(nameof(PainelRotaMapaDetalhadoXaml), typeof(PainelRotaMapaDetalhadoXaml));
        //Routing.RegisterRoute(nameof(PainelRotaDetalhadoXaml), typeof(PainelRotaDetalhadoXaml));
        //Routing.RegisterRoute(nameof(PainelPrumaMapaDetalhadoXaml), typeof(PainelPrumaMapaDetalhadoXaml));
        //Routing.RegisterRoute(nameof(PainelPrumaDetalhadoXaml), typeof(PainelPrumaDetalhadoXaml));

        //
        //Routing.RegisterRoute("CriarFormulario", typeof(CriarFormularioXaml));
        //Routing.RegisterRoute("Avaliacoes", typeof(AvaliacoesXaml));
        //Routing.RegisterRoute("ListaFomularios", typeof(ListaFormulariosXaml));

        //_userBasicDetails = new UserBasicDetail();

        BindingContext = _userBasicDetails;

        // Inscrever-se no evento PropertyChanged
        _userBasicDetails.PropertyChanged += OnUserBasicDetailsPropertyChanged;
    }
    protected override void OnNavigating(ShellNavigatingEventArgs args)
    {
        if (args.Target?.Location.OriginalString == "//Home/Home.VivoTask"
        && args.Current?.Location.OriginalString == "//Home/Home.VivoTask")
        {
            args.Cancel();
        }
        else if ((args.Target.Location.OriginalString.Contains("//Home")
            && args.Target?.Location.OriginalString == args.Current?.Location.OriginalString))
        {
            if (args.CanCancel)
            {
                args.Cancel();
                Shell.Current.GoToAsync("//Home/Home.VivoTask");
            }
        }
        else if (args.Target?.Location.OriginalString == "//Logout/Login")
        {
            SecureStorage.RemoveAll();
            Setting.UserBasicDetail = null;
        }
        base.OnNavigating(args);
    }
    // Build the Hub connection


    public static void Exit()
    {
        Environment.Exit(0);
    }

    private async void image_Clicked(object sender, EventArgs e)
    {
        Current.ShowPopup(new MopUpUserInfo(_userBasicDetails));
    }

    private async void SingoutButton_Clicked(object sender, EventArgs e)
    {
        SecureStorage.RemoveAll();
        Setting.UserBasicDetail = null;
        await Shell.Current.GoToAsync("//Login");
    }

    private void OnUserBasicDetailsPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        // Atualizar o BindingContext da página
        if (e.PropertyName == nameof(UserBasicDetail))
        {
            BindingContext = _userBasicDetails;
        }
    }

}