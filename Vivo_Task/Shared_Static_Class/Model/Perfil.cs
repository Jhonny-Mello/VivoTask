using Newtonsoft.Json;
using Vivo_Task.Shared_Static_Class.Data;

namespace Vivo_Task.Shared_Static_Class.FundamentalModels
{
    [JsonObject]
    public class Perfil
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string PLATAFORMA { get; set; }
        public int? Cargo { get; set; }
        public PERFIL_PLATAFORMAS_VIVO Perfil_Plataforma { get; set; }
        public string? Nome_Perfil { get; set; }
    }
}
