using PanCardView;
using System.Collections.Generic;
using Vivo_Task.Models;
using Vivo_Task.Pages;
using Vivo_Task.ViewModels;

namespace Vivo_Task.Templates;

public partial class CardsPrincipaisHome : ContentView
{
    public static readonly BindableProperty cardsProperty = BindableProperty.Create(nameof(cards), typeof(CardsPrincipaisModel), typeof(CardsPrincipaisHome), new CardsPrincipaisModel("Giro v", "Carregando...", "criandoprovas.jpg", new Command(() =>{})));
    public CardsPrincipaisModel cards
    {
        get => (CardsPrincipaisModel)GetValue(cardsProperty);
        set => SetValue(cardsProperty, value);
    }

    public CardsPrincipaisHome()
    {
        BindingContext = cards;
        InitializeComponent();
    }
}