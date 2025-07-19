using System.ComponentModel.DataAnnotations.Schema;
using Vivo_Task.Shared_Static_Class.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Runtime.Versioning;

namespace Vivo_Task.Shared_Static_Class.Model_ForumRTCZ_Context;

[Table("FORUM_PUBLICACAO_SOLICITACAO", Schema = "Fórum")]
public class PUBLICACAO_SOLICITACAO
{
    public PUBLICACAO_SOLICITACAO()
    {
        ID_SOLICITACAO_PUBLICACAO = Guid.Empty;
        TEXT_PUBLICACAO = string.Empty;
        SUB_TEMA = 0;
        MAT_RESPONSAVEL = 0;
        HORA = DateTime.Now;
        Avaliacao = [];
        Respostas = [];
        Responsavel = new();
        Tema = new();

    }

    public PUBLICACAO_SOLICITACAO(Guid iD_SOLICITACAO_PUBLICACAO, string tEXT_PUBLICACAO, int sUB_TEMA, int mAT_RESPONSAVEL, DateTime hORA)
    {
        ID_SOLICITACAO_PUBLICACAO = iD_SOLICITACAO_PUBLICACAO;
        TEXT_PUBLICACAO = tEXT_PUBLICACAO;
        SUB_TEMA = sUB_TEMA;
        MAT_RESPONSAVEL = mAT_RESPONSAVEL;
        HORA = hORA;
    }

    [Key]
    public Guid ID_SOLICITACAO_PUBLICACAO { get; set; }
    [Required(AllowEmptyStrings = false,ErrorMessage = "É necessário algum valor no campo de texto")]
    public string TEXT_PUBLICACAO { get; set; } = string.Empty;
    [Range(1,130, ErrorMessage = "Por favor escolha um Tema válido")]
    public int SUB_TEMA { get; set; }
    public int MAT_RESPONSAVEL { get; set; }
    public DateTime HORA { get; set; }
    public List<AVALIACAO_PUBLICACAO> Avaliacao { get; set; } = [];
    public List<RESPOSTA_PUBLICACAO> Respostas { get; set; } = [];
    public ACESSOS_MOBILE Responsavel { get; set; } = null;
    public JORNADA_BD_TEMAS_SUB_TEMA Tema { get; set; } = null;
}