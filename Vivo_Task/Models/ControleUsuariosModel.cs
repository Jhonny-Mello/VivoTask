
using Vivo_Task.Models;

namespace Vivo_Task.Models
{
    public class ControleUsuariosModel
    {
        public int ID { get; set; }
        public string EMAIL { get; set; }
        public int MATRICULA { get; set; }
        public string SENHA { get; set; }
        public string REGIONAL { get; set; }
        public int CARGO { get; set; }
        public int? CANAL { get; set; }
        public string PDV { get; set; }
        public string CPF { get; set; }
        public string NOME { get; set; }
        public string UF { get; set; }
        public bool? STATUS { get; set; }
        public bool? FIXA { get; set; }
        public string? TP_AFASTAMENTO { get; set; }
        public string? OBS { get; set; }
        public byte[]? UserAvatar { get; set; }
        public int? LOGIN_MOD { get; set; }
        public DateTime? DT_MOD { get; set; }
        public bool ELEGIVEL { get; set; } = false;
        public int DDD { get; set; }
        public string TP_STATUS { get; set; } = string.Empty;
        public List<int> Perfil { get; set; } = new();
    }
}
