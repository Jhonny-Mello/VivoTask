using BlazorBootstrap;
using Blazorise;
using Blazorise.LoadingIndicator;
using CommunityToolkit.Maui.Views;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
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
    public class EditSingleQuestionViewModel : INotifyPropertyChanged
    {
        public IMessageService MessageService;
        private ILoadingIndicatorService ApplicationLoadingIndicatorService;
        public SweetAlertService Swal;
        public UserBasicDetail User;
        public DialogService _DialogService;
        public ICreateQuestionService _contextserviceCreate;
        public IEditSingleQuestionService _contextservice;
        public NavigationManager navigationManager;

        public EditSingleQuestionViewModel(
                                  ICreateQuestionService contextserviceCreate,
                                  IEditSingleQuestionService contextservice,
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
            _contextserviceCreate = contextserviceCreate;
            MessageService = messageService;
            ApplicationLoadingIndicatorService = applicationLoadingIndicatorService;
            User = user;
            _DialogService = DialogService;
        }
        //Data 
        public IEnumerable<JORNADA_BD_TEMAS_SUB_TEMA> tema_subtema { get; set; }
        public IEnumerable<Option<int>> cargos { get; set; }
        // Model
        public CreateQuestionModel questionModel { get; set; }
        public bool Jornada { get; set; }
        public bool Rota_Cruzada { get; set; }
        public int ID_QUESTION { get; set; }
        //
        private class filter
        {
            public IEnumerable<JORNADA_BD_TEMAS_SUB_TEMA> tema_subtema { get; set; }

            public IEnumerable<Option<int>> cargos { get; set; }
        }
        public async Task LoadData()
        {
            IsBusy = true;
            var result = await _contextserviceCreate.GetDataCriarQuestion();
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

            var result1 = await _contextservice.GetSingleQuestion(ID_QUESTION);
            if (result1.IsSuccess)
            {
                Response<object> saida = JsonConvert.DeserializeObject<Response<object>>(result1.Content.ToString());
                if (saida.Succeeded)
                {
                    questionModel = JsonConvert.DeserializeObject<CreateQuestionModel>(saida.Data.ToString());
                    questionModel.matricula = User.Matricula;
                    Jornada = questionModel.TP_FORMS.Contains("Jornada");
                    Rota_Cruzada = questionModel.TP_FORMS.Contains("Rota Cruzada");
                }
                else
                {
                    var error = JsonConvert.DeserializeObject<Response<string>>(result1.Content.ToString());
                    await ErrorModel(error);
                }
            }
            IsBusy = false;
            return;
        }       
        public async Task UploadQuestion()
        {
            IsBusy = true;
            var result = await _contextservice.UpdateQuestion(questionModel, ID_QUESTION);
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
