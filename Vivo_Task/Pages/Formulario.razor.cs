using CommunityToolkit.Maui.Views;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Radzen;
using Vivo_Task.Shared_Static_Class.Converters;
using Vivo_Task.Shared_Static_Class.Data;
using System.ComponentModel;
using System.Globalization;
using Vivo_Task.ModelDTO;
using Vivo_Task.Models;
using Vivo_Task.Shared_Static_Class.FundamentalModels;
using Vivo_Task.Shared_Static_Class.Enums;
using Microsoft.JSInterop;

namespace Vivo_Task.Pages
{
    public partial class Formulario
    {
        [Parameter]
        public int Caderno { get; set; }
        [Parameter]
        public string TIPO_FORMS { get; set; }
        [Parameter]
        public string CARGO { get; set; }
        [Parameter]
        public string FIXA { get; set; }
        [Parameter] 
        public int ID_PROVA { get; set; }
        [Inject]IJSRuntime JSRuntime { get; set; }
        public BlazorBootstrap.Modal Filter;

        public string _spinnerClass = "";
        private string selectedStep = "Inicio";
        string loading = "";
        public Blazorise.Steps stepsRef;
        private BlazorBootstrap.Modal modalRef;
        private BlazorBootstrap.Modal modal;


        private TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        bool FirstModal = false;
        bool Finalizado = false;
        double nota;
        List<JORNADA_BD_AVALIACAO_RETORNO> RESPOSTAS = new();
        JORNADA_BD_ANSWER_AVALIACAO HISTORICO_PROVA = new();
        private bool firstRenderComplete;

        private async Task OnBeforeInternalNavigation(LocationChangingContext context)
        {

        }

        private bool NavigationAllowed(Blazorise.StepNavigationContext context)
        {
            if (!(context.CurrentStepName is null && context.NextStepName == "Fim"))
            {
                if ((service.RespostaFormulario.DDD_AVALIADO is null // Caso ele tente sair do inicio sem responder os campos de identificação
                   || service.RespostaFormulario.RE_AVALIADO is null
                   || service.RespostaFormulario.REDE_AVALIADA is null
                   || service.RespostaFormulario.PDV_AVALIADO is null) && context.NextStepName != "Inicio")
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        App.Current.MainPage.ShowPopup(new MopUpAlert($"Por favor informe todos os campos de identificação para poder passar para a próxima etapa!"));
                    });
                    return false;
                }
                else
                {
                    if (Int32.TryParse(context.NextStepName, out int Next) && Int32.TryParse(context.CurrentStepName, out int Current)) // Tenta passar o proximo passo nome para numero
                    {
                        if (Next != 1) //Caso ele não esteja tentando ir para a primeira questão
                        {
                            if (Next > Current + 1 && service.RespostaFormulario.QUESTIONS[Next - 1].RESPOSTA is null)
                            {
                                Device.BeginInvokeOnMainThread(() =>
                                {
                                    App.Current.MainPage.ShowPopup(new MopUpWarningAlert($"Você precisa responder a prova em sequência, a próxima pergunta é: {Current + 1} e não {Next}"));
                                });
                                //service.MessageService.Info();
                                return false;
                            }
                            else if (Next > Current && service.RespostaFormulario.QUESTIONS[Current - 1].RESPOSTA is null) //Caso ele tente ir para as próximas sem responder a atual
                            {
                                Device.BeginInvokeOnMainThread(() =>
                                {
                                    App.Current.MainPage.ShowPopup(new MopUpWarningAlert($"Você precisa responder a pergunta {Current} para passar para a próxima"));
                                });
                                return false;
                            }

                        }
                    }
                    else // Caso não consiga transformar em numero ou é inicio ou fim
                    {
                        if (service.RespostaFormulario.QUESTIONS.Any(x => x.RESPOSTA is null) && context.NextStepName == "Fim")
                        {
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                App.Current.MainPage.ShowPopup(new MopUpAlert($"Você ainda não respondeu todas as perguntas, não chegará ao fim sem responde-las."));
                            });

                            return false;
                        }

                    }
                }
            }

            return true;
        }

        private void OnAlternativaClicked(QUESTIONS question, ALTERNATIVAS alternativa)
        {
            foreach (var item_AL in question.ALTERNATIVAS)
            {
                item_AL.RESPOSTA_ESCOLHIDA = (item_AL == alternativa);
            }
            // Notifica o Blazor sobre a mudança na propriedade RESPOSTA_ESCOLHIDA
            StateHasChanged();
        }

        public async Task VizualizarGabarito()
        {
            await modalRef.HideAsync();
            await Filter.ShowAsync();
        }

        public async Task FinalizarForm()
        {
            await Shell.Current.GoToAsync("../");
            service.Finalizado = false;
            service.RespostaFormulario = new();
        }

        public async Task REDEChanged(string args)
        {
            if (!string.IsNullOrEmpty(args))
            {
                service.RespostaFormulario.REDE_AVALIADA = args;
            }
            service.RespostaFormulario.DDD_AVALIADO = service.CARTEIRA.Where(x => x.REDE == service.RespostaFormulario.REDE_AVALIADA)
                                                       .Select(x => x.DDD).FirstOrDefault().ToString();
            service.RespostaFormulario.PDV_AVALIADO = service.CARTEIRA.Where(x => x.REDE == service.RespostaFormulario.REDE_AVALIADA
                                                    && x.DDD == int.Parse(service.RespostaFormulario.DDD_AVALIADO))
                                                    .Select(x => x.ADABAS).FirstOrDefault();
        }

        public async Task DDDChanged(string args)
        {
            if (!string.IsNullOrEmpty(args))
            {
                service.RespostaFormulario.DDD_AVALIADO = args;
            }
            service.RespostaFormulario.PDV_AVALIADO = service.CARTEIRA.Where(x => x.REDE == service.RespostaFormulario.REDE_AVALIADA
                                                    && x.DDD == int.Parse(service.RespostaFormulario.DDD_AVALIADO))
                                                    .Select(x => x.ADABAS).FirstOrDefault();
        }
        public async Task FinalizarProva()
        {
            service.IsBusy = true;
            double pontuacao = 0;
            double pontuacaoalternativa = 0;
            double pontuacaoporquestao = (double)(100.00 / service.RespostaFormulario.QUESTIONS.Count());

            foreach (var item in service.RespostaFormulario.QUESTIONS)
            {
                foreach (var alternativa in item.ALTERNATIVAS)
                {
                    if (item.TP_QUESTAO != "MULTIPLA ESCOLHA")
                    {
                        if (alternativa.RESPOSTA_ESCOLHIDA == true && alternativa.RESPOSTA_CORRETA == true)
                        {
                            pontuacao++;
                        }
                    }
                    else
                    {
                        double pontuacaoSingleAlternativa = 0;
                        double pesoAlternativa = (double)(1.00 / item.ALTERNATIVAS.Where(x => x.RESPOSTA_CORRETA == true).Count());

                        if (alternativa.RESPOSTA_ESCOLHIDA == true && alternativa.RESPOSTA_CORRETA == true)
                        {
                            pontuacaoSingleAlternativa++;
                        }
                        else if (alternativa.RESPOSTA_ESCOLHIDA == true && alternativa.RESPOSTA_CORRETA == false)
                        {
                            pontuacaoSingleAlternativa--;
                        }

                        double notaalternativa = pesoAlternativa * pontuacaoSingleAlternativa;
                        alternativa.PESO = notaalternativa;
                        pontuacaoalternativa = pontuacaoalternativa + notaalternativa;

                    }
                }

                RESPOSTAS.Add(new JORNADA_BD_AVALIACAO_RETORNO
                {
                    ID_PROVA = ID_PROVA,
                    CADERNO = Caderno,
                    DT_AVALIACAO = DateTime.Now,
                    TP_FORMS = TIPO_FORMS,
                    PUBLICO_CANAL = ((int)DePara.CanalCargoEnum(((Cargos)int.Parse(CARGO)))),
                    PUBLICO_CARGO = int.Parse(CARGO),
                    MATRICULA_APLICADOR = Setting.UserBasicDetail.Matricula,
                    TEMAS = string.Join(";", item.TEMA.Select(x => x.TEMAS).Distinct()),
                    ID_SUB_TEMAS = item.SUB_TEMA,
                    ID_QUESTION = item.ID_QUESTION,
                    PESO = Math.Round(pontuacaoporquestao, 1).ToString(),
                    RESPOSTA_USER = string.Join(";", item.ALTERNATIVAS.Where(x => x.RESPOSTA_ESCOLHIDA == true).Select(x => x.ID_ALTERNATIVA)),
                    REDE_AVALIADA = service.RespostaFormulario.REDE_AVALIADA,
                    DDD_AVALIADO = int.Parse(service.RespostaFormulario.DDD_AVALIADO),
                    PDV_AVALIADO = service.RespostaFormulario.PDV_AVALIADO,
                    RE_AVALIADO = service.RespostaFormulario.RE_AVALIADO.Value,
                    STATUS_RESPOSTA = item.ALTERNATIVAS.Where(y => y.RESPOSTA_CORRETA == true).Any(x => x.RESPOSTA_ESCOLHIDA == true),
                    REGIONAL = Setting.UserBasicDetail.Regional
                });
            }
            if (pontuacaoalternativa >= 0)
            {
                pontuacao = pontuacao + (int)Math.Round(pontuacaoalternativa);
            }

            nota = pontuacaoporquestao * pontuacao;
            HISTORICO_PROVA = new JORNADA_BD_ANSWER_AVALIACAO
            {
                TP_FORMS = TIPO_FORMS,
                ID_TEMAS = string.Join(";", service.RespostaFormulario.GetDistinctTemas()),
                ID_SUB_TEMAS = string.Join(";", service.RespostaFormulario.GetDistinctSubTemas()),
                CADERNO = Caderno,
                PUBLICO_CANAL = ((int)DePara.CanalCargoEnum(((Cargos)int.Parse(CARGO)))),
                PUBLICO_CARGO = int.Parse(CARGO),
                MATRICULA_APLICADOR = Setting.UserBasicDetail.Matricula,
                DT_AVALIACAO = DateTime.Now,
                NOME_APLICADOR = Setting.UserBasicDetail.Name,
                NOTA = (decimal)Math.Round(nota, 1),
                REDE_AVALIADA = service.RespostaFormulario.REDE_AVALIADA,
                DDD_AVALIADO = Setting.UserBasicDetail.DDD,
                PDV_AVALIADO = service.RespostaFormulario.PDV_AVALIADO,
                RE_AVALIADO = service.RespostaFormulario.RE_AVALIADO.Value,
                REGIONAL = Setting.UserBasicDetail.Regional,
                ID_PROVA = ID_PROVA
            };


            int? id = await service.Insert_RESULTADO_PROVA(HISTORICO_PROVA);

            if (id is null)
            {
                return;
            }

            RESPOSTAS.ForEach(x => x.ID_PROVA_RESPONDIDA = id);

            await service.InsertRespostasQuestion(RESPOSTAS);
            await modal.HideAsync();
            service.IsBusy = false;
            Finalizado = true;
            await modalRef.ShowAsync();
            this.StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            await service.LoadData(ID_PROVA);
            await service.LoadDataCarteira(Setting.UserBasicDetail.Regional);
            service.PropertyChanged += OnStateChanged;
            await base.OnInitializedAsync();
        }

        private void OnStateChanged(object? sender, PropertyChangedEventArgs e) => StateHasChanged();


        void IDisposable.Dispose()
        {
            // Unsubscribe from the event when our component is disposed
            service.PropertyChanged -= OnStateChanged;
        }

        public async Task TopFieldSet(int idFieldSet)
        {
            await JSRuntime.InvokeVoidAsync("TopFildset", idFieldSet);
        }

    }
}