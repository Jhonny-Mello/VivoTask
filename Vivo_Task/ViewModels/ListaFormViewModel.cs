using BlazorBootstrap;
using Blazorise;
using Blazorise.LoadingIndicator;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Radzen;
using Vivo_Task.Shared_Static_Class.Data;
using System.ComponentModel;

using Vivo_Task.Models;
using Vivo_Task.Pages;
using Vivo_Task.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Vivo_Task.Shared_Static_Class.FundamentalModels;

namespace Vivo_Task.ViewModels
{
    public class ListaFormViewModel : INotifyPropertyChanged
    {
        public IMessageService MessageService;
        public IListaFormService _contextservice;
        public IAnswerFormViewModel _Formcontextservice;

        public ListaFormViewModel(IListaFormService contextservice,
                                  IMessageService messageService,
                                  IAnswerFormViewModel Formcontextservice)
        {
            _Formcontextservice = Formcontextservice;
            _contextservice = contextservice;
            MessageService = messageService;
            popup.Closed += OnPopupDismissed;
            LoadData();
        }
        public List<JORNADA_BD_QUESTION_HISTORICO> questions { get; set; }

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
                    await LoadData();
                });

            }
        }
        public async Task LoadData()
        {
            if (!IsBusy)
            {
                IsBusy = true;
            }
            var result = await _contextservice.GetFormsRotaByUser(
                (int)Setting.UserBasicDetail.Cargo,
                Setting.UserBasicDetail.Matricula,
                Setting.UserBasicDetail.Fixa,
                Setting.UserBasicDetail.Regional);

            if (result.IsSuccess)
            {
                Response<object> saida = JsonConvert.DeserializeObject<Response<object>>(result.Content.ToString());
                if (saida.Succeeded)
                {
                    questions = JsonConvert.DeserializeObject<List<JORNADA_BD_QUESTION_HISTORICO>>(saida.Data.ToString());
                    IsBusy = false;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(questions)));
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

        public async Task FinalizarForm(int cargo, int caderno, string tp_forms, bool fixa)
        {
            IsBusy = true;
            var result = await _contextservice.FinalizarForm(Setting.UserBasicDetail.Matricula, cargo, caderno, tp_forms, fixa);

            if (result.IsSuccess)
            {
                Response<object> saida = JsonConvert.DeserializeObject<Response<object>>(result.Content.ToString());
                if (saida.Succeeded)
                {
                    var questionschanged = JsonConvert.DeserializeObject<IEnumerable<JORNADA_BD_QUESTION_HISTORICO>>(saida.Data.ToString());
                    foreach (var changedQuestion in questionschanged)
                    {
                        var existingQuestion = questions.FirstOrDefault(q => q.ID_QUESTION == changedQuestion.ID_QUESTION);
                        questions.Remove(existingQuestion);
                    }
                    await App.Current.MainPage.ShowPopupAsync(new MopUpSuccessAlert("A prova foi finalizada com sucesso!"));
                    IsBusy = false;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBusy)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(questions)));
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
