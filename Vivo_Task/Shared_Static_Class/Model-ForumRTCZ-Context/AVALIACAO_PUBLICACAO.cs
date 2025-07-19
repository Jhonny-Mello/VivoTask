using Vivo_Task.Shared_Static_Class.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Vivo_Task.Shared_Static_Class.Model_ForumRTCZ_Context;

[Table("FORUM_AVALIACAO_PUBLICACAO", Schema = "Fórum")]
public class AVALIACAO_PUBLICACAO
{
    public AVALIACAO_PUBLICACAO()
    {
    }

    public AVALIACAO_PUBLICACAO(Guid? iD_AVALIACAO, Guid iD_PUBLICACAO, int mATRICULA_RESPONSAVEL, int aVALIACAO)
    {
        ID_AVALIACAO = iD_AVALIACAO ?? Guid.Empty;
        ID_PUBLICACAO = iD_PUBLICACAO; 
        MATRICULA_RESPONSAVEL = mATRICULA_RESPONSAVEL;
        AVALIACAO = aVALIACAO;
    }
    [Key]
    public Guid ID_AVALIACAO { get; set; }
    public Guid? ID_PUBLICACAO { get; set; }
    public int MATRICULA_RESPONSAVEL { get; set; }
    [Range(0, 5)]
    public int AVALIACAO { get; set; }
    public ACESSOS_MOBILE Responsavel { get; set; } = null;
    public PUBLICACAO_SOLICITACAO? Publicacao_Principal { get; set; } = new();
    public RESPOSTA_PUBLICACAO? Resposta_Publicacao { get; set; } = new();
}