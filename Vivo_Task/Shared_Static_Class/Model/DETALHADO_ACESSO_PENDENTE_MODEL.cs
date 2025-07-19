using Vivo_Task.Shared_Static_Class.Converters;
using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.Enums;
using Vivo_Task.Shared_Static_Class.Model_DTO;
using Vivo_Task.Shared_Static_Class.FundamentalModels;

namespace Vivo_Task.Shared_Static_Class.FundamentalModels
{
    public class DETALHADO_ACESSO_PENDENTE_MODEL
    {
        public SOLICITACAO_USUARIO_DETALHADO SOLICITACAO { get; set; }
        public ACESSOS_MOBILE? ACESSOS_MOBILE { get; set; } = null;
        public IEnumerable<PERFIL_PLATAFORMAS_VIVO>? PERFIS_ACESSOS_MOBILE { get; set; } = [];
        public IEnumerable<MENSAGEM_ACESSO_PENDENTE> RESPOSTAS { get; set; } = [];
    }
}
