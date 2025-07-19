using Vivo_Task.Shared_Static_Class.Converters;
using Vivo_Task.Shared_Static_Class.Enums;

namespace Vivo_Task.Shared_Static_Class.FundamentalModels
{
    public class FilterUsuariosPendentesModel
    {
        public int MatriculaRequisitante { get; set; } = 0;
        public List<string> ID { get; set; } = [];
        public bool? IsSuporte { get; set; } = false;
        public bool IsMaster { get; set; } = false;
        public string? NomeSolicitante { get; set; } = string.Empty;
        public List<string> MATRICULA { get; set; } = [];
        public List<int?> LOGIN_SOLICITANTE { get; set; } = [];
        public List<string?> UF { get; set; } = [];
        public List<string?> REGIONAL { get; set; } = [];
        public List<string?> Tipo { get; set; } = [];
        public List<string> REGIONAIS_FILTER { get; set; } = [];
        public List<string?> STATUS { get; set; } = [];
        public List<Canal> Canal { get; set; } = [];
        public List<Cargos> Cargos { get; set; } = [];
        public bool APROVACAO { get; set; } = false;
        public IReadOnlyList<DateTime?> DT_SOLICITACAO { get; set; } = [];
    }
}
