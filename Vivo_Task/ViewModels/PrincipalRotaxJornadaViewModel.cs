using Blazorise;
using Blazorise.LoadingIndicator;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Vivo_Task.Shared_Static_Class.FundamentalModels;
using System.ComponentModel;
using System.Text.RegularExpressions;

using Vivo_Task.Models;
using Vivo_Task.Services;

namespace Vivo_Task.ViewModels
{
    public class PrincipalRotaxJornadaViewModel : INotifyPropertyChanged
    {
        public IMessageService MessageService;
        public ILoadingIndicatorService ApplicationLoadingIndicatorService;
        public NavigationManager navigationManager;
        public UserBasicDetail Userservice;

        public PrincipalRotaxJornadaViewModel(
                                  IMessageService messageService,
                                  ILoadingIndicatorService applicationLoadingIndicatorService,
                                  NavigationManager navigationManager,
                                  UserBasicDetail userservice)
        {
            this.navigationManager = navigationManager;
            MessageService = messageService;
            ApplicationLoadingIndicatorService = applicationLoadingIndicatorService;
            Userservice = userservice;
            this.navigationManager = navigationManager;

        }
        public async Task ErrorModel(Response<string> error)
        {
            await MessageService.Error(error.Message, "Erro!");
        }

        public bool isBusy = true;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (isBusy == value) return;
                if (value == true)
                {
                    ApplicationLoadingIndicatorService.Show();
                }
                else
                {
                    ApplicationLoadingIndicatorService.Hide();
                }
                isBusy = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBusy)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
