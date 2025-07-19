using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Static_Class.Model
{
    public class RespostaPublicacaoModel
    {
        public RespostaPublicacaoModel(Guid iD_PUBLICACAO_ALVO, string tEXT_PUBLICACAO, int mat_solicitante, DateTime hORA)
        {
            ID_SOLICITACAO_PUBLICACAO = iD_PUBLICACAO_ALVO;
            TEXT_PUBLICACAO = tEXT_PUBLICACAO ?? string.Empty;
            MAT_SOLICITANTE = mat_solicitante;
            HORA = hORA;
        }

        public Guid ID_SOLICITACAO_PUBLICACAO { get; set; } 
        public string TEXT_PUBLICACAO { get; set; } = string.Empty;
        public int MAT_SOLICITANTE { get; set; }
        public DateTime HORA { get; set; }

    }
}
