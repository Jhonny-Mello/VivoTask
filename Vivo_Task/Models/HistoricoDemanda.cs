
using Vivo_Task.Shared_Static_Class.Converters;
using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.Enums;

namespace Vivo_Task.Models
{
    public class HistoricoDemanda
    {
        public string? STATUS { get; set; } = null!;
        public string? RESPOSTA { get; set; } = null!;
        public DateTime? DATA { get; set; }
        public ACESSO? MATRICULA_RESPONSAVEL { get; set; }
        public ACESSO? MAT_QUEM_REDIRECIONOU { get; set; }
        public IEnumerable<CONTROLE_DEMANDAS_ARQUIVOS_RESPOSTum>? ANEXOS { get; set; }
        public TipoCardHistorico? Tipo { get; set; }
    }
}
