using Vivo_Task.ViewModels;
namespace Vivo_Task.Pages;


public partial class PopUpFormularioDetails : ContentPage, IQueryAttributable
{
    public int Caderno { get; set; }
    public string TIPO_FORMS { get; set; }
    public string CARGO { get; set; }
    public string FIXA { get; set; }
    public int ID_PROVA { get; set; }
    private IAnswerFormViewModel _vm { get; set; }

    public PopUpFormularioDetails()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        //Shell.Current.Navigating += OnNavigating;
    }

    protected override void OnDisappearing()
    {
        //Shell.Current.Navigating -= OnNavigating;
        base.OnDisappearing();
    }

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.Navigation.RemovePage(this);
        Shell.Current.GoToAsync("/ListaFormularios");
        return base.OnBackButtonPressed();
    }

    private async void OnNavigating(object sender, ShellNavigatingEventArgs args)
    {

        if (_vm.RespostaFormulario.QUESTIONS.Any(x => x.RESPOSTA is not null) && !_vm.Finalizado) // Caso ele já tenha respondido alguma questão e não tenha finalizado a prova
        {
            // Pause a navegação até o usuário tomar alguma decisão
            var deferral = args.GetDeferral();

            const string STAY = "Cancelar";
            const string DISCARD = "Continuar";
            switch (await DisplayActionSheet(
                "Tem certeza? as respostas seram anuladas!", null, null, DISCARD, STAY))
            {
                case STAY:
                default:
                    //cancela navegação
                    args.Cancel();
                    break;

                case DISCARD:
                    break;
            }

            // Despausa e mantém a navegação
            deferral.Complete();
        }
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Caderno = Convert.ToInt32(query["CADERNO"].ToString());
        TIPO_FORMS = query["TIPO_FORMS"].ToString();
        CARGO = query["CARGO"].ToString();
        FIXA = query["FIXA"].ToString();
        _vm = query["vm"] as IAnswerFormViewModel;
        ID_PROVA = Convert.ToInt32(query["ID_PROVA"].ToString());
        OnPropertyChanged();

        //rootComponent.Parameters = new Dictionary<string, object> { { "item", item } };
        rootComponent.Parameters = new Dictionary<string, object> {
            { "Caderno", Caderno },
            { "TIPO_FORMS", TIPO_FORMS },
            { "CARGO", CARGO },
            { "FIXA", FIXA },
            { "ID_PROVA", ID_PROVA },
        };
    }
}