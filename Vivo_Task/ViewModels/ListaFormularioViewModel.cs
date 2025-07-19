using BlazorBootstrap;
using Blazorise;
using Vivo_Task.Shared_Static_Class.Converters;
using Vivo_Task.Shared_Static_Class.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.Maui;
using Newtonsoft.Json;
using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.Enums;

using System;
using System.ComponentModel;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Vivo_Task.ModelDTO;
using Vivo_Task.Models;
using Vivo_Task.Services;


namespace Vivo_Task.ViewModels
{
    public partial class ListaFormularioViewModel : INotifyPropertyChanged
    {
        public ListaFormularioViewModel(IFormularioService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public readonly IFormularioService _service;
        private List<JORNADA_BD_QUESTION_HISTORICO>? _data;
        public List<JORNADA_BD_QUESTION_HISTORICO>? data
        {
            get => _data;
            set
            {
                _data = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(data)));
            }
        }
        public PreloadService PreloadService = new();

        public async void DetailsPage(JORNADA_BD_QUESTION_HISTORICO item) => await Shell.Current.GoToAsync($"/PopUpFormularioDetails",
            new Dictionary<string, object> {
                    { "CADERNO", item.CADERNO},
                    { "TIPO_FORMS", item.TP_FORMS},
                    { "CARGO", item.CARGO },
                    { "FIXA", item.FIXA },
            });

        public async void FinalizarForm(JORNADA_BD_QUESTION_HISTORICO item)
        {
            if (await App.Current.MainPage.DisplayActionSheet("Tem certeza que deseja finalizar este formulário?", null, null, new string[]
            {"Sim","Näo"}) == "Sim")
            {
                var respose = await _service.DeleteFormulario(item);
                if (respose.IsSuccess)
                {
                    await App.Current.MainPage.DisplayAlert("Tudo certo", "O formulário foi finalizado com sucesso", "ok!");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Algum erro ocorreu", "Não conseguimos finalizar este formulário, por favor tente novamente", "ok!");
                }

                await Shell.Current.GoToAsync("/CriarFormulario");
                ReloadPageComma();
            }
            else
            {

            }
        }
        public async Task ReloadPageComma()
        {
            IsBusy = true;
            carregado = false;
            List<JORNADA_BD_QUESTION_HISTORICO>? dataQuestions = new();
            _spinnerClass = "spinner-border spinner-border-sm";

            var jornada = await _service.GetAllEnableFormJornada(Setting.UserBasicDetail.Canal.GetDisplayName(), Setting.UserBasicDetail.Cargo.GetDisplayName(), Setting.UserBasicDetail.Matricula);
            var rotina = await _service.GetAllEnableFormRotina(Setting.UserBasicDetail.Canal.GetDisplayName(), Setting.UserBasicDetail.Cargo.GetDisplayName(), Setting.UserBasicDetail.Matricula);
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

            data = dataQuestions;

            _spinnerClass = "";
            carregado = !carregado;
            IsBusy = !IsBusy;
        }

        public Command ReloadPage
        {
            get
            {
                return new Command(() =>
                {
                    ReloadPageComma();
                });
            }
        }
        public async Task ModalClosingEvent(Blazorise.ModalClosingEventArgs args)
        {
            modalVisible = !modalVisible;
        }

        public void FilterModalComma()
        {
            modalVisible = !modalVisible;
        }

        public Command FilterModal
        {
            get
            {
                return new Command(() =>
                {
                    modalVisible = !modalVisible;
                });
            }
        }


        public string spinnerClass;

        public string _spinnerClass
        {
            get => spinnerClass;
            set
            {
                spinnerClass = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_spinnerClass)));
            }
        }

        public bool _modalVisible;

        public bool modalVisible
        {
            get => _modalVisible;
            set
            {
                _modalVisible = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(modalVisible)));
            }
        }
        public bool Carregado;

        public bool carregado
        {
            get => Carregado;
            set
            {
                Carregado = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(carregado)));
            }
        }

        public bool isBusy;

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBusy)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}











