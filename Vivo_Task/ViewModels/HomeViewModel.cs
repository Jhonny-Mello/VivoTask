using Blazorise;
using Blazorise.LoadingIndicator;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using PanCardView.Processors;
using Vivo_Task.Shared_Static_Class.FundamentalModels;
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
using System.Collections.Generic;

namespace Vivo_Task.ViewModels
{
    public partial class HomeViewModel : INotifyPropertyChanged
    {
        public ICardsService service;
        public readonly IAppService AppService;
        public HomeViewModel(ICardsService _service, IAppService _appService)
        {
            service = _service;
            AppService = _appService ?? throw new ArgumentNullException(nameof(_appService));

        }

        public IEnumerable<Cards_data> Cards
        { get => cards; set { cards = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Cards))); } }
        public async Task LoadData()
        {
            IsBusy = true;
            var result = await Task.WhenAll(
                LoadCard(service.Jornada_GetCards_Principal1()),
                LoadCard(service.Jornada_GetCards_Principal2()),
                LoadCard(service.Jornada_GetCards_Principal3()),
                LoadCard(service.Jornada_GetCards_Principal4()),
                LoadCard(service.Jornada_GetCards_Principal5()));

            if (result.Any())
            {
                foreach (var item in result)
                {
                    if (item.Any())
                    {
                        foreach (var card in item)
                        {
                            Cards = Cards.Append(card);
                        }
                    }
                }
            }

            //var Task_Cards = await service.Jornada_GetCards_Principal1();
            IsBusy = false;

            await Task.CompletedTask;
        }

        static async Task<IEnumerable<Cards_data>> LoadCard(Task<MainResponse> Task_Cards)
        {
            var result = await Task_Cards;
            IEnumerable<Cards_data> saida;

            try
            {
                saida = JsonConvert.DeserializeObject<IEnumerable<Cards_data>>(result.Content.ToString()) ?? [];
            }
            catch
            {
                return [];
            }

            return saida;
        }


        public async Task ErrorModel(Response<string> error)
        {
            App.Current.MainPage.ShowPopup(new MopUpAlert(error.Message));
        }

        public MopUpBusyIndicator popup = new MopUpBusyIndicator();

        private IEnumerable<Cards_data> cards = [];

        public bool isBusy = false;

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBusy)));

                //if (isBusy == true)
                //{
                //    MainThread.InvokeOnMainThreadAsync(() =>
                //    {
                //        Shell.Current.CurrentPage.ShowPopup(popup);
                //    });
                //}
                //else
                //{
                //    popup.IsBusy = false;
                //}
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

    }
}











