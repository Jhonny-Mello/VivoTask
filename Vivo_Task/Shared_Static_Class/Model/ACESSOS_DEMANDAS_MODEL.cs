using Vivo_Task.Shared_Static_Class.Data;

namespace Vivo_Task.Shared_Static_Class.FundamentalModels
{
    public class ACESSOS_DEMANDAS_MODEL
    {
        public int ID { get; set; }
        public IEnumerable<CONTROLE_DE_DEMANDAS_RELACAO_CAMPOS_CHAMADO>? ID_CAMPOS_CHAMADO { get; set; }
        public CONTROLE_DE_DEMANDAS_RELACAO_STATUS_CHAMADO? ULTIMO_STATUS { get; set; }
        public CONTROLE_DE_DEMANDAS_FILA FILA { get; set; }
        public ACESSO? RESPONSAVEL { get; set; }
        public ACESSO SOLICITANTE { get; set; }
        public DateTime DATA_ABERTURA { get; set; }
        public DateTime? DATA_FECHAMENTO { get; set; }
        public string? MOTIVO_FECHAMENTO_SUPORTE { get; set; }
        public string? PRIORIDADE { get; set; }
        public string REGIONAL { get; set; }
        public string? PBI { get; set; }
        public string? EMAIL_SECUNDARIO { get; set; }
        public ACESSO? RESPONSAVEL_OUTRA_AREA { get; set; }
        public TimeSpan? SLA_PRIMEIRA_RESPOSTA { get; set; }
    }
}
