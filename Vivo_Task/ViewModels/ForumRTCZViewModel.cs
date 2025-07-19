using Blazorise.LoadingIndicator;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Vivo_Task.Shared_Static_Class.Model_DTO;
using Vivo_Task.Shared_Static_Class.FundamentalModels;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Radzen;
using Microsoft.FluentUI.AspNetCore.Components;
using Vivo_Task.Shared_Static_Class.Data;
using Blazorise;
using Microsoft.JSInterop;
using BlazorBootstrap;
using Vivo_Task.Shared_Static_Class.Converters;
using System.Linq;
using Vivo_Task.Shared_Static_Class.Model_DTO.FilterModels;
using Vivo_Task.Shared_Static_Class.Model_ForumRTCZ_Context;
using Vivo_Task.Shared_Static_Class.ErrorModels;
using Vivo_Task.Services;
using Vivo_Task.Models;
using CommunityToolkit.Maui.Views;
using Vivo_Task.Pages;
using Shared_Static_Class.Model;
using Radzen.Blazor.Rendering;
using CommunityToolkit.Maui.Core;

namespace Vivo_Task.ViewModels
{
    public class ForumRTCZViewModel
    {
        public IForumRTCZService ForumRTCZService;
        public Blazorise.IMessageService MessageService;
        public ILoadingIndicatorService ApplicationLoadingIndicatorService;
        public NavigationManager navigationManager;
        public ILinksService service;
        public IDialogService FluentDialog;
        public bool ShowFilter
        {
            get => showfilter;
            set
            {
                if (showfilter != value)
                {
                    showfilter = value;
                    FilterChanged.Invoke(value);
                }
            }
        }
        private bool showfilter = false;
        public event Action<bool> FilterChanged;
        public IEnumerable<PUBLICACAO_SOLICITACAODTO> Data { get; set; } = [];
        public GenericPaginationModel<PainelForumRTCZ> filterPagination { get; set; } = new(new(string.Empty, 0, [], []));
        public GenericPagedResponse<IEnumerable<PUBLICACAO_SOLICITACAODTO>> DataResponse { get; set; } = new([], 1, 15);
        public PainelForumRTCZ filter { get; set; } = new(string.Empty, 0, [], []);

        public async Task Get(int? NewPage = null, bool ByUser = false)
        {
            if (NewPage.HasValue)
                filterPagination.PageNumber = NewPage.Value;

            filterPagination.Value = new PainelForumRTCZ(filter.search, filter.avaliacao, filter.tema, filter.subtema);

            MainResponse result;
            if (ByUser)
            {
                result = await ForumRTCZService.SearchByFilters(filterPagination, Setting.UserBasicDetail.Matricula);
            }
            else
            {
                result = await ForumRTCZService.SearchByFilters(filterPagination);
            }

            if (result.IsSuccess)
            {
                var saida = JsonConvert.DeserializeObject<Response<object>>(result.Content.ToString());
                if (saida.Succeeded)
                {
                    DataResponse = JsonConvert.DeserializeObject<GenericPagedResponse<IEnumerable<PUBLICACAO_SOLICITACAODTO>>>(saida.Data.ToString());
                    Data = DataResponse.Data.Select(x => new PUBLICACAO_SOLICITACAODTO(x)).ToList();
                }
                else
                {
                    App.Current.MainPage.ShowPopup(new MopUpAlert(saida.Message));
                }
            }
            else
            {
                App.Current.MainPage.ShowPopup(new MopUpWarningAlert(result.ErrorMessage));
            }

            await Task.CompletedTask;
        }
        public async Task GetByAnalista(int? NewPage = null)
        {
            if (NewPage.HasValue)
                filterPagination.PageNumber = NewPage.Value;

            filterPagination.Value = new PainelForumRTCZ(filter.search, filter.avaliacao, filter.tema, filter.subtema);

            MainResponse result;

            result = await ForumRTCZService.SearchByAnalista(filterPagination, Setting.UserBasicDetail.Matricula);

            if (result.IsSuccess)
            {
                var saida = JsonConvert.DeserializeObject<Response<object>>(result.Content.ToString());
                if (saida.Succeeded)
                {
                    DataResponse = JsonConvert.DeserializeObject<GenericPagedResponse<IEnumerable<PUBLICACAO_SOLICITACAODTO>>>(saida.Data.ToString());
                    Data = DataResponse.Data.Select(x => new PUBLICACAO_SOLICITACAODTO(x)).ToList();
                }
                else
                {
                    App.Current.MainPage.ShowPopup(new MopUpAlert(saida.Message));
                }
            }
            else
            {
                App.Current.MainPage.ShowPopup(new MopUpAlert(result.ErrorMessage));
            }

            await Task.CompletedTask;
        }
        public async Task<IEnumerable<JORNADA_BD_TEMAS_SUB_TEMA>> GetTemas(bool ByAnalista = false)
        {
            MainResponse result;
            if (ByAnalista)
            {
                result = await ForumRTCZService.GetTemas(Setting.UserBasicDetail.Matricula);
            }
            else
            {
                result = await ForumRTCZService.GetTemas();
            }

            if (result.IsSuccess)
            {
                var saida = JsonConvert.DeserializeObject<Response<object>>(result.Content.ToString());
                if (saida.Succeeded)
                {
                    return JsonConvert.DeserializeObject<IEnumerable<JORNADA_BD_TEMAS_SUB_TEMA>>(saida.Data.ToString());
                }
                else
                {
                    App.Current.MainPage.ShowPopup(new MopUpWarningAlert(saida.Message));

                    return [];
                }
            }
            else
            {
                App.Current.MainPage.ShowPopup(new MopUpWarningAlert(result.ErrorMessage));
            }
            return [];
        }
        public async Task<bool> PostPublicacao(PUBLICACAO_SOLICITACAODTO data)
        {
            var result = await ForumRTCZService.PostPublicacao(new PublicacaoModel(data.TEXT_PUBLICACAO, data.SUB_TEMA, data.MAT_RESPONSAVEL, DateTime.Now));
            if (result.IsSuccess)
            {
                var saida = JsonConvert.DeserializeObject<Response<object>>(result.Content.ToString());
                if (saida.Succeeded)
                {
                    App.Current.MainPage.ShowPopup(new MopUpSuccessAlert(saida.Message));
                    return true;
                }
                else
                {
                    if (saida.Errors != null && saida.Errors.Any())
                    {
                        App.Current.MainPage.ShowPopup(new MopUpAlert(string.Join(';', saida.Errors)));
                    }
                    else
                    {
                        App.Current.MainPage.ShowPopup(new MopUpAlert(string.Join(';', saida.Errors)));
                    }
                }
            }
            else
            {
                try
                {
                    var saida = result.Content as ErrorResponse;
                    if (saida.Errors != null && saida.Errors.Any())
                    {
                        App.Current.MainPage.ShowPopup(new MopUpWarningAlert(result.ErrorMessage));
                    }
                    else
                    {
                        App.Current.MainPage.ShowPopup(new MopUpAlert(string.Join(';', result.ErrorMessage)));
                    }
                }
                catch
                {
                    App.Current.MainPage.ShowPopup(new MopUpAlert(string.Join(';', result.ErrorMessage)));
                }
            }

            return false;
        }
        public async Task<bool> PostRespostaPublicacao(RESPOSTA_PUBLICACAODTO data)
        {
            var result = await ForumRTCZService.PostRespostaPublicacao(new RespostaPublicacaoModel(data.ID_SOLICITACAO_PUBLICACAO, data.TEXT_PUBLICACAO, data.MAT_SOLICITANTE, DateTime.Now));
            if (result.IsSuccess)
            {
                var saida = JsonConvert.DeserializeObject<Response<object>>(result.Content.ToString());
                if (saida.Succeeded)
                {
                    App.Current.MainPage.ShowPopup(new MopUpSuccessAlert(saida.Message));
                    return true;
                }
                else
                {

                    if (saida.Errors != null && saida.Errors.Any())
                    {
                        App.Current.MainPage.ShowPopup(new MopUpAlert(string.Join(';', saida.Errors)));
                    }
                    else
                    {
                        App.Current.MainPage.ShowPopup(new MopUpAlert(string.Join(';', saida.Errors)));
                    }

                }
            }
            else
            {
                try
                {
                    var saida = result.Content as ErrorResponse;
                    if (saida.Errors != null && saida.Errors.Any())
                    {
                        App.Current.MainPage.ShowPopup(new MopUpWarningAlert(result.ErrorMessage));
                    }
                    else
                    {
                        App.Current.MainPage.ShowPopup(new MopUpAlert(string.Join(';', result.ErrorMessage)));
                    }
                }
                catch
                {
                    App.Current.MainPage.ShowPopup(new MopUpAlert(string.Join(';', result.ErrorMessage)));
                }
            }

            return false;
        }
        public async Task<bool> PostAvaliacaoToPublicacao(int value, Guid id_argumentacao)
        {
            if (id_argumentacao != Guid.Empty)
            {
                var saidasingleimage = await ForumRTCZService.PostAvaliacaoToPublicacao(
                    new AvaliacaoPublicacaoModel(id_argumentacao, Setting.UserBasicDetail.Matricula, value)
                    );

                if (saidasingleimage.IsSuccess)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        private bool isBusy = false;

        public ForumRTCZViewModel(IForumRTCZService forumRTCZService, Blazorise.IMessageService messageService, ILoadingIndicatorService applicationLoadingIndicatorService, NavigationManager navigationManager, ILinksService service, IDialogService fluentDialog)
        {
            ForumRTCZService = forumRTCZService;
            MessageService = messageService;
            ApplicationLoadingIndicatorService = applicationLoadingIndicatorService;
            this.navigationManager = navigationManager;
            this.service = service;
            FluentDialog = fluentDialog;

            popup.Closed += OnPopupDismissed;
        }

        public MopUpBusyIndicator popup = new MopUpBusyIndicator();
        private void OnPopupDismissed(object sender, PopupClosedEventArgs e)
        {
            popup = new MopUpBusyIndicator();
            popup.Closed += OnPopupDismissed;
        }
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
