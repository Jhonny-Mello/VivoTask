using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Vivo_Task.Models;
using Vivo_Task.ModelDTO;
using Vivo_Task.Services;
using Microsoft.JSInterop;
using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.Converters;
using Vivo_Task.Shared_Static_Class.Enums;

namespace Vivo_Task.ViewModels
{
    public partial class RefreshablePageBase : Blazorise.BaseComponent
    {
        protected RefreshablePageBase()
        {
            Current = this;
        }

        public static RefreshablePageBase Current;

        public class DropdownList
        {
            public int? Value { get; set; }
            public string Texto { get; set; }
        }

        public string _spinnerClass;

        public static List<ListaAvaliacaoModel>? data { get; set; } = null;
        public static List<CriarFormModel>? dataCriarFormulario;
        public static List<ListDemandasByMatricula> chamados;
        public static List<JORNADA_BD_QUESTION_HISTORICO>? dataListaFormularios;
        public static List<DropdownList> Tipo_Fila = null;

        public Shared_Static_Class.FundamentalModels.Form Resposta = new();

        public bool carregado = false;

        [Inject] public PreloadService PreloadService { get; set; }
        [Inject] public Blazorise.IPageProgressService PageProgressService { get; set; }
        [Inject] protected IJSRuntime JS { get; set; }
        [Inject] public IFormularioService service { get; set; }
        [Inject] public Blazorise.INotificationService NotificationService { get; set; }
        [Inject] public Blazorise.IMessageService MessageService { get; set; }


        public async Task RefreshPage()
        {
            data = null;
            StateHasChanged();
            await PageProgressService.Go(null, options => { options.Color = Blazorise.Color.Light; });
            _spinnerClass = "spinner-border spinner-border-sm";
            await PageProgressService.Go(null, options => { options.Color = Blazorise.Color.Light; });
            var result = await service.GetListProvas_ByMatricula(Setting.UserBasicDetail.Matricula, Setting.UserBasicDetail.Cargo.GetDisplayName());
            if (result.IsSuccess)
            {
                data = JsonConvert.DeserializeObject<List<ListaAvaliacaoModel>>(result.Content.ToString());
            }
            else
            {
                await PageProgressService.Go(-1);
                PreloadService.Hide();
            }

            await PageProgressService.Go(100, options => { options.Color = Blazorise.Color.Light; });
            await PageProgressService.Go(-1);
            PreloadService.Hide();
            _spinnerClass = "";
            StateHasChanged();
        }

        public async Task RefreshCriarFormularioPage()
        {
            await PageProgressService.Go(null, options => { options.Color = Blazorise.Color.Light; });
            dataCriarFormulario = null;
            Resposta = new();
            _spinnerClass = "spinner-border spinner-border-sm";
            await PageProgressService.Go(null, options => { options.Color = Blazorise.Color.Light; });
            StateHasChanged();
            var jornada = await service.GetQuestionFromExcel();
            dataCriarFormulario = JsonConvert.DeserializeObject<List<CriarFormModel>>(jornada.Content.ToString());
            await PageProgressService.Go(100, options => { options.Color = Blazorise.Color.Light; });
            await PageProgressService.Go(-1);
            _spinnerClass = "";
            StateHasChanged();
        }

        public async Task RefreshListaFormulariosPage()
        {
            carregado = false;
            dataListaFormularios = null;
            List<JORNADA_BD_QUESTION_HISTORICO>? dataQuestions= new();
            _spinnerClass = "spinner-border spinner-border-sm";
            await PageProgressService.Go(null, options => { options.Color = Blazorise.Color.Light; });
            StateHasChanged();

            var jornada = await service.GetAllEnableFormJornada(Setting.UserBasicDetail.Canal.GetDisplayName(), Setting.UserBasicDetail.Cargo.GetDisplayName(), Setting.UserBasicDetail.Matricula);
            var rotina = await service.GetAllEnableFormRotina(Setting.UserBasicDetail.Canal.GetDisplayName(), Setting.UserBasicDetail.Cargo.GetDisplayName(), Setting.UserBasicDetail.Matricula);
            var resultjornada = JsonConvert.DeserializeObject<List<JORNADA_BD_QUESTION_HISTORICO>>(jornada.Content.ToString());
            var resultrotina = JsonConvert.DeserializeObject<List<JORNADA_BD_QUESTION_HISTORICO>>(rotina.Content.ToString());
            
            if (resultrotina != null)
            {
                dataQuestions.AddRange(resultrotina.ToList());

            }
            if (resultjornada != null)
            {
                dataQuestions.AddRange(resultjornada.ToList());
            }

            dataListaFormularios = dataQuestions;
            
            _spinnerClass = "";
            carregado = !carregado;
            StateHasChanged();
        }
    }
}
