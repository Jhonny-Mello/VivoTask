using System.ComponentModel;
using Vivo_Task.Models;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using Vivo_Task.ViewModels;
using SkiaSharp;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Radzen.Blazor.Rendering;
using Vivo_Task.Pages;
using Vivo_Task.Services;

namespace Vivo_Task.ViewModels
{
    public partial class EdituserViewModel : INotifyPropertyChanged
    {
        public UserBasicDetail User { get; set; } = Setting.UserBasicDetail;
        public IEditUserService service;
        public EdituserViewModel(IEditUserService service)
        {
            this.service = service;
            this.User = Setting.UserBasicDetail;
            popup.Closed += OnPopupDismissed;
        }

        private string newone;
        public string Newone
        {
            get => newone;
            set
            {
                newone = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Newone)));
            }
        }

        private string confirmnewone;
        public string Confirmnewone
        {
            get => confirmnewone;
            set
            {
                confirmnewone = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Confirmnewone)));
            }
        }

        private string old;
        public string Old
        {
            get => old;
            set
            {
                old = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Old)));
            }
        }

        public MopUpBusyIndicator popup = new MopUpBusyIndicator();
        private void OnPopupDismissed(object sender, PopupClosedEventArgs e)
        {
            popup = new MopUpBusyIndicator();
            popup.Closed += OnPopupDismissed;
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

        public event PropertyChangedEventHandler PropertyChanged;
    }
}











