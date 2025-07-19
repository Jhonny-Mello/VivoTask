using Vivo_Task.Shared_Static_Class.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivo_Task.Shared_Static_Class.Model_ForumRTCZ_Context;

[Table("FORUM_RESPONSAVEL_TEMA", Schema = "Fórum")]
public partial class RESPONSAVEL_TEMA
{
    public RESPONSAVEL_TEMA()
    {

    }

    public RESPONSAVEL_TEMA(Guid iD_RESPONSAVEL_TEMA, int mATRICULA_RESPONSAVEL, int sUB_TEMA, DateTime hORA)
    {
        ID_RESPONSAVEL_TEMA = iD_RESPONSAVEL_TEMA;
        MATRICULA_RESPONSAVEL = mATRICULA_RESPONSAVEL;
        SUB_TEMA = sUB_TEMA;
        HORA = hORA;
    }

    [Key]
    public Guid ID_RESPONSAVEL_TEMA { get; set; }
    public int MATRICULA_RESPONSAVEL { get; set; }
    public int SUB_TEMA { get; set; }
    public DateTime HORA { get; set; }
    public JORNADA_BD_TEMAS_SUB_TEMA Tema { get; set; } = null;
    public ACESSOS_MOBILE Responsavel { get; set; } = null;
}
