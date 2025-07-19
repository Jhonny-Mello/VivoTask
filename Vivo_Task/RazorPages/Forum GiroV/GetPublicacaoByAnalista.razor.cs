using Microsoft.AspNetCore.Components;
using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.Model_DTO;
using Vivo_Task.Shared_Static_Class.Model_DTO.FilterModels;
using System.ComponentModel;
using System.Globalization;
using Vivo_Task.ViewModels;
using Microsoft.JSInterop;
using Vivo_Task.Models;

namespace Vivo_Task.RazorPages.Forum_GiroV;
public partial class GetPublicacaoByAnalista : ComponentBase, IDisposable
{
    //[CascadingParameter]  Model
    TextInfo textInfo = new CultureInfo("pt-BR", false).TextInfo;
    bool FooterOpen { get; set; } = false;
    bool AddNewPublicacao { get; set; } = false;
    [CascadingParameter] public RESPOSTA_PUBLICACAODTO Model { get; set; } = null;
    private IEnumerable<JORNADA_BD_TEMAS_SUB_TEMA> Temas { get; set; } = [];
    string value { get; set; }
    [Inject] ForumRTCZViewModel vm { get; set; }
    private void OnStateChanged(object? sender, PropertyChangedEventArgs e) => InvokeAsync(StateHasChanged);
    protected override void OnInitialized()
    {
        vm.PropertyChanged += OnStateChanged;
        vm.filterPagination = new(new PainelForumRTCZ(vm.filter.search,
            vm.filter.avaliacao,
            vm.filter.tema,
            vm.filter.subtema), 1, 3);

        vm.FilterChanged += FilterChanged;

        base.OnInitialized();
    }

    public void FilterChanged(bool value) => InvokeAsync(StateHasChanged);
    void OpenResposta(PUBLICACAO_SOLICITACAODTO item)
    {
        if (!item.ShowRespostas)
            Model = new(Guid.Empty, item.ID_SOLICITACAO_PUBLICACAO, DateTime.Now, Setting.UserBasicDetail.Matricula, string.Empty);

        item.ShowRespostas = !item.ShowRespostas;
    }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            //_jsmodule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Shared_Razor_Components/Shared/ProdutoCard.razor.js");
            vm.IsBusy = true;
            await vm.GetByAnalista();
            Temas = await vm.GetTemas(true);
            vm.IsBusy = false;
            await InvokeAsync(StateHasChanged);
        }
        await base.OnAfterRenderAsync(firstRender);
    }
    async void Get(int? value)
    {
        vm.IsBusy = true;
        await vm.GetByAnalista(value);
        vm.IsBusy = false;
        await InvokeAsync(StateHasChanged);
    }
    async void PostRespostaPublicacao(PUBLICACAO_SOLICITACAODTO item)
    {
        Model.HORA = DateTime.Now;
        Model.Solicitante = new();
        var saida = await vm.PostRespostaPublicacao(Model);
        if (saida)
        {
            vm.IsBusy = true;
            //AddNewPublicacao = false;
            item.Respostasdto = [];
            item.Respostasdto.Add(Model);
            //Get(1);
            vm.IsBusy = false;
            await InvokeAsync(StateHasChanged);
            //vm.Data = vm.Data.Append(Model);
        }
    }
    async void SetAvaliacaoToPublicacao(int? args, PUBLICACAO_SOLICITACAODTO argumento)
    {
        if (args.HasValue)
        {
            var result = await vm.PostAvaliacaoToPublicacao(args.Value, argumento.ID_SOLICITACAO_PUBLICACAO);
            if (!result)
            {
                await vm.FluentDialog.ShowErrorAsync("Ocorreu algum erro ao realizar a avalia��o neste momento.", "Desculpe :(");
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
                await vm.FluentDialog.ShowErrorAsync("Ocorreu algum erro ao realizar a avalia��o neste momento.", "Desculpe :(");
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