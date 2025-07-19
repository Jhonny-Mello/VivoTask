using BlazorBootstrap;
using Blazorise;
using Blazorise.LoadingIndicator;
using CommunityToolkit.Maui.Views;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
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
using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.FundamentalModels;

namespace Vivo_Task.ViewModels
{
    public class CreateQuestionViewModel : INotifyPropertyChanged
    {
        public IMessageService MessageService;
        private ILoadingIndicatorService ApplicationLoadingIndicatorService;
        public SweetAlertService Swal;
        public UserBasicDetail User;
        public DialogService _DialogService;
        public ICreateQuestionService _contextservice;
        public NavigationManager navigationManager;

        public CreateQuestionViewModel(
                                  ICreateQuestionService contextservice,
                                  IMessageService messageService,
                                  ILoadingIndicatorService applicationLoadingIndicatorService,
                                  DialogService DialogService,
                                  SweetAlertService Swal,
                                  NavigationManager navigationManager,
                                  UserBasicDetail user)
        {
            this.Swal = Swal;
            this.navigationManager = navigationManager;
            _contextservice = contextservice;
            MessageService = messageService;
            ApplicationLoadingIndicatorService = applicationLoadingIndicatorService;
            User = user;
            _DialogService = DialogService;
        }
        public List<JORNADA_BD_ANSWER_ALTERNATIVA> ALTERNATIVAS
        { get; set; } = new();
        //Data 
        public IEnumerable<JORNADA_BD_TEMAS_SUB_TEMA> tema_subtema { get; set; }
        public IEnumerable<Option<int>> cargos { get; set; }
        // Model
        public string TEMA { get; set; }
        public string SUB_TEMA { get; set; }
        public List<string> TP_FORMS { get; set; } = new();
        public bool Jornada { get; set; }
        public bool Rota_Cruzada { get; set; }
        public string TP_QUESTAO { get; set; }
        public string PERGUNTA { get; set; }
        public IList<int> CARGO { get; set; }
        public bool? FIXA { get; set; }
        //
        private class filter
        {
            public IEnumerable<JORNADA_BD_TEMAS_SUB_TEMA> tema_subtema { get; set; }

            public IEnumerable<Option<int>> cargos { get; set; }
        }
        public async Task GetDataCriarQuestion()
        {
            IsBusy = true;
            var result = await _contextservice.GetDataCriarQuestion();
            if (result.IsSuccess)
            {
                Response<object> saida = JsonConvert.DeserializeObject<Response<object>>(result.Content.ToString());
                if (saida.Succeeded)
                {

                    var objeto = JsonConvert.DeserializeObject<filter>(saida.Data.ToString());
                    tema_subtema = objeto.tema_subtema;
                    cargos = objeto.cargos;
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

        public async Task CreateQuestion()
        {
            IsBusy = true;
            var result = await _contextservice.CreateQuestion(TEMA,
                                                              SUB_TEMA,
                                                              TP_FORMS,
                                                              TP_QUESTAO,
                                                              PERGUNTA,
                                                              CARGO,
                                                              FIXA,
                                                              ALTERNATIVAS,
                                                              User.Matricula);
            if (result.IsSuccess)
            {
                Response<object> saida = JsonConvert.DeserializeObject<Response<object>>(result.Content.ToString());
                if (saida.Succeeded)
                {
                    await MessageService.Success(saida.Message, "Tudo Certo!");
                }
                else
                {
                    var error = JsonConvert.DeserializeObject<Response<string>>(result.Content.ToString());
                    await ErrorModel(error);
                }
            }
            else
            {
                await ErrorModel(new Response<string>
                {
                    Data = "",
                    Succeeded = false,
                    Message = "Desculpe, por algum motivo não conseguimos realizar esta ação."
                });
            }

            IsBusy = false;
            return;
        }

        public async Task ErrorModel(Response<string> data)
        {
            App.Current.MainPage.ShowPopup(new MopUpAlert(data.Message));
        }

        public bool isBusy = false;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (isBusy == value) return;
                if (value == true)
                {
                    ApplicationLoadingIndicatorService.Show();
                }
                else
                {
                    ApplicationLoadingIndicatorService.Hide();
                }
                isBusy = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBusy)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
