using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Storage;
using PanCardView.Controls;
using System.Xml.Linq;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Vivo_Task.Models;
using Vivo_Task.ViewModels;
using Microsoft.Maui.Dispatching;
using Vivo_Task.Model_DTO;

namespace Vivo_Task.Pages;

public partial class JornadaXrotaCruzada : ContentPage
{
    bool limittop;
    bool limitbottom;
    int scrollposition = 0;
    private HomeJornadaViewModel _vm;
    public JornadaXrotaCruzada(HomeJornadaViewModel vm)
    {
        _vm = vm;
        BindingContext = _vm;
        InitializeComponent();
        //lista_formulario.Command = ListaFormulario;
        //criar_formulario.Command = CriarFormulario;
        //avaliacoes.Command = Avaliacoes;
        //CardsJornada.Command = RotaCardsJornada;
        //LinksJornada.Command = RotaLinksJornada;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        if (Cards.GetValue(BindableLayout.ItemsSourceProperty) == null)
        {
            Cards.SetBinding(BindableLayout.ItemsSourceProperty, "cards");
        }
        base.OnNavigatedTo(args);
    }

    private async void image_Clicked(object sender, TappedEventArgs e)
    {
        var DisplayUser = e.Parameter as ACESSOS_MOBILE_DTO;
        if (DisplayUser is not null)
        {
            App.Current.MainPage.ShowPopup(new MopUpGenericUserInfo(DisplayUser));
        }
    }
    protected override void OnDisappearing()
    {
        //_vm._timerScroll.Tick -= OnDispatcherScrollTimer;
        base.OnDisappearing();
    }


    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

    }
}

