

using Vivo_Task.Shared_Static_Class.Data;

namespace Vivo_Task.Models
{
    public class HistoricoDemandasModel
    {
        public int ID { get; set; }
        public CONTROLE_DE_DEMANDAS_FILA FILA { get; set; }
        public ACESSO? SOLICITANTE { get; set; }
        public ACESSO? RESPONSAVEL { get; set; }
        public DateTime? DATA_FECHAMENTO { get; set; }
        public string? MOTIVO_FECHAMENTO_SUPORTE { get; set; }
        public string REGIONAL { get; set; }
        public string? EMAIL_SECUNDARIO { get; set; }
        public ACESSO? RESPONSAVEL_OUTRA_AREA { get; set; }
        public IEnumerable<CONTROLE_DE_DEMANDAS_RELACAO_CAMPOS_CHAMADO>? CAMPOS { get; set; }

        public IEnumerable<StatusDemanda> STATUS { get; set; }
        public IEnumerable<RespostaDemanda> RESPOSTAS { get; set; }
        public IEnumerable<CONTROLE_DE_DEMANDAS_CHAMADO_ARQUIVO>? ANEXOS_DEMANDA { get; set; }
    }
}
