using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Vivo_Task.Models;
using Vivo_Task.ModelDTO;
using Vivo_Task.Services;
using System.ComponentModel;
using Vivo_Task.Shared_Static_Class.Converters;
using Vivo_Task.Shared_Static_Class.Enums;

namespace Vivo_Task.ViewModels
{
    public abstract class AvaliacaoPageBase : Blazorise.BaseComponent, INotifyPropertyChanged
    {
        protected AvaliacaoPageBase()
        {
            Current = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static AvaliacaoPageBase Current;

        public class DropdownList
        {
            public int? Value { get; set; }
            public string Texto { get; set; }
        }
        public string _spinnerClass;

        private bool _modalVisible;
        public bool modalVisible
        {
            get => _modalVisible;
            set
            {
                _modalVisible = value;
                Current.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(modalVisible)));
            }
        }

        public Task ShowModal()
        {
            modalVisible = !modalVisible;
            this.StateHasChanged();
            return Task.CompletedTask;
        }

        public Task OnModalClosing(Blazorise.ModalClosingEventArgs e)
        {
            modalVisible = false;
            return Task.CompletedTask;
        }

        public static List<ListaAvaliacaoModel>? data { get; set; } = null;
        [Inject] public PreloadService PreloadService { get; set; }
        [Inject] public Blazorise.IPageProgressService PageProgressService { get; set; }
        [Inject] public IFormularioService service { get; set; }
        

        public async Task RefreshPage()
        {
            data = null;
            StateHasChanged();
            await PageProgressService.Go(null, options => { options.Color = Blazorise.Color.Light; });
            _spinnerClass = "spinner-border spinner-border-sm";
            await PageProgressService.Go(null, options => { options.Color = Blazorise.Color.Light; });
            var result = await service.GetListProvas_ByMatricula(Setting.UserBasicDetail.Matricula, Setting.UserBasicDetail.Cargo.GetDisplayName());
            if (result.IsSuccess)
            {
                data = JsonConvert.DeserializeObject<List<ListaAvaliacaoModel>>(result.Content.ToString());
            }
            else
            {
                await PageProgressService.Go(-1);
                PreloadService.Hide();
            }

            await PageProgressService.Go(100, options => { options.Color = Blazorise.Color.Light; });
            await PageProgressService.Go(-1);
            PreloadService.Hide();
            _spinnerClass = "";
            StateHasChanged();
        }
    }
}
