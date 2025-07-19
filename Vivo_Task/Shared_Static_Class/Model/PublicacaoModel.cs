using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Static_Class.Model
{
    public class PublicacaoModel
    {
        public PublicacaoModel(string tEXT_PUBLICACAO, int sUB_TEMA, int mAT_RESPONSAVEL, DateTime hORA)
        {
            TEXT_PUBLICACAO = tEXT_PUBLICACAO ?? string.Empty;
            SUB_TEMA = sUB_TEMA;
            MAT_RESPONSAVEL = mAT_RESPONSAVEL;
            HORA = hORA;
        }

        public string TEXT_PUBLICACAO { get; set; } = string.Empty;
        public int SUB_TEMA { get; set; }
        public int MAT_RESPONSAVEL { get; set; }
        public DateTime HORA { get; set; }

    }
}
