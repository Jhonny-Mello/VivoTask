using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Vivo_Task.Models;
using Vivo_Task.ModelDTO;
using Vivo_Task.Services;
using System.ComponentModel;
using Blazorise;
using Blazorise.LoadingIndicator;
using CurrieTechnologies.Razor.SweetAlert2;
using Radzen;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Vivo_Task.Pages;
using Vivo_Task.Shared_Static_Class.FundamentalModels;

namespace Vivo_Task.ViewModels
{
    public class AvaliacaoViewModel : INotifyPropertyChanged
    {
        public IAnswerFormService _contextservice;
        public IMessageService MessageService;
        private ILoadingIndicatorService ApplicationLoadingIndicatorService;
        public SweetAlertService Swal;
        public UserBasicDetail User;
        public DialogService _DialogService;
        public NavigationManager navigationManager;
        public PreloadService PreloadService;
        public Blazorise.IPageProgressService PageProgressService;

        public AvaliacaoViewModel(IAnswerFormService contextservice,
            IMessageService messageService,
            ILoadingIndicatorService applicationLoadingIndicatorService,
            SweetAlertService swal,
            UserBasicDetail user,
            DialogService dialogService,
            NavigationManager navigationManager,
            PreloadService preloadService,
            IPageProgressService pageProgressService
            )
        {
            _contextservice = contextservice;
            MessageService = messageService;
            ApplicationLoadingIndicatorService = applicationLoadingIndicatorService;
            Swal = swal;
            User = user;
            _DialogService = dialogService;
            this.navigationManager = navigationManager;
            PreloadService = preloadService;
            PageProgressService = pageProgressService;

            popup.Closed += OnPopupDismissed;

        }

        public class DropdownList
        {
            public int? Value { get; set; }
            public string Texto { get; set; }
        }
        public string _spinnerClass;

        private bool _modalVisible;
        public bool modalVisible
        {
            get => _modalVisible;
            set
            {
                _modalVisible = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(modalVisible)));
            }
        }

        public Task ShowModal()
        {
            modalVisible = !modalVisible;
            return Task.CompletedTask;
        }

        public Task OnModalClosing(ModalClosingEventArgs e)
        {
            modalVisible = false;
            return Task.CompletedTask;
        }

        public static List<ListaAvaliacaoModel>? data { get; set; } = null;
        //public IFormularioService service { get; set; }


        //public async Task RefreshPage()
        //{
        //    data = null;
        //    IsBusy = true;
        //    var result = await service.GetListProvas_ByMatricula(User.User.MATRICULA, User.User.CARGO);

        //    if (result.IsSuccess)
        //    {
        //        data = JsonConvert.DeserializeObject<List<ListaAvaliacaoModel>>(result.Content.ToString());
        //    }
        //    else
        //    {
        //        await PageProgressService.Go(-1);
        //        PreloadService.Hide();
        //    }-
        //    IsBusy = false;
        //    return;
        //}
        public async Task ErrorModel(Response<string> data)
        {
            App.Current.MainPage.ShowPopup(new MopUpAlert(data.Message));
        }
        public MopUpBusyIndicator popup = new MopUpBusyIndicator();


        private void OnPopupDismissed(object sender, PopupClosedEventArgs e)
        {
            popup = new MopUpBusyIndicator();
            popup.Closed += OnPopupDismissed;
        }

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
                        App.Current.MainPage.ShowPopup(popup);
                    });
                }
                else
                {
                    popup.IsBusy = false;
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
