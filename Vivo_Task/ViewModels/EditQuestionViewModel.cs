using Blazorise;
using Blazorise.LoadingIndicator;
using CommunityToolkit.Maui.Views;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Newtonsoft.Json;
using Radzen;
using Vivo_Task.Shared_Static_Class.Data;
using System.ComponentModel;

using Vivo_Task.ModelDTO;
using Vivo_Task.Models;
using Vivo_Task.Pages;
using Vivo_Task.Services;
using IModalService = Blazorise.IModalService;
using Vivo_Task.Shared_Static_Class.FundamentalModels;

namespace Vivo_Task.ViewModels
{
    public class EditQuestionViewModel : INotifyPropertyChanged
    {
        public IEditQuestionService _contextservice;
        public ICreateQuestionService _contextserviceCreate;
        public IMessageService MessageService;
        public ILoadingIndicatorService ApplicationLoadingIndicatorService;
        public IModalService ModalService;
        public NavigationManager navigationManager;
        public UserBasicDetail Userservice;
        public DialogService _DialogService;


        public EditQuestionViewModel(
                                  IEditQuestionService contextservice,
                                  IMessageService messageService,
                                  ILoadingIndicatorService applicationLoadingIndicatorService,
                                  IModalService modalService,
                                  ICreateQuestionService contextserviceCreate,
                                  NavigationManager navigationManager,
                                  DialogService DialogService,
                                  UserBasicDetail userservice)
        {
            _contextservice = contextservice;
            MessageService = messageService;
            ModalService = modalService;
            _DialogService = DialogService;
            _contextserviceCreate = contextserviceCreate;
            ApplicationLoadingIndicatorService = applicationLoadingIndicatorService;
            this.navigationManager = navigationManager;
            Userservice = userservice;

            FilterData = new FilterEditQuestionModel
            {
                Canal = null,
                Cargos = null,
                Fixa = null,
                Id_Question = null,
                Pergunta = null,
                Sub_temas = null,
                Temas = null,
                TP_questao = null
            };

            RealStatePage = new GenericPaginationModel<FilterEditQuestionModel>()
            {
                PageNumber = 1,
                PageSize = 10,
                Value = FilterData
            };
        }

        public GenericPagedResponse<IEnumerable<QuestionModel>> statepage { get; set; } =
            new GenericPagedResponse<IEnumerable<QuestionModel>>
            (new List<QuestionModel>(), 1, 10);
        public GenericPaginationModel<FilterEditQuestionModel> RealStatePage { get; set; }
        public FilterEditQuestionModel FilterData { get; set; }
        public IEnumerable<QuestionModel> data { get; set; }
        public bool Jornada { get; set; }
        public bool Rota_Cruzada { get; set; }
        //Data 
        public IEnumerable<JORNADA_BD_TEMAS_SUB_TEMA> tema_subtema { get; set; } = new List<JORNADA_BD_TEMAS_SUB_TEMA>();
        public IEnumerable<Option<int>> cargos { get; set; } = new List<Option<int>>();
        private class filter
        {
            public IEnumerable<JORNADA_BD_TEMAS_SUB_TEMA> Tema_subtema { get; set; }

            public IEnumerable<Option<int>> cargos { get; set; }
        }

        public async Task LoadData()
        {
            IsBusy = true;
            var result = await _contextservice.GetEditQuestion(RealStatePage);
            if (result.IsSuccess)
            {
                Response<object> saida = JsonConvert.DeserializeObject<Response<object>>(result.Content.ToString());
                if (saida.Succeeded)
                {
                    statepage = JsonConvert.DeserializeObject<GenericPagedResponse<IEnumerable<QuestionModel>>>(saida.Data.ToString());
                    data = statepage.Data;
                }
                else
                {
                    IsBusy = false;
                    var error = JsonConvert.DeserializeObject<Response<string>>(result.Content.ToString());
                    await ErrorModel(error);
                }
            }

            var result1 = await _contextserviceCreate.GetDataCriarQuestion();
            if (result1.IsSuccess)
            {
                Response<object> saida = JsonConvert.DeserializeObject<Response<object>>(result1.Content.ToString());
                if (saida.Succeeded)
                {

                    var objeto = JsonConvert.DeserializeObject<filter>(saida.Data.ToString());
                    tema_subtema = objeto.Tema_subtema;
                    cargos = objeto.cargos;
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
        public async Task DeleteQuestion(int ID_QUESTION)
        {
            IsBusy = true;
            var result = await _contextservice.DeleteQuestion(ID_QUESTION);
            if (result.IsSuccess)
            {
                Response<object> saida = JsonConvert.DeserializeObject<Response<object>>(result.Content.ToString());
                if (saida.Succeeded)
                {
                    await LoadData();
                    await MessageService.Success(saida.Message, "Tudo Certo!");
                    return;
                }
                else
                {
                    IsBusy = false;
                    var error = JsonConvert.DeserializeObject<Response<string>>(result.Content.ToString());
                    await ErrorModel(error);
                    return;
                }
            }
            IsBusy = false;
            return;
        }
        public async Task GoLastPage(int TotalPage)
        {
            RealStatePage.PageNumber = TotalPage;
            IsBusy = true;
            var result = await _contextservice.GetEditQuestion(RealStatePage);
            if (result.IsSuccess)
            {
                Response<object> saida = JsonConvert.DeserializeObject<Response<object>>(result.Content.ToString());
                if (saida.Succeeded)
                {
                    statepage = JsonConvert.DeserializeObject<GenericPagedResponse<IEnumerable<QuestionModel>>>(saida.Data.ToString());
                    data = statepage.Data;
                    IsBusy = false;
                    return;
                }
                else
                {
                    IsBusy = false;
                    var error = JsonConvert.DeserializeObject<Response<string>>(result.Content.ToString());
                    await ErrorModel(error);
                    return;
                }
            }
            IsBusy = false;
            return;
        }
        public async Task GoFirstPage()
        {
            RealStatePage.PageNumber = 1;
            IsBusy = true;
            var result = await _contextservice.GetEditQuestion(RealStatePage);
            if (result.IsSuccess)
            {
                Response<object> saida = JsonConvert.DeserializeObject<Response<object>>(result.Content.ToString());
                if (saida.Succeeded)
                {
                    statepage = JsonConvert.DeserializeObject<GenericPagedResponse<IEnumerable<QuestionModel>>>(saida.Data.ToString());
                    data = statepage.Data;
                    IsBusy = false;
                    return;
                }
                else
                {
                    IsBusy = false;
                    var error = JsonConvert.DeserializeObject<Response<string>>(result.Content.ToString());
                    await ErrorModel(error);
                    return;
                }
            }
            IsBusy = false;
            return;
        }
        public async Task GoToPage(int PageNumber)
        {
            RealStatePage.PageNumber = PageNumber;
            IsBusy = true;
            var result = await _contextservice.GetEditQuestion(RealStatePage);
            if (result.IsSuccess)
            {
                Response<object> saida = JsonConvert.DeserializeObject<Response<object>>(result.Content.ToString());
                if (saida.Succeeded)
                {
                    statepage = JsonConvert.DeserializeObject<GenericPagedResponse<IEnumerable<QuestionModel>>>(saida.Data.ToString());
                    data = statepage.Data;
                    IsBusy = false;
                    return;
                }
                else
                {
                    IsBusy = false;
                    var error = JsonConvert.DeserializeObject<Response<string>>(result.Content.ToString());
                    await ErrorModel(error);
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

        public bool isFilterBusy;
        public bool IsFilterBusy
        {
            get => isFilterBusy;
            set
            {
                if (isFilterBusy == value) return;
                isFilterBusy = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsFilterBusy)));
            }
        }

        public bool isBusy;
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
