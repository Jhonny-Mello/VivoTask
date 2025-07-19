using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Maui.Views;
using Vivo_Task.Models;
using Vivo_Task.ViewModels;

namespace Vivo_Task.Pages;

public partial class Home : ContentPage
{
    private IFileSaver _fileSaver;
    private HomeViewModel _vm;
    IDispatcherTimer _timer;
    private bool isrunning { get; set; } = false;
    public Home(HomeViewModel vm, IFileSaver fileSaver)
    {
        _timer = Application.Current.Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromSeconds(3.5);
        _timer.Tick += OnDispatcherTimer;
        _timer.IsRepeating = true;

        _timer.Start();
        _vm = vm;
        _fileSaver = fileSaver;

        InitializeComponent();

        carouselView.UserInteracted += CarouselView_UserInteracted;
        rotaxjornada.Command = Jornada;
        //vivomais.Command = VivoMais;
        //cardsconsumer.Command = CardsConsumer;
    }

    private void CarouselView_UserInteracted(PanCardView.CardsView view, PanCardView.EventArgs.UserInteractedEventArgs args)
    {
        if (args.Status == PanCardView.Enums.UserInteractionStatus.Started)
        {
            _timer.Stop();
        }

        if (args.Status == PanCardView.Enums.UserInteractionStatus.Ended)
        {
            _timer = Application.Current.Dispatcher.CreateTimer();
            _timer.Interval = TimeSpan.FromSeconds(3.5);
            _timer.Tick += OnDispatcherTimer;
            _timer.IsRepeating = true;
            _timer.Start();
        }
    }

    async void OnDispatcherTimer(object sender, EventArgs e)
    {
        var actual = carouselView.SelectedIndex;
        if (!carouselView.IsUserInteractionRunning)
        {
            if (actual++ != _vm.Cards.Count())
            {
                carouselView.SelectedIndex = actual++;
            }
            else
            {
                carouselView.SelectedIndex = 0;
            }
        }
    }

    protected override async void OnAppearing()
    {
        BindingContext = _vm;

        if (!_vm.Cards.Any())
        {
            await _vm.LoadData();
        }


        var saida = await _vm.AppService.GetLatestVersionAvailableOnStore();

        if (!saida)
        {
            var result = await Application.Current.MainPage.ShowPopupAsync(new MopUpUpdateApp());
            if (!(bool)result)
            {
                Environment.Exit(0);
            }
            else
            {
                string playStoreUrl = "urlplaystore";

                await Launcher.OpenAsync(new Uri(playStoreUrl));
                Environment.Exit(0);
            }
        }
        base.OnAppearing();

    }

    private void Button_Clicked(object sender, TappedEventArgs e)
    {
        var item = e?.Parameter as Cards_data;

        if (item != null)
        {
            MainThread.InvokeOnMainThreadAsync(() =>
            {
                Shell.Current.CurrentPage.ShowPopup(new MopUpShowImage(item, _fileSaver));
            });
        }
    }

    public Command Jornada
    {
        get => new Command(async () =>
        {
            if (!isrunning)
            {
                isrunning = true;
                await Shell.Current.GoToAsync("//Home/Home.VivoTask/Home.RTCZ",true);
                isrunning = false;
            }
        });
    }

    protected override void OnDisappearing()
    {
        carouselView.UserInteracted -= CarouselView_UserInteracted;
        _timer.Tick -= OnDispatcherTimer;
        base.OnDisappearing();
    }

}