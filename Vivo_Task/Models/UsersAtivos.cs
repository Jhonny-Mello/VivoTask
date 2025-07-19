using Newtonsoft.Json;
using Vivo_Task.Shared_Static_Class.FundamentalModels;
using System.ComponentModel;
using Vivo_Task.Services;

namespace Vivo_Task.Models
{
    public class UsersAtivos : INotifyPropertyChanged
    {
        private List<AcessoModel> usuariosAtivos { get; set; } = new();

        public List<AcessoModel> UsuariosAtivos
        {
            get => usuariosAtivos;
            set
            {
                usuariosAtivos = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UsuariosAtivos)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }

}
