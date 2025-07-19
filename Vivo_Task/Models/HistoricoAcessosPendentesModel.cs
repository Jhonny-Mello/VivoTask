
using Vivo_Task.Shared_Static_Class.Converters;
using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.Enums;

namespace Vivo_Task.Models
{
    public class HistoricoAcessosPendentesModel
    {
        public int ID { get; set; }
        public ControleUsuariosModel? ID_ACESSOS_MOBILE { get; set; }
        public string EMAIL { get; set; }
        public int MATRICULA { get; set; }
        public string SENHA { get; set; }
        public string REGIONAL { get; set; }
        public Cargos CARGO { get; set; }
        public Canal CANAL { get; set; }
        public string NOME { get; set; }
        public string UF { get; set; }
        public string CPF { get; set; }
        public string PDV { get; set; }
        public bool? APROVACAO { get; set; }
        public bool? FIXA { get; set; }
        public string TIPO { get; set; }
        public bool? STATUS_USUARIO { get; set; }
        public ACESSO? LOGIN_SOLICITANTE { get; set; }
        public ACESSO? LOGIN_RESPONSAVEL { get; set; }
        public DateTime DT_SOLICITACAO { get; set; }
        public DateTime? DT_RETORNO { get; set; }
        public string STATUS { get; set; }
        public int DDD { get; set; }
        public bool ELEGIVEL { get; set; } = false;
        public string TP_STATUS { get; set; } = string.Empty;
        public byte[]? UserAvatar { get; set; }
        public IEnumerable<RespostasAcessosPendentesModel> RESPOSTAS { get; set; }
        public IEnumerable<PERFIL_PLATAFORMAS_VIVO> PERFIS_SOLICITADOS { get; set; }

    }
}
