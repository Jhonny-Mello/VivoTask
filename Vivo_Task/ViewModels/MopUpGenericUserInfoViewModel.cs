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
using Vivo_Task.Model_DTO;
using Vivo_Task.Pages;
using Vivo_Task.Services;

namespace Vivo_Task.ViewModels
{
    public partial class MopUpGenericUserInfoViewModel : INotifyPropertyChanged
    {
        public ACESSOS_MOBILE_DTO User { get; set; } = new();
        public MopUpGenericUserInfoViewModel(ACESSOS_MOBILE_DTO User)
        {
            this.User = User;
        }

        private bool _isRotedRunning = false;
        public bool IsRotedRunning
        {
            get => _isRotedRunning;
            set
            {
                _isRotedRunning = value;
                OnPropertyChanged(nameof(IsRotedRunning));
            }
        }
        private bool _isRoted = false;
        public bool IsRoted
        {
            get => _isRoted;
            set
            {
                _isRoted = value;
                OnPropertyChanged(nameof(IsRoted));
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
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            var page = Shell.Current;
            page.BindingContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}











