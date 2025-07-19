using Microsoft.AspNetCore.Components.WebView.Maui;
using Vivo_Task.ModelDTO;

namespace Vivo_Task.Pages;

public partial class PopUpProvaDetails : ContentPage,IQueryAttributable
{
    public ListaAvaliacaoModel item { get; set; }
    public PopUpProvaDetails()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        item = query["item"] as ListaAvaliacaoModel;
        OnPropertyChanged();
        rootComponent.Parameters = new Dictionary<string, object> { { "item", item } };
        BindingContext = item;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }
}