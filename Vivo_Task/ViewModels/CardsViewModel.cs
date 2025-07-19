using Blazorise;
using Blazorise.LoadingIndicator;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using PanCardView.Processors;
using Vivo_Task.Shared_Static_Class.FundamentalModels;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Input;

using Vivo_Task.Models;
using Vivo_Task.Pages;
using Vivo_Task.Services;
using Button = Microsoft.Maui.Controls.Button;

namespace Vivo_Task.ViewModels
{
    public class CardsViewModel : INotifyPropertyChanged
    {
        public IMessageService MessageService;
        public ILoadingIndicatorService ApplicationLoadingIndicatorService;
        public NavigationManager navigationManager;
        public UserBasicDetail Userservice;
        public ICardsService service;

        public CardsViewModel(ICardsService _service,
                              IMessageService messageService,
                              ILoadingIndicatorService applicationLoadingIndicatorService,
                              NavigationManager navigationManager,
                              UserBasicDetail userservice)
        {
            service = _service;
            this.navigationManager = navigationManager;
            MessageService = messageService;
            ApplicationLoadingIndicatorService = applicationLoadingIndicatorService;
            Userservice = userservice;
            this.navigationManager = navigationManager;
            popup.Closed += OnPopupDismissed;
        }

        public IEnumerable<Cards_data> Cards_Qualidade { get; set; } = new List<Cards_data>();
        public IEnumerable<Cards_data> Cards_Ofertas { get; set; } = new List<Cards_data>();
        public IEnumerable<Cards_data> Cards_Processos { get; set; } = new List<Cards_data>();
        public IEnumerable<Cards_data> Cards_Pessoas { get; set; } = new List<Cards_data>();

        public bool Loaded = false;

        public async Task LoadData()
        {
            if (!Loaded)
            {
                IsBusy = true;
                //var result = await service.Jornada_GetCards_Qualidade();
                Task<MainResponse> Task_Cards_Qualidade;
                Task<MainResponse> Task_Cards_Ofertas;
                Task<MainResponse> Task_Cards_Processos;
                Task<MainResponse> Task_Cards_Pessoas;
                await Task.WhenAll(new Task[]{

                Task_Cards_Qualidade = service.Jornada_GetCards_Qualidade(),
                Task_Cards_Ofertas = service.Jornada_GetCards_Ofertas(),
                Task_Cards_Processos = service.Jornada_GetCards_Processos(),
                Task_Cards_Pessoas = service.Jornada_GetCards_Pessoas(),
                });

                Cards_Qualidade = JsonConvert.DeserializeObject<IEnumerable<Cards_data>>(Task_Cards_Qualidade.Result.Content.ToString());
                Cards_Ofertas = JsonConvert.DeserializeObject<IEnumerable<Cards_data>>(Task_Cards_Ofertas.Result.Content.ToString());
                Cards_Processos = JsonConvert.DeserializeObject<IEnumerable<Cards_data>>(Task_Cards_Processos.Result.Content.ToString());
                Cards_Pessoas = JsonConvert.DeserializeObject<IEnumerable<Cards_data>>(Task_Cards_Pessoas.Result.Content.ToString());
                IsBusy = false;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBusy)));
                Loaded = true;
            }

            return;
        }
        public Command ReloadPage
        {
            get
            {
                return new Command(async () =>
                {
                    if (!IsBusy)
                    {
                        Loaded = false;
                        await LoadData();
                    }
                });
            }
        }
        public Command BackButton
        {
            get
            {
                return new Command(async () =>
                {

                    await Shell.Current.GoToAsync("//Home/Home.VivoTask/Home.RTCZ");
                });
            }
        }
        public async Task ErrorModel(Response<string> error)
        {
            App.Current.MainPage.ShowPopup(new MopUpAlert(error.Message));
        }
        private void OnPopupDismissed(object sender, PopupClosedEventArgs e)
        {
            popup = new MopUpBusyIndicator();
            popup.Closed += OnPopupDismissed;
        }

        public MopUpBusyIndicator popup = new MopUpBusyIndicator();

        public bool isBusy = false;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (isBusy == value) return;

                isBusy = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBusy)));

                if (isBusy == true)
                {
                    MainThread.InvokeOnMainThreadAsync(() =>
                    {
                        Shell.Current.CurrentPage.ShowPopup(popup);
                    });
                }
                else
                {
                    popup.IsBusy = false;
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

    }
}
