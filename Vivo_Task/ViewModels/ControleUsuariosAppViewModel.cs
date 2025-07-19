using Newtonsoft.Json;
using Vivo_Task.Shared_Static_Class.Data;
using System.ComponentModel;

using Vivo_Task.Models;
using Vivo_Task.Services;
using Vivo_Task.Shared_Static_Class.FundamentalModels;


namespace Vivo_Task.ViewModels
{
    public partial class ControleUsuariosAppViewModel : INotifyPropertyChanged
    {
        private IControleUsuariosAppService service;
        public ControleUsuariosAppViewModel(IControleUsuariosAppService service)
        {
            this.service = service;
        }

        public Command ReloadPage
        {
            get
            {
                return new Command(() =>
                {
                    CommaReloadPage();
                });
            }
        }
        public Command OpenFilter
        {
            get
            {
                return new Command(() =>
                {
                    this.IsFilterOpen = true;
                });
            }
        }

        public bool isFilterOpen = false;
        public bool IsFilterOpen
        {
            get => isFilterOpen;
            set
            {
                if (isFilterOpen == value) return;
                isFilterOpen = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsFilterOpen)));
            }
        }

        public async Task CommaReloadFilterData()
        {
            if (IsFilterBusy) return;
            IsFilterBusy = true;
            var result = await service.GetUsuariosFilter();
            if (result.IsSuccess)
            {
                filterdata = JsonConvert.DeserializeObject<ControleUsersFilterModel>(result.Content.ToString());
            }
            IsFilterBusy = false;
        }
        public async Task CommaReloadPage()
        {
            if (IsBusy) return;
            IsBusy = true;

            var result = await service.GetUsuarios(filter);
            if (result.IsSuccess)
            {
                actual_StatePage = JsonConvert.DeserializeObject<GenericStatePage<ACESSOS_MOBILE>>(result.Content.ToString());
                data = actual_StatePage.Data;
            }
            IsBusy = false;
        }

        public async Task<MainResponse> UpdateUser(ACESSOS_MOBILE user)
        {
            var result = await service.UpdateUsuarios(user);
            if (result.IsSuccess)
            {
                return result;
            }
            else
            {
                return new MainResponse
                {
                    Content = "",
                    IsSuccess = false,
                    ErrorMessage = "algum erro ocorreu"
                };
            }
        }
        public async Task<MainResponse> BloquearUsuario(string TP_AFASTAMENTO, string OBS, int id)
        {
            var result = await service.BloquearUsuarios(TP_AFASTAMENTO, OBS, id);
            if (result.IsSuccess)
            {
                return result;
            }
            else
            {
                return new MainResponse
                {
                    Content = "",
                    IsSuccess = false,
                    ErrorMessage = "algum erro ocorreu"
                };
            }
        }
        public async Task<MainResponse> DesbloquearUsuario(int id)
        {
            var result = await service.DesbloquearUsuarios(id);
            if (result.IsSuccess)
            {
                return result;
            }
            else
            {
                return new MainResponse
                {
                    Content = "",
                    IsSuccess = false,
                    ErrorMessage = "algum erro ocorreu"
                };
            }
        }
        public async Task GoLastPage(int TotalPage)
        {
            filter.PageNumber = TotalPage;
            IsBusy = true;

            var result = await service.GetUsuarios(filter);

            actual_StatePage = JsonConvert.DeserializeObject<GenericStatePage<ACESSOS_MOBILE>>(result.Content.ToString());
            data = actual_StatePage.Data;
            IsBusy = !IsBusy;
        }
        public async Task GoFirstPage()
        {
            filter.PageNumber = 1;
            IsBusy = true;

            var result = await service.GetUsuarios(filter);

            actual_StatePage = JsonConvert.DeserializeObject<GenericStatePage<ACESSOS_MOBILE>>(result.Content.ToString());
            data = actual_StatePage.Data;
            IsBusy = !IsBusy;
        }
        public async Task GoToPage(int PageNumber)
        {
            filter.PageNumber = PageNumber;
            IsBusy = true;

            var result = await service.GetUsuarios(filter);

            actual_StatePage = JsonConvert.DeserializeObject<GenericStatePage<ACESSOS_MOBILE>>(result.Content.ToString());
            data = actual_StatePage.Data;
            IsBusy = !IsBusy;
        }


        public List<ACESSOS_MOBILE> data;

        public ControleUsuariosFilterModel filter { get; set; } = new();
        public ControleUsersFilterModel filterdata { get; set; }
        public GenericStatePage<ACESSOS_MOBILE> actual_StatePage { get; set; }

        public bool isBusy = false;
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

        public bool isFilterBusy = false;
        public bool IsFilterBusy
        {
            get => isFilterBusy;
            set
            {
                if (isFilterBusy == value) return;
                isFilterBusy = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsFilterBusy)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}











