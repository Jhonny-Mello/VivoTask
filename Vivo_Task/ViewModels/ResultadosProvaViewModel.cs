using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Vivo_Task.Models;
using Vivo_Task.ModelDTO;
using Vivo_Task.Services;
using System.ComponentModel;
using Blazorise.LoadingIndicator;
using Blazorise;
using CurrieTechnologies.Razor.SweetAlert2;
using Radzen;

using Vivo_Task.Pages;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Core;
using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.FundamentalModels;

namespace Vivo_Task.ViewModels
{
    public class ResultadosProvaViewModel : INotifyPropertyChanged
    {
        public IResultadosProvaService _contextservice;
        public IMessageService MessageService;
        private ILoadingIndicatorService ApplicationLoadingIndicatorService;
        public ResultadosProvaViewModel(
            IResultadosProvaService contextservice,
            IMessageService messageService,
            ILoadingIndicatorService applicationLoadingIndicatorService)
        {
            _contextservice = contextservice;
            MessageService = messageService;
            ApplicationLoadingIndicatorService = applicationLoadingIndicatorService;
            popup.Closed += OnPopupDismissed;
        }

        private bool _modalVisible;
        public List<JORNADA_BD_AVALIACAO_RETORNO> questions = new();

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

        public Task OnModalClosing(Blazorise.ModalClosingEventArgs e)
        {
            modalVisible = false;
            return Task.CompletedTask;
        }

        public List<ListaAvaliacaoModel>? data { get; set; } = null;

        public async Task LoadResultadoDetalhado(int ID)
        {
            IsBusy = true;
            var result = await _contextservice.GetQuestionsById_Prova(ID);
            if (result.IsSuccess)
            {
                Response<object> saida = JsonConvert.DeserializeObject<Response<object>>(result.Content.ToString());
                if (saida.Succeeded)
                {
                    questions = JsonConvert.DeserializeObject<List<JORNADA_BD_AVALIACAO_RETORNO>>(saida.Data.ToString());
                }
                else
                {
                    var error = JsonConvert.DeserializeObject<Response<string>>(result.Content.ToString());
                    await ErrorModel(error);
                }
            }
            IsBusy = false;
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

        public Command ReloadPage
        {
            get
            {
                return new Command(async () =>
                {
                    if (!IsBusy)
                    {
                        await LoadData();
                    }
                });
            }
        }
        public async Task LoadData()
        {
            IsBusy = true;
            data = null;
            var result = await _contextservice.Get_List_Resultado_Prova(Setting.UserBasicDetail.Matricula);
            if (result.IsSuccess)
            {
                Response<object> saida = JsonConvert.DeserializeObject<Response<object>>(result.Content.ToString());
                if (saida.Succeeded)
                {
                    data = JsonConvert.DeserializeObject<List<ListaAvaliacaoModel>>(saida.Data.ToString());
                }
                else
                {
                    var error = JsonConvert.DeserializeObject<Response<string>>(result.Content.ToString());
                    await ErrorModel(error);
                }
            }
            IsBusy = false;
            return;
        }



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

        public bool isBusy;
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
                    //popup.IsBusy = true;
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
