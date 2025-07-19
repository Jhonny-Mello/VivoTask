
using Newtonsoft.Json;
using Vivo_Task.Shared_Static_Class.FundamentalModels;
using System.ComponentModel;
using System.Globalization;
using Vivo_Task.Shared_Static_Class.Converters;
using Vivo_Task.Shared_Static_Class.Enums;

namespace Vivo_Task.Models
{
    public class UserBasicDetail : INotifyPropertyChanged
    {
        [JsonIgnore]
        private TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        [JsonIgnore]
        private bool _isRotedRunning = false;
        [JsonIgnore]
        public bool IsRotedRunning
        {
            get => _isRotedRunning;
            set
            {
                _isRotedRunning = value;
                OnPropertyChanged(nameof(IsRotedRunning));
            }
        }
        [JsonIgnore]
        private bool _isRoted = false;
        [JsonIgnore]
        public bool IsRoted
        {
            get => _isRoted;
            set
            {
                _isRoted = value;
                OnPropertyChanged(nameof(IsRoted));
            }
        }
        public string Name { get; set; }
        public Cargos Cargo { get; set; }
        public Canal Canal { get; set; }
        public string Pdv { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public string Uf { get; set; }
        public string exp { get; set; }
        public bool AdmView
        {
            get
            {
                return Cargo == Cargos.ADM;
            }
        }
        public bool VivoMaisView
        {
            get
            {
                return false;
            }
        }

        public bool PainelRotaView
        {
            get
            {
                return false;
            }
        }

        public bool JornadaView
        {
            get
            {
                return (
                    Perfil.Any(
                    x => x.Perfil_Plataforma.ID_PERFIL == 1
                    || x.Perfil_Plataforma.ID_PERFIL == 8
                    || x.Perfil_Plataforma.ID_PERFIL == 7
                    || x.Perfil_Plataforma.ID_PERFIL == 9));
            }
        }
        public bool CriarFormJornadaView
        {
            get
            {
                return (Perfil.Any(
                    x => x.Perfil_Plataforma.ID_PERFIL == 9
                    || x.Perfil_Plataforma.ID_PERFIL == 7
                    || x.Perfil_Plataforma.ID_PERFIL == 1
                    )
                    );
            }
        }

        public int Matricula { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Email { get; set; }
        public int DDD { get; set; }
        public string Regional { get; set; }
        public bool Fixa { get; set; }
        public IEnumerable<Perfil> Perfil { get; set; } = new List<Perfil>();
        public bool IsSuporte()
        {
            if (this.Perfil.Any(x => x.Perfil_Plataforma.ID_PERFIL == 1))
            {
                return true;
            }
            return false;
        }
        public string FirstName { get => textInfo.ToTitleCase(this.Name.Split()[0].ToLower()); }
        public string BeautifulName { get => textInfo.ToTitleCase(this.Name.ToLower()); }
        [JsonIgnore]
        public byte[] _imageBase64Data { get; set; }
        private string _userAvatar;
        public string UserAvatar
        {
            get => _userAvatar;
            set
            {
                _userAvatar = value;
                OnPropertyChanged(nameof(UserAvatar));
                OnPropertyChanged(nameof(ChangeAvatar));
            }
        }
        [JsonIgnore]
        private bool changeAvatar = false;
        [JsonIgnore]
        public bool ChangeAvatar
        {
            get => changeAvatar;
            set
            {
                changeAvatar = value;
                OnPropertyChanged(nameof(ChangeAvatar));
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
