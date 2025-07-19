using Blazorise;
using Blazorise.LoadingIndicator;
using Newtonsoft.Json;
using System.ComponentModel;
using Vivo_Task.ModelDTO;

using Vivo_Task.Models;
using Vivo_Task.Services;
using Vivo_Task.Pages;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.FundamentalModels;

namespace Vivo_Task.ViewModels
{
    public interface IAnswerFormViewModel
    {
        IEnumerable<JORNADA_BD_HIERARQUIum> CARTEIRA { get; set; }
        bool Finalizado { get; set; }
        bool IsBusy { get; set; }
        Shared_Static_Class.FundamentalModels.Formulario RespostaFormulario { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
        Task ErrorModel(Response<string> data);
        Task InsertRespostasQuestion(IEnumerable<JORNADA_BD_AVALIACAO_RETORNO> data);
        Task<int?> Insert_RESULTADO_PROVA(JORNADA_BD_ANSWER_AVALIACAO data);
        Task LoadData(int id);
        Task LoadDataCarteira(string regional);
    }
    public class AnswerFormViewModel : INotifyPropertyChanged, IAnswerFormViewModel
    {
        public IAnswerFormService _contextservice;
        public IMessageService MessageService;

        public AnswerFormViewModel(IAnswerFormService contextservice,
                                  IMessageService messageService)
        {
            _contextservice = contextservice;
            MessageService = messageService;
            popup.Closed += OnPopupDismissed;
        }
        public IEnumerable<JORNADA_BD_HIERARQUIum> CARTEIRA { get; set; }
        public Shared_Static_Class.FundamentalModels.Formulario RespostaFormulario { get; set; } = new();
        public async Task LoadData(int id)
        {
            if (!IsBusy)
            {
                IsBusy = true;
            }
            var result = await _contextservice.GetForm(id);

            if (result.IsSuccess)
            {
                Response<object> saida = JsonConvert.DeserializeObject<Response<object>>(result.Content.ToString());
                if (saida.Succeeded)
                {
                    RespostaFormulario.QUESTIONS = JsonConvert.DeserializeObject<List<QUESTIONS>>(saida.Data.ToString());
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
        public async Task LoadDataCarteira(string regional)
        {
            if (!IsBusy)
            {
                IsBusy = true;
            }
            var result = await _contextservice.GetDataCarteira(regional);

            if (result.IsSuccess)
            {
                Response<object> saida = JsonConvert.DeserializeObject<Response<object>>(result.Content.ToString());
                if (saida.Succeeded)
                {
                    CARTEIRA = JsonConvert.DeserializeObject<IEnumerable<JORNADA_BD_HIERARQUIum>>(saida.Data.ToString());
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

        public async Task<int?> Insert_RESULTADO_PROVA(JORNADA_BD_ANSWER_AVALIACAO data)
        {
            var result = await _contextservice.InsertResultadoProva(data);

            if (result.IsSuccess)
            {
                Response<object> saida = JsonConvert.DeserializeObject<Response<object>>(result.Content.ToString());
                if (saida.Succeeded)
                {
                    var id = JsonConvert.DeserializeObject<int>(saida.Data.ToString());
                    return id;
                }
                else
                {
                    var erro = JsonConvert.DeserializeObject<Response<string>>(result.Content.ToString());
                    await ErrorModel(erro);
                    return null;
                }
            }
            return null;
        }

        public async Task InsertRespostasQuestion(IEnumerable<JORNADA_BD_AVALIACAO_RETORNO> data)
        {
            var result = await _contextservice.InsertRespostasQuestion(data);

            if (result.IsSuccess)
            {
                Response<object> saida = JsonConvert.DeserializeObject<Response<object>>(result.Content.ToString());
                if (saida.Succeeded)
                {
                    return;
                }
                else
                {
                    var erro = JsonConvert.DeserializeObject<Response<string>>(result.Content.ToString());
                    await ErrorModel(erro);
                    return;
                }
            }
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
        private bool finalizado = false;

        public bool Finalizado
        {
            get => finalizado;
            set
            {
                if (finalizado == value) return;
                finalizado = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Finalizado)));
            }
        }
        private bool isBusy = false;
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
