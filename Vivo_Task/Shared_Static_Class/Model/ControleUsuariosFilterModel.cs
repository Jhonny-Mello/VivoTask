using Newtonsoft.Json;

namespace Vivo_Task.Shared_Static_Class.FundamentalModels
{
    public class ControleUsuariosFilterModel
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public List<double> Cargo { get; set; } = new List<double>();

        public List<double> Canal { get; set; } = new List<double>();
        public List<string> Regional { get; set; } = new List<string>();
        public List<string> Uf { get; set; } = new List<string>();
        public List<bool> Fixa { get; set; } = new List<bool>();
        public string Nome { get; set; } = string.Empty;

        public int? Matricula { get; set; }

        //public string MatriculaDivisao { get; set; } = string.Empty;
        public List<string> MatriculaDivisao { get; set; } = new List<string>();
        public string email { get; set; } = string.Empty;
        public string Pdv { get; set; } = string.Empty;
        public bool? IsSuporte { get; set; } = null;
    }
}

