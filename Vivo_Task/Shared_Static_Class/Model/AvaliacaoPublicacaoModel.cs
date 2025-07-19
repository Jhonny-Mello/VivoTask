using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Static_Class.Model
{
    public class AvaliacaoPublicacaoModel
    {
        public AvaliacaoPublicacaoModel(Guid? iD_PUBLICACAO, int mATRICULA_RESPONSAVEL, int aVALIACAO)
        {
            ID_PUBLICACAO = iD_PUBLICACAO ?? Guid.Empty;
            MATRICULA_RESPONSAVEL = mATRICULA_RESPONSAVEL;
            AVALIACAO = aVALIACAO;
        }

        public Guid? ID_PUBLICACAO { get; set; }
        public int MATRICULA_RESPONSAVEL { get; set; }
        public int AVALIACAO { get; set; }

    }
}
