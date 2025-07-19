using Newtonsoft.Json;
using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.Model_DTO;

namespace Vivo_Task.Shared_Static_Class.FundamentalModels
{
    public class ACESSOS_MOBILE_PENDENTE_DTO
    {
        [JsonIgnore]
        public bool SELECTED { get; set; } = false;
        public int ID { get; set; }
        public string EMAIL { get; set; }
        public int MATRICULA { get; set; }
        public string SENHA { get; set; }
        public string REGIONAL { get; set; }
        public int CARGO { get; set; }
        public int CANAL { get; set; }
        public string NOME { get; set; }
        public string UF { get; set; }
        public string CPF { get; set; }
        public string PDV { get; set; }
        public string ULTIMO_STATUS { get; set; }
        public bool? APROVACAO { get; set; }
        public bool? FIXA { get; set; }
        public int? DDD { get; set; }
        public string TP_STATUS { get; set; }
        public bool? ELEGIVEL { get; set; }
        public string TIPO { get; set; }
        public ACESSOS_MOBILE_DTO? SOLICITANTE { get; set; }
        public DateTime DT_SOLICITACAO { get; set; }
        public int? LOGIN_RESPONSAVEL { get; set; }
        public DateTime? DT_RETORNO { get; set; }
        public DateTime? DT_PRIMEIRO_RETORNO { get; set; }
    }
}
