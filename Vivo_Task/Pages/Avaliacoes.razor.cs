using Microsoft.AspNetCore.Components.Web;
using Radzen;
using System.ComponentModel;
using Vivo_Task.ModelDTO;
using Vivo_Task.Models;

namespace Vivo_Task.Pages
{
    public partial class Avaliacoes
    {
        DateTime min = DateTime.MinValue;
        DateTime max = DateTime.MaxValue;
        int filterNota = 0;
        private IReadOnlyList<DateTime?> selectedDates;
        bool OrderByProva = false;
        bool TipoProva = true;

        public string SwtichOrderProva() => this.OrderByProva switch
        {
            true => "Provas Respondidas",
            false => "Provas Aplicadas",
        };

        //public string SwtichTipoProva() => this.TipoProva switch
        //{
        //    true => "Rota Cruzada",
        //    false => "Jornada",
        //};

        private bool IsADM() => Setting.UserBasicDetail.IsSuporte();

        List<ListaAvaliacaoModel>? List
        {
            get
            {
                List<ListaAvaliacaoModel> result = service.data;

                result = result.Where(x => Convert.ToDouble(x.NOTA) >= filterNota).ToList();

                if (selectedDates != null)
                {
                    if (selectedDates.Count >= 2)
                    {
                        result = result.Where(x => Convert.ToDateTime(x.DT_AVALIACAO) <= selectedDates[1]
                                       && Convert.ToDateTime(x.DT_AVALIACAO) >= selectedDates[0]).ToList();
                    }
                }
                result = OrderByProva ?
                result.Where(x => x.MATRICULA_AVALIADOR == Setting.UserBasicDetail.Matricula).ToList() :
                result.Where(x => x.RE_AVALIADO == Setting.UserBasicDetail.Matricula).ToList();

                //result = TipoProva ?
                //result.Where(x => x.TP_FORMS.Contains("Rota Cruzada")).ToList() :
                //result.Where(x => x.TP_FORMS.Contains("Jornada")).ToList();

                if (FilterText != null)
                {
                    result = result.Where(x => x.CADERNO.ToLower().Contains(FilterText.ToLower())
                    || x.ID_PROVA_RESPONDIDA.ToString().Contains(FilterText.ToLower())).ToList();
                }

                return result.OrderByDescending(x => Convert.ToDateTime(x.DT_AVALIACAO)).ToList();
            }
        }

        string FilterText;
        DateTime mouseDownTme;

        void TouchDown(MouseEventArgs a, ListaAvaliacaoModel classe)
        {
            //classe.pressclass = "pressing";
            //mouseDownTme = DateTime.UtcNow;
        }

        void TouchUp(MouseEventArgs a, ListaAvaliacaoModel classe)
        {
            //long milliseconds = (DateTime.UtcNow.Ticks - mouseDownTme.Ticks) / TimeSpan.TicksPerMillisecond;
            //if (milliseconds > 600)
            //{
            //    App.Current.MainPage.DisplayAlert("Atenção", "LongPress", "OK");
            //}
            //classe.pressclass = "";

        }

        public async Task OpenPopUP(MouseEventArgs ex, ListaAvaliacaoModel item)
        {
            //await App.Current.MainPage.Navigation.PushModalAsync(new PopUpProvaDetails(item));
            await Shell.Current.GoToAsync($"Jornada/{nameof(PopUpProvaDetails)}", true, new Dictionary<string, object>{
            {"item",item }
        });

            //await service._DialogService.OpenAsync<Vivo_Task.Templates.AvaliacaoDetails>($"Prova N° {item.ID}",
            //       new Dictionary<string, object>() { { "item", item } },
            //       new Radzen.DialogOptions() { Width = "1000px", Height = "612px", Resizable = true, Draggable = true });
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            service.PropertyChanged += OnModalVisibilityChanged;
            await service.LoadData();
        }

        private void OnModalVisibilityChanged(object? sender, PropertyChangedEventArgs e) => StateHasChanged();


        public void Dispose()
        {
            service.PropertyChanged -= OnModalVisibilityChanged;
        }

    }
}