using Microsoft.EntityFrameworkCore;
using Vivo_Task.Shared_Static_Class.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vivo_Task.Shared_Static_Class.FundamentalModels
{
    public class HistoricoDemandasModel
    {
        public int ID { get; set; }
        public CONTROLE_DE_DEMANDAS_FILA_DTO FILA { get; set; }
        public ACESSO? SOLICITANTE { get; set; }
        public ACESSO? RESPONSAVEL { get; set; }
        public DateTime? DATA_FECHAMENTO { get; set; }
        public string? MOTIVO_FECHAMENTO_SUPORTE { get; set; }
        public string REGIONAL { get; set; }
        public string? EMAIL_SECUNDARIO { get; set; }
        public ACESSO? RESPONSAVEL_OUTRA_AREA { get; set; }
        public IEnumerable<CONTROLE_DE_DEMANDAS_RELACAO_CAMPOS_CHAMADO_DTO>? CAMPOS { get; set; }
        public IEnumerable<StatusDemanda> STATUS { get; set; }
        public IEnumerable<RespostaDemanda> RESPOSTAS { get; set; }
        public IEnumerable<CONTROLE_DE_DEMANDAS_CHAMADO_ARQUIVO_DTO>? ANEXOS_DEMANDA { get; set; }
    }
    public class CONTROLE_DE_DEMANDAS_FILA_DTO
    {
        public int ID { get; set; }
        public string FILA { get; set; }
        public string ADD_CAMPOS_AUTOMATICOS { get; set; }
        public string MAT_QUEM_CRIOU { get; set; }
        public string ADD_CAMPOS_MUNICIPIOS { get; set; }
        public string TIPO_CHAMADO { get; set; }
        public string REGIONAL { get; set; }
        public string ADD_PDV_DESTINO { get; set; }

    }
    public class CONTROLE_DE_DEMANDAS_RELACAO_CAMPOS_CHAMADO_DTO
    {
        public int ID_CAMPOS_CHAMADO { get; set; }
        public string CAMPO { get; set; }
        public string VALOR { get; set; }
        public int ID { get; set; }
    }
    public class CONTROLE_DEMANDAS_ARQUIVOS_RESPOSTum_DTO
    {
        public int ID { get; set; }
        public int ID_RESPOSTA { get; set; }
        public string NOME_ARQUIVO { get; set; }
        public string EXT_ARQUIVO { get; set; }
        public byte[] ARQUIVO { get; set; }
    }
    public class CONTROLE_DE_DEMANDAS_CHAMADO_ARQUIVO_DTO
    {
        public int Id { get; set; }
        public int ID_CHAMADO { get; set; }
        public string NOME_CAMPO { get; set; }
        public string EXT_ARQUIVO { get; set; }
        public byte[] ARQUIVO { get; set; }
    }



}
