using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.JSInterop;
using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.Model_DTO;
using Vivo_Task.Shared_Static_Class.Model_DTO.FilterModels;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Globalization;
using Vivo_Task.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Vivo_Task.Models;
using CommunityToolkit.Maui.Views;
using Vivo_Task.Pages;

namespace Vivo_Task.RazorPages.Forum_GiroV;

public partial class Index : ComponentBase, IDisposable
{
    //[CascadingParameter]  Model
    TextInfo textInfo = new CultureInfo("pt-BR", false).TextInfo;
    bool FooterOpen { get; set; } = false;
    bool AddNewPublicacao { get; set; } = false;
    [CascadingParameter] public PUBLICACAO_SOLICITACAODTO Model { get; set; } = null;
    private IEnumerable<JORNADA_BD_TEMAS_SUB_TEMA> Temas { get; set; } = [];
    Task<IJSObjectReference> _jsmodule;
    public Task<IJSObjectReference> Module => _jsmodule ??= JSRuntime.InvokeAsync<IJSObjectReference>("import", $"./{this.GetType().Name}.js").AsTask();

    string value { get; set; }
    [Inject] ForumRTCZViewModel vm { get; set; }
    [Inject] IJSRuntime JSRuntime { get; set; }
    private void OnStateChanged(object? sender, PropertyChangedEventArgs e)
    {
        InvokeAsync(StateHasChanged);
    }
    protected override void OnInitialized()
    {
        vm.PropertyChanged += OnStateChanged;
        vm.filterPagination = new(new PainelForumRTCZ(vm.filter.search,
            vm.filter.avaliacao,
            vm.filter.tema,
            vm.filter.subtema), 1, 3);

        Model = new(new(Guid.Empty, string.Empty, 0, Setting.UserBasicDetail.Matricula, DateTime.Now));
        Model.Tema = new JORNADA_BD_TEMAS_SUB_TEMA
        {
            ID_TEMAS = 0,
            ID_SUB_TEMAS = 0
        };
        vm.FilterChanged += FilterChanged;

        base.OnInitialized();
    }
    public void FilterChanged(bool value) => InvokeAsync(StateHasChanged);

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            //_jsmodule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", $"./{this.GetType().Name}.js");
            await vm.Get();
            Temas = await vm.GetTemas();
            vm.IsBusy = false;
            await InvokeAsync(StateHasChanged);
        }
        await base.OnAfterRenderAsync(firstRender);
    }
    private void OnSearchTema(OptionsSearchEventArgs<JORNADA_BD_TEMAS_SUB_TEMA> e)
    {
        var temas = Temas.GroupBy(x => x.ID_TEMAS).Select(x => x.First());
        e.Items = temas.Where(i => i.TEMAS.StartsWith(e.Text, StringComparison.OrdinalIgnoreCase))
                              .OrderBy(i => i.TEMAS);
    }
    private void OnSearchSubTema(OptionsSearchEventArgs<JORNADA_BD_TEMAS_SUB_TEMA> e)
    {
        var temas = Temas.Where(x => vm.filter.tema.Contains(x.ID_TEMAS.Value));
        e.Items = temas.Where(i => i.SUB_TEMAS.StartsWith(e.Text, StringComparison.OrdinalIgnoreCase))
                              .OrderBy(i => i.SUB_TEMAS);
    }
    async void Get(int? value)
    {
        vm.IsBusy = true;
        await vm.Get(value);
        vm.IsBusy = false;
        await InvokeAsync(StateHasChanged);
    }
    async void PostPublicacao()
    {
        Model.HORA = DateTime.Now;
        Model.SUB_TEMA = Model.Tema.ID_SUB_TEMAS;
        Model.Responsavel = new();
        var saida = await vm.PostPublicacao(Model);
        if (saida)
        {
            AddNewPublicacao = false;
            vm.IsBusy = true;
            Get(1);
            vm.IsBusy = false;
            await InvokeAsync(StateHasChanged);
            //vm.Data = vm.Data.Append(Model);
            //StateHasChanged();
        }
    }
    async void OpenNewPubliArea()
    {
        AddNewPublicacao = !AddNewPublicacao;
        if (AddNewPublicacao)
        {
            //var module = await Module;
            //await module.InvokeVoidAsync("FocusOnNewPubli");
        }
    }
    async void SetAvaliacaoToPublicacao(int? args, PUBLICACAO_SOLICITACAODTO argumento)
    {
        if (args.HasValue)
        {
            var result = await vm.PostAvaliacaoToPublicacao(args.Value, argumento.ID_SOLICITACAO_PUBLICACAO);
            if (!result)
            {
                App.Current.MainPage.ShowPopup(new MopUpAlert("Ocorreu algum erro ao realizar a avaliação neste momento."));
            }
            else
            {
                argumento.ActualAvaliacao = args.Value;
                //argumento.QtdAvaliacao += 1;
            }
        }
        StateHasChanged();
    }
    async void SetAvaliacaoToRespostaPublicacao(int? args, RESPOSTA_PUBLICACAODTO argumento)
    {
        if (args.HasValue)
        {
            var result = await vm.PostAvaliacaoToPublicacao(args.Value, argumento.ID_PUBLICACAO);
            if (!result)
            {
                App.Current.MainPage.ShowPopup(new MopUpAlert("Ocorreu algum erro ao realizar a avaliação neste momento."));
            }
            else
            {
                argumento.ActualAvaliacao = args.Value;
                //argumento.QtdAvaliacao += 1;
            }
        }
        StateHasChanged();
    }
    public void MouseFooterEnter()
    {
        FooterOpen = !FooterOpen;
        StateHasChanged();
    }

    public void MouseFooterLeave()
    {
        FooterOpen = !FooterOpen;
        StateHasChanged();
    }

    public void Dispose()
    {

    }
}