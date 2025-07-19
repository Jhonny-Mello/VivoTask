using BlazorBootstrap;
using Blazorise;
using Blazorise.LoadingIndicator;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Maui.Handlers;
using Newtonsoft.Json;
using Radzen;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Text.Json.Nodes;

using Vivo_Task.Shared_Static_Class.Converters;
using Vivo_Task.Models;
using Vivo_Task.Pages;
using Vivo_Task.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Vivo_Task.Shared_Static_Class.FundamentalModels;

namespace Vivo_Task.ViewModels
{
    public class CreateFormViewModel : INotifyPropertyChanged
    {
        public IMessageService MessageService;
        public ICreateFormService _contextservice;

        public CreateFormViewModel(ICreateFormService contextservice,
                                  IMessageService messageService)
        {
            _contextservice = contextservice;
            MessageService = messageService;
            popup.Closed += OnPopupDismissed;
            LoadData();
        }
        public bool ELEGIVEL { get; set; } = false;
        public string TIPO_PROVA { get; set; } = string.Empty;

        private DateTime dT_INIT = DateTime.Now;
        public DateTime DT_INIT
        {
            get => dT_INIT;

            set
            {
                dT_INIT = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DT_INIT)));
            }
        }
        public DateTime? DT_FINAL { get; set; }

        public int QTD_PERGUNTA { get; set; }
        public int QTD_TEMA { get; set; }
        public int CARGO { get; set; }
        public bool FIXA { get; set; }
        public bool TemaIsBusy { get; set; }
        public List<TEMAS_QTD> TEMAS_QUANTIDADE { get; set; } = new();
        //Data Filter s
        public IEnumerable<Option<int>> datafilterscargos { get; set; }
        public IEnumerable<TEMA_SUB_TEMA_QTD>? datafilterstemas { get; set; }

        public async Task GetTemas()
        {
            if (TIPO_PROVA is not null &
                QTD_PERGUNTA != 0 &
                QTD_TEMA != 0 &
                CARGO != 0)
            {
                TemaIsBusy = true;
                datafilterstemas = new List<TEMA_SUB_TEMA_QTD>();
                var result = await _contextservice.GetTemasCriarFormulario(TIPO_PROVA, Setting.UserBasicDetail.Regional, CARGO, FIXA);
                if (result.IsSuccess)
                {
                    Response<object> saida = JsonConvert.DeserializeObject<Response<object>>(result.Content.ToString());
                    if (saida.Succeeded)
                    {
                        datafilterstemas = JsonConvert.DeserializeObject<IEnumerable<TEMA_SUB_TEMA_QTD>>(saida.Data.ToString());
                        TemaIsBusy = false;
                        return;
                    }
                    else
                    {
                        TemaIsBusy = false;
                        var erro = JsonConvert.DeserializeObject<Response<string>>(result.Content.ToString());
                        await ErrorModel(erro);
                        return;
                    }
                }
                TemaIsBusy = false;
                return;
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

        public Command ReloadData
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
            var result = await _contextservice.GetDataCriarFormulario();
            if (result.IsSuccess)
            {
                Response<object> saida = JsonConvert.DeserializeObject<Response<object>>(result.Content.ToString());
                if (saida.Succeeded)
                {
                    datafilterscargos = JsonConvert.DeserializeObject<IEnumerable<Option<int>>>(saida.Data.ToString());
                    IsBusy = false;
                    return;
                }
                else
                {
                    IsBusy = false;
                    var erro = JsonConvert.DeserializeObject<Response<string>>(result.Content.ToString());
                    await ErrorModel(erro);
                    return;
                }
            }
            IsBusy = false;
            return;
        }

        public async Task CreateForm()
        {
            IsBusy = true;
            var result = await _contextservice.CriarFormulario(TEMAS_QUANTIDADE, TIPO_PROVA, CARGO, FIXA, Setting.UserBasicDetail.Regional,
                Setting.UserBasicDetail.Matricula, DT_INIT, DT_FINAL, QTD_PERGUNTA, ELEGIVEL);

            if (result.IsSuccess)
            {
                Response<object> saida = JsonConvert.DeserializeObject<Response<object>>(result.Content.ToString());
                if (saida.Succeeded)
                {
                    App.Current.MainPage.ShowPopup(new MopUpSuccessAlert(saida.Message));
                    IsBusy = false;
                    return;
                }
                else
                {
                    IsBusy = false;
                    var erro = JsonConvert.DeserializeObject<Response<string>>(result.Content.ToString());
                    await ErrorModel(erro);
                    return;
                }
            }
            IsBusy = false;
            return;
        }
        public async Task ErrorModel(Response<string> data)
        {
            App.Current.MainPage.ShowPopup(new MopUpAlert(data.Message));
        }

        public async Task<DateTime> SetDate()
        {
            DateTime? Date = DateTime.Now;

            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                object result = await App.Current.MainPage.ShowPopupAsync(new MopUpSelectDate());
                Date = result as DateTime?;
            });

            return Date.Value;
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

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
