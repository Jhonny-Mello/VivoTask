using Blazorise;
using Blazorise.LoadingIndicator;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using PanCardView.Processors;
using System.ComponentModel;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Input;

using Vivo_Task.Model_DTO;
using Vivo_Task.Models;
using Vivo_Task.Pages;
using Vivo_Task.Services;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace Vivo_Task.ViewModels
{
    public partial class HomeJornadaViewModel : INotifyPropertyChanged
    {
        public IDispatcherTimer _timerScroll;
        public IEnumerable<CardsPrincipaisModel> cards => 
            [new CardsPrincipaisModel("PROVAS DISPONÍVEIS","Aqui você encontrará todas as provas que estão disponíveis para você","fazendoprova.jpg", new Command(() => Shell.Current.GoToAsync("../Jornada/ListaFormularios"))),
            new CardsPrincipaisModel("RESULTADOS","Resultado detalhado de todas as provas respondidas ou aplicadas por você","resultadoprova.jpg", new Command(() => Shell.Current.GoToAsync("../Jornada/Avaliacoes"))),
            new CardsPrincipaisModel("CRIAR PROVAS","Criar uma nova prova de forma aleatória baseado nos temas escolhidos","criandoprovas.jpg", new Command(() => Shell.Current.GoToAsync("../Jornada/CriarFormulario"))),
            new CardsPrincipaisModel("CARDS JORNADA","Compartilhar ou baixar cards informativos criados pelo consumer sobre a jornada do conhecimento","cardsjornada.png", new Command(() => Shell.Current.GoToAsync("../Cards/CardsConsumer"))),
            new CardsPrincipaisModel("LINKS JORNADA","Acesso a conteúdos recomendados pelo consumer sobre a jornada do conhecimento","linksjornada2.png", new Command(() => Shell.Current.GoToAsync("../Cards/LinksConsumer"))),
            new CardsPrincipaisModel("FÓRUM GIRO V","Lugar reservado para tirar dúvidas com especialistas e compartilhar conhecimentos com os demais.","forum.png",new Command(() => Shell.Current.GoToAsync($"../Jornada/{nameof(PainelForumGiroV)}")))
            ];

        public ICardsService service;
        public IEnumerable<RakingJornada> rankingtop10 => _ranking.Skip(3).Take(7) ?? [];
        public IEnumerable<RakingJornada> rankingtop30 => _ranking.Skip(10) ?? [];
        public bool _isFocused = false;
        public bool isFocused
        {
            get => _isFocused;
            set
            {
                _isFocused = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(isFocused)));
            }
        }

        public RakingJornada[] ranking
        {
            get => _ranking;
            set
            {
                _ranking = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ranking)));
            }
        }

        public RakingJornada Primeiro
        {
            get => _primeiro;
            set
            {
                _primeiro = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Primeiro)));
            }
        }

        public RakingJornada Segundo
        {
            get => _segundo;
            set
            {
                _segundo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Segundo)));
            }
        }

        public RakingJornada Terceiro
        {
            get => _terceiro;
            set
            {
                _terceiro = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Terceiro)));
            }
        }


        public Command CriarFormulario
        {
            get => new Command(async () =>
            {
                await Shell.Current.GoToAsync("../Jornada/CriarFormulario");
            });
        }
        public Command ListaFormulario
        {
            get => new Command(async () =>
            {
                await Shell.Current.GoToAsync("../Jornada/ListaFormularios");
            });
        }
        public Command Avaliacoes
        {
            get => new Command(async () =>
            {
                await Shell.Current.GoToAsync("../Jornada/Avaliacoes");
            });
        }
        public Command RotaCardsJornada
        {
            get => new Command(async () =>
            {
                await Shell.Current.GoToAsync("../Cards/CardsConsumer");
            });
        }
        public Command RotaLinksJornada
        {
            get => new Command(async () =>
            {
                await Shell.Current.GoToAsync("../Cards/LinksConsumer");
            });
        }
        public Command RotaForumGiroV
        {
            get => new Command(async () =>
            {
                await Shell.Current.GoToAsync($"../Jornada/{nameof(PainelForumGiroV)}");
            });
        }

        public HomeJornadaViewModel(ICardsService _service)
        {

            //if (_timerScroll == null)
            //{
            //    _timerScroll = Application.Current.Dispatcher.CreateTimer();
            //    _timerScroll.Interval = TimeSpan.FromMilliseconds(500);
            //    _timerScroll.Start();
            //    _timerScroll.IsRepeating = true;
            //}

            service = _service;
#if DEBUG
            Environment = "Development";
#elif TEST
                Environment = "Test";
#endif
        }

        public string Environment = "Production";

        public async Task LoadRanking()
        {
            isRankingBusy = true;
            var list = await service.GetRankingData();
            ranking = list.ToArray();

            Primeiro = ranking[0];
            Segundo = ranking[1];
            Terceiro = ranking[2];

            isRankingBusy = false;
        }

        private string _pontuaçãoClass = "pontuacao";
        private double _pontuação;
        private double _media;
        private RakingJornada _primeiro = new(new(), 1, 0, 0);
        private RakingJornada _segundo = new(new(), 2, 0, 0);
        private RakingJornada _terceiro = new(new(), 3, 0, 0);

        private RakingJornada[] _ranking = [];

        public bool isRankingBusy = false;
        public bool IsRankingBusy
        {
            get => isRankingBusy;
            set
            {
                isRankingBusy = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRankingBusy)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

    }
}











