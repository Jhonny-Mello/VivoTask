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
    public class LinksViewModel : INotifyPropertyChanged
    {
        public IMessageService MessageService;
        public ILoadingIndicatorService ApplicationLoadingIndicatorService;
        public NavigationManager navigationManager;
        public UserBasicDetail Userservice;
        public ILinksService service;

        public LinksViewModel(ILinksService _service,
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

        public IEnumerable<Links_data> Links { get; set; } = new List<Links_data>();
        public List<Group_Links_data> Group_link { get; private set; } = new List<Group_Links_data>();

        public async Task LoadData()
        {
            if (!Links.Any())
            {
                IsBusy = true;
                try
                {
                    var result = await service.Jornada_GetLinks();

                    if (result.IsSuccess)
                    {
                        Links = JsonConvert.DeserializeObject<IEnumerable<Links_data>>(result.Content.ToString());
                        foreach (var link in Links.GroupBy(
                            p => p.Canal,
                            p => p,
                            (key, g) => new { Chave = key, Links = g.ToList() }))
                        {
                            Group_link.Add(new Group_Links_data(link.Chave, link.Links));
                        }
                    }
                }
                catch (Exception ex)
                {

                }
                IsBusy = false;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBusy)));
            }
            return;
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
