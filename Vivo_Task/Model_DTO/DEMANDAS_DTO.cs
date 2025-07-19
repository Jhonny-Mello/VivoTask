using Newtonsoft.Json;

using Microsoft.Maui.Graphics;
using Vivo_Task.Shared_Static_Class.Converters;
using Vivo_Task.Model_DTO;
using Vivo_Task.Models;
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
using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.Enums;
using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.Controls;

namespace Vivo_Task.Model_DTO
{
    public partial class DEMANDA_TIPO_FILA_DTO
    {
        public int ID_TIPO_FILA { get; set; }
        public string NOME_TIPO_FILA { get; set; } = string.Empty;
        public string REGIONAL { get; set; } = string.Empty;
        public bool STATUS_TIPO_FILA { get; set; }
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
        public string REGIONAL { get; set; } = string.Empty;
        public string? DESCRICAO { get; set; } = string.Empty;
        public bool CAMPOS_AUTO { get; set; }
        public bool CAMPOS_IDENT_USER { get; set; }
        public bool STATUS_SUB_FILA { get; set; }
        public int ID_TIPO_FILA { get; set; }
        public int? ID_ANTIGO { get; set; }
        public int SLA { get; set; }
        public DEMANDA_TIPO_FILA ID_TIPO_FILANavigation { get; set; } = new();
        public List<DEMANDA_CAMPOS_FILA_DTO> DEMANDA_CAMPOS_FILAs { get; set; } = new();
        public IEnumerable<ACESSOS_MOBILE_DTO>? Responsaveis { get; set; }
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
        public List<string>? selectedValues
        {
            get;
            set;
        }
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
        [JsonIgnore] private TextInfo textInfo = new CultureInfo("pt-br", false).TextInfo;

        public ACESSOS_MOBILE_DTO()
        {
            ID = 0;
            EMAIL = "telefonica@telefonica.com";
            MATRICULA = 0;
            REGIONAL = "NE";
            CARGO = 0;
            CANAL = 0;
            PDV = "NULL";
            NOME = "NULL";
            UserAvatar = [];
        }

        public ACESSOS_MOBILE_DTO(int iD, string eMAIL, int mATRICULA, string rEGIONAL, Cargos cARGO, Canal cANAL, string pDV, string nOME, byte[] userAvatar)
        {
            ID = iD;
            EMAIL = eMAIL ?? "telefonica@telefonica.com";
            MATRICULA = mATRICULA;
            REGIONAL = rEGIONAL ?? "NE";
            CARGO = cARGO;
            CANAL = cANAL;
            PDV = pDV ?? "NULL";
            NOME = nOME ?? "NULL";
            UserAvatar = userAvatar ?? [];
        }

        public int ID { get; set; }
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

        public byte[] UserAvatar { get; set; }
        public IEnumerable<DEMANDA_CHAMADO> DemandasResponsavel { get; set; } = new List<DEMANDA_CHAMADO>();
        public IEnumerable<DEMANDA_CHAMADO> DemandasSolicitadas { get; set; } = new List<DEMANDA_CHAMADO>();

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
            File.ReadAllBytes("C:\\FilesTemplates\\usericon.png")
            //            File.ReadAllBytes("C:\\FilesTemplates\\usericon.png")
            ;
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

    public record PaginationDemandasModel
    {
        public PaginationDemandasModel(int matricula, List<DateTime> datas, List<string> regional, List<string> status, List<ACESSO> responsável, List<string> id_demandas, List<DROPDOWN_FILA_MODEL> tipo_fila, List<DROPDOWN_FILA_MODEL> fila)
        {
            this.matricula = matricula;
            this.datas = datas;
            this.regional = regional;
            this.status = status;
            this.tipo_fila = tipo_fila;
            this.fila = fila;
            this.responsável = responsável;
            this.id_demandas = id_demandas;
        }

        public bool IsRealTime { get; set; } = true;
        public int matricula { get; set; }
        public List<DateTime> datas { get; set; }
        public List<string> regional { get; set; }
        public List<string> status { get; set; }
        public List<DROPDOWN_FILA_MODEL> tipo_fila { get; set; }
        public List<DROPDOWN_FILA_MODEL> fila { get; set; }
        public List<ACESSO> responsável { get; set; }
        public List<string> id_demandas { get; set; }

    }
    public partial class PAINEL_DEMANDAS_CHAMADO_DTO
    {
        public int ID { get; set; }
        public PAINEL_DEMANDA_SUB_FILA_DTO Fila { get; set; }
        public DateTime? DATA_ABERTURA { get; set; }
        public DateTime? DATA_FECHAMENTO { get; set; }
        public string MOTIVO_FECHAMENTO_SUPORTE { get; set; }
        public string PRIORIDADE { get; set; }
        public string REGIONAL { get; set; }
        public bool IsSelected { get; set; } = false;
        public IEnumerable<DEMANDA_CHAMADO_RESPOSTA> Respostas { get; set; } = new List<DEMANDA_CHAMADO_RESPOSTA>();
        public IEnumerable<DEMANDA_CAMPOS_CHAMADO> Campos { get; set; } = new List<DEMANDA_CAMPOS_CHAMADO>();
        public IEnumerable<DEMANDA_STATUS_CHAMADO> Status { get; set; } = new List<DEMANDA_STATUS_CHAMADO>();
        public ACESSOS_MOBILE_DTO? Resp_Outra_Area { get; set; }
        public ACESSOS_MOBILE_DTO? Responsavel { get; set; }
        public ACESSOS_MOBILE_DTO Solicitante { get; set; }
        public TimeSpan? SLA_TOTAL
        {
            get
            {
                return DateTime.Now - this.DATA_ABERTURA;
            }
        }
        public TimeSpan? SLA_PRIMEIRA_RESPOSTA =>
            (Respostas.Any()
            && Respostas.Where(x => x.MATRICULA_RESPONSAVEL != Solicitante.MATRICULA).Any()) == true
            ? (DateTime.Now - Respostas.Where(x => x.MATRICULA_RESPONSAVEL != Solicitante.MATRICULA)?.Min(x => x.DATA_RESPOSTA))
            : null;

    }

    public partial class DEMANDAS_CHAMADO_DTO
    {
        public int ID { get; set; }
        public DEMANDA_SUB_FILA_DTO Fila { get; set; } = new();
        public DateTime? DATA_ABERTURA { get; set; }
        public DateTime? DATA_FECHAMENTO { get; set; }
        public string MOTIVO_FECHAMENTO_SUPORTE { get; set; } = string.Empty;
        public string PRIORIDADE { get; set; } = string.Empty;
        public string REGIONAL { get; set; } = string.Empty;
        public DEMANDA_PARQUE? Has_Cliente_Valor { get; set; }
        public ACESSOS_MOBILE_DTO? RESPONSAVEL_OUTRA_AREA { get; set; }
        public IEnumerable<DEMANDA_CHAMADO_RESPOSTA_DTO> Respostas { get; set; } = new List<DEMANDA_CHAMADO_RESPOSTA_DTO>();
        public IEnumerable<DEMANDA_CAMPOS_CHAMADO> Campos { get; set; } = new List<DEMANDA_CAMPOS_CHAMADO>();
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
        public List<DEMANDA_ARQUIVOS_RESPOSTA_DTO>? ARQUIVOS { get; set; } = new List<DEMANDA_ARQUIVOS_RESPOSTA_DTO>();
        public DEMANDA_STATUS_CHAMADO? Status { get; set; } // Status 
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

}
