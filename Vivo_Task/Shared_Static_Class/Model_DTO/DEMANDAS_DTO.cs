using Newtonsoft.Json;
using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.Converters;
using Vivo_Task.Shared_Static_Class.Enums;
using Vivo_Task.Shared_Static_Class.Model_DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;
using static Vivo_Task.Shared_Static_Class.Data.DEMANDA_RELACAO_CHAMADO;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;

namespace Vivo_Task.Shared_Static_Class.Model_DTO
{
    public partial class DEMANDA_TIPO_FILA_DTO
    {
        public int ID_TIPO_FILA { get; set; }
        public string NOME_TIPO_FILA { get; set; } = string.Empty;
        public string? DESCRICAO { get; set; } = string.Empty;
        public List<DEMANDA_SUB_FILA_DTO> DEMANDA_SUB_FILAs { get; set; } = new();
    }

    public partial class PAINEL_DEMANDA_SUB_FILA_DTO
    {
        public int SLA { get; set; }
        public int ID_SUB_FILA { get; set; }
        public string NOME_SUB_FILA { get; set; } = string.Empty;
        public string REGIONAL { get; set; } = string.Empty;
        public string? DESCRICAO { get; set; } = string.Empty;
        public bool CAMPOS_AUTO { get; set; }
        public bool CAMPOS_IDENT_USER { get; set; }
        public bool STATUS_SUB_FILA { get; set; }
        public DEMANDA_TIPO_FILA ID_TIPO_FILANavigation { get; set; }
        public int? ID_ANTIGO { get; set; }
    }
    public partial class DEMANDA_SUB_FILA_DTO
    {
        public int ID_SUB_FILA { get; set; }
        public string NOME_SUB_FILA { get; set; } = string.Empty;
        public string? DESCRICAO { get; set; } = string.Empty;
        public bool CAMPOS_AUTO { get; set; }
        public bool CAMPOS_IDENT_USER { get; set; }
        public int ID_TIPO_FILA { get; set; } = 0;
        public int SLA { get; set; }
        [AllowNull]
        public DEMANDA_TIPO_FILA? ID_TIPO_FILANavigation { get; set; } = null;
        public List<DEMANDA_CAMPOS_FILA_DTO> DEMANDA_CAMPOS_FILAs { get; set; } = new();
        public IEnumerable<ACESSOS_MOBILE_DTO> Responsaveis { get; set; } = [];
    }

    public partial class DEMANDA_CAMPOS_FILA_DTO
    {
        public int ID_CAMPOS { get; set; }
        public int ID_SUB_FILA { get; set; }
        public string CAMPO { get; set; } = string.Empty;
        public string GetMascara() => !CAMPO_SUSPENSO ? MASCARA : "campo_suspenso";
        public string MASCARA { get; set; } = string.Empty;
        public bool CAMPO_SUSPENSO { get; set; } = false;
        public bool STATUS_CAMPOS_FILA { get; set; } = true;
        public bool CamposFromDatabase { get; set; } = true;
        public List<DEMANDA_VALORES_CAMPOS_SUSPENSO_DTO> DEMANDA_VALORES_CAMPOS_SUSPENSOs { get; set; } = new();
        public bool IsSelected { get; set; } = false;
    }

    public partial class DEMANDA_VALORES_CAMPOS_SUSPENSO_DTO
    {
        public int ID_VALORES { get; set; }
        public string VALOR { get; set; } = string.Empty;
        public int ID_CAMPOS { get; set; }
        public bool STATUS { get; set; }
    }

    public partial class DEMANDAS_CAMPOS_FILA_DTO
    {
        public int ID_FILA { get; set; }
        public string CAMPO { get; set; } = string.Empty;
        public string MASCARA { get; set; } = string.Empty;
    }

    public partial class ACESSOS_MOBILE_DTO
    {
        [JsonIgnore]
        private TextInfo textInfo = new CultureInfo("pt-br", false).TextInfo;

        public ACESSOS_MOBILE_DTO()
        {
        }

        public ACESSOS_MOBILE_DTO(string eMAIL, int mATRICULA, string tELEFONE, string rEGIONAL, Cargos cARGO, Canal cANAL, string pDV, string nOME, byte[] userAvatar)
        {
            EMAIL = eMAIL ?? string.Empty;
            MATRICULA = mATRICULA;
            TELEFONE = tELEFONE ?? string.Empty;
            REGIONAL = rEGIONAL ?? string.Empty;
            CARGO = cARGO;
            CANAL = cANAL;
            PDV = pDV ?? string.Empty;
            NOME = nOME ?? string.Empty;
            UserAvatar = userAvatar;
        }

        public int ID { get; set; }
        public string EMAIL { get; set; } = string.Empty;
        public int MATRICULA { get; set; }
        public string TELEFONE { get; set; } = string.Empty;
        public string REGIONAL { get; set; } = string.Empty;
        public Cargos CARGO { get; set; }
        public Canal CANAL { get; set; }
        public string PDV { get; set; } = string.Empty;
        public string NOME { get; set; } = string.Empty;
        [JsonIgnore]
        public string DISPLAY_NOME
        {
            get
            {
                var Listname = this.NOME.Split();
                var name = Listname.FirstOrDefault();

                if (Listname.Length > 1)
                {
                    name += " " + Listname.LastOrDefault();
                }

                return textInfo.ToTitleCase(name.ToLower());
            }
        }
        public byte[]? UserAvatar { get; set; } = null;
        //public IEnumerable<DEMANDA_CHAMADO> DemandasResponsavel { get; set; } = [];
        //public IEnumerable<DEMANDA_CHAMADO> DemandasSolicitadas { get; set; } = [];
        public IEnumerable<PERFIL_USUARIO> Perfis { get; set; } = [];
        public Controle_Demanda_role role { get; set; } = Controle_Demanda_role.BASICO;
    }
    public partial class ACESSOS_MOBILE_NO_RELATIONS
    {
        [JsonIgnore]
        private TextInfo textInfo = new CultureInfo("pt-br", false).TextInfo;
        public string EMAIL { get; set; } = string.Empty;
        public int MATRICULA { get; set; }
        public string REGIONAL { get; set; } = string.Empty;
        public Cargos CARGO { get; set; }
        public Canal CANAL { get; set; }
        public string PDV { get; set; } = string.Empty;
        public string NOME { get; set; } = string.Empty;
        [JsonIgnore]
        public string DISPLAY_NOME
        {
            get
            {
                var Listname = this.NOME.Split();
                var name = Listname.FirstOrDefault();

                if (Listname.Length > 1)
                {
                    name += " " + Listname.LastOrDefault();
                }

                return textInfo.ToTitleCase(name.ToLower());
            }
        }
        [AllowNull]
        public byte[] UserAvatar { get; set; } = null;
    }
    public partial class ACESSOS_MOBILE_CHAT_DTO
    {
        public int ID { get; set; }
        public string EMAIL { get; set; } = string.Empty;
        public int MATRICULA { get; set; }
        public string REGIONAL { get; set; } = string.Empty;
        public Cargos CARGO { get; set; }
        public Canal CANAL { get; set; }
        public string PDV { get; set; } = string.Empty;
        public string NOME { get; set; } = string.Empty;

        public byte[] UserAvatar { get; set; } =
            null;
        //            File.ReadAllBytes("C:\\FilesTemplates\\usericon.png")
        public List<Messages> ChatMessages { get; set; } = new();
        public bool NewMessage { get; set; } = false;
        public bool Connected { get; set; } = false;
    }

    public partial class Messages
    {
        public required int mat_remetente { get; set; }
        public required int mat_destinatario { get; set; }
        public required string messsagem { get; set; }
        public DateTime hora { get; set; }
    }

    public partial class ACESSO_DTO
    {
        private TextInfo textInfo = new CultureInfo("pt-br", false).TextInfo;
        public int idAcesso { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Regional { get; set; } = string.Empty;
        public byte[] Senha { get; set; }
        public byte[] Imagem { get; set; }
        public string Status { get; set; } = string.Empty;
        public string DISPLAY_NOME
        {
            get
            {
                var Listname = this.Nome.Split();
                var name = Listname.FirstOrDefault();

                if (Listname.Length > 1)
                {
                    name += " " + Listname.LastOrDefault();
                }

                return textInfo.ToTitleCase(name.ToLower());
            }
        }
        public bool? Primeiro_Acesso { get; set; }
    }


    public class DEMANDA_DTO
    {
        public Guid ID_RELACAO { get; set; }
        public int ID_CHAMADO { get; set; }
        public int Sequence { get; set; }
        public Tabela_Demanda Tabela { get; set; }
        public string tipo => Tabela.GetDisplayName();
        public string LastStatus { get; set; }
        public string REGIONAL { get; set; } = string.Empty;
        public DateTime DATA_ABERTURA { get; set; }
        public int MATRICULA_SOLICITANTE { get; set; }
        public int MATRICULA_RESPONSAVEL { get; set; }
        public bool Selected { get; private set; } = false;
        public string NewObs { get; set; } = string.Empty;
        public void SetSelected() => Selected = !Selected;
        public bool PRIORIDADE { get; set; }
        public bool PRIORIDADE_SEGMENTO { get; set; }  /* Coluna se aplica apenas a DEMANDAS */
        public ACESSOS_MOBILE_NO_RELATIONS Solicitante { get; set; } = new();
        public ACESSOS_MOBILE_NO_RELATIONS Responsavel { get; set; } = new();
        public PAINEL_DEMANDAS_CHAMADO_DTO? ChamadoRelacao { get; set; } = null;
        public DEMANDA_ACESSOS_PAINEL? AcessoRelacao { get; set; } = null;
        public DEMANDA_DESLIGAMENTOS_PAINEL? DesligamentoRelacao { get; set; } = null;
        public IEnumerable<DEMANDA_CHAMADO_RESPOSTA> Respostas { get; set; } = [];
        public IEnumerable<DEMANDA_STATUS_CHAMADO> Status { get; set; } = [];
        public TimeSpan? SLA_TOTAL
        {
            get
            {
                return DateTime.Now - this.DATA_ABERTURA;
            }
        }
    }

    public partial class PAINEL_DEMANDAS_CHAMADO_DTO
    {
        public int ID { get; set; }
        public PAINEL_DEMANDA_SUB_FILA_DTO Fila { get; set; }
    }

    public partial class DEMANDAS_CHAMADO_DTO
    {
        public int ID { get; set; }
        public Guid ID_RELACAO { get; set; }
        public DEMANDA_SUB_FILA_DTO Fila { get; set; } = new();
        public DateTime? DATA_ABERTURA { get; set; }
        public DateTime? DATA_FECHAMENTO { get; set; }
        public string MOTIVO_FECHAMENTO_SUPORTE { get; set; } = string.Empty;
        public string PRIORIDADE { get; set; } = string.Empty;
        public string REGIONAL { get; set; } = string.Empty;
        public DEMANDA_PARQUE? Has_Cliente_Valor { get; set; }
        public ACESSOS_MOBILE_DTO? RESPONSAVEL_OUTRA_AREA { get; set; }
        public DEMANDA_RELACAO_CHAMADO Relacao { get; set; } = null;
        public IEnumerable<DEMANDA_CHAMADO_RESPOSTA_DTO> Respostas { get; set; } = [];
        public IEnumerable<DEMANDA_CAMPOS_CHAMADO> Campos { get; set; } = [];
        public ACESSOS_MOBILE_DTO? Responsavel { get; set; }
        public ACESSOS_MOBILE_DTO Solicitante { get; set; } = new();
    }

    public partial class HistoricoDemanda
    {
        public string? STATUS { get; set; } = null!;
        public string? RESPOSTA { get; set; } = null!;
        public DateTime? DATA { get; set; }
        public ACESSOS_MOBILE_DTO? MATRICULA_RESPONSAVEL { get; set; }
        public ACESSOS_MOBILE_DTO? MAT_QUEM_REDIRECIONOU { get; set; }
        public IEnumerable<DEMANDA_ARQUIVOS_RESPOSTA>? ANEXOS { get; set; }
        public TipoCardHistorico? Tipo { get; set; }
    }
    public partial class DEMANDA_CHAMADO_RESPOSTA_DTO
    {
        public int ID { get; set; }
        public string RESPOSTA { get; set; } = string.Empty;
        public int ID_CHAMADO { get; set; }
        public DateTime? DATA_RESPOSTA { get; set; }
        private List<DEMANDA_ARQUIVOS_RESPOSTA_DTO>? ARQUIVOS { get; set; } = [];
        public DEMANDA_STATUS_CHAMADO_DTO? Status { get; set; } = null; // Status 
        public ACESSOS_MOBILE_DTO Responsavel { get; set; }
    }

    public partial class DEMANDA_ARQUIVOS_RESPOSTA_DTO
    {
        public int ID { get; set; }
        public int ID_RESPOSTA { get; set; }
        public string NOME_CAMPO { get; set; } = string.Empty;
        public byte[] ARQUIVO { get; set; } = new byte[0];
        public string EXT_ARQUIVO { get; set; } = string.Empty;
    }

    public partial class DEMANDA_BD_OPERADORES_DTO
    {
        public int ID { get; set; }

        public ACESSOS_MOBILE_DTO MATRICULA { get; set; }

        public string REGIONAL { get; set; }

        public bool? STATUS { get; set; }

        public DateTime? DT_MOD { get; set; }

        public ACESSOS_MOBILE_DTO? MATRICULA_MOD { get; set; }
    }
    public partial class DEMANDA_STATUS_CHAMADO_DTO
    {
        public int ID { get; set; }
        public int ID_CHAMADO { get; set; }
        public Guid ID_RELACAO { get; set; }
        public int ID_RESPOSTA { get; set; }
        public string STATUS { get; set; } = string.Empty;
        public DateTime DATA { get; set; }
        public int? MAT_QUEM_REDIRECIONOU { get; set; }
        public int? MAT_DESTINATARIO { get; set; }
        public DEMANDA_RELACAO_CHAMADO Relacao_DEMANDA { get; set; } = new();
        public ACESSOS_MOBILE? Quem_redirecionou { get; set; } = null;
        public ACESSOS_MOBILE? Para_Quem_redirecionou { get; set; } = null;
        public DEMANDA_CHAMADO_RESPOSTA? Resposta { get; set; } = null;
    }


}
