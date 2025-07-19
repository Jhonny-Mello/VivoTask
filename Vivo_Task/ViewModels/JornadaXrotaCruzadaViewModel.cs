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

namespace Vivo_Task.ViewModels
{
    public class JornadaXrotaCruzadaViewModel : INotifyPropertyChanged
    {
        public IMessageService MessageService;
        public ILoadingIndicatorService ApplicationLoadingIndicatorService;
        public NavigationManager navigationManager;
        public UserBasicDetail Userservice;
        public ICardsService service;

        public JornadaXrotaCruzadaViewModel(ICardsService _service,
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

        public IEnumerable<Cards_data> Cards { get; set; } = new List<Cards_data>();

        public async Task LoadData()
        {
            //IsBusy = true;
            //var Task_Cards = await service.Jornada_GetCards_Principal();
            //Cards = JsonConvert.DeserializeObject<IEnumerable<Cards_data>>(Task_Cards.Content.ToString());
            //IsBusy = false;
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBusy)));
            return;
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
