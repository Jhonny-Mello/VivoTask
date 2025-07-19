using Vivo_Task.Shared_Static_Class.FundamentalModels;
using Vivo_Task.Shared_Static_Class.Model_ForumRTCZ_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivo_Task.Shared_Static_Class.Model_DTO
{
    public class RESPOSTA_PUBLICACAODTO : RESPOSTA_PUBLICACAO
    {
        public RESPOSTA_PUBLICACAODTO() { }
        public RESPOSTA_PUBLICACAODTO(Guid iD_PUBLICACAO, Guid iD_SOLICITACAO_PUBLICACAO, DateTime hORA, int mAT_SOLICITANTE, string tEXT_PUBLICACAO) : base(iD_PUBLICACAO, iD_SOLICITACAO_PUBLICACAO, hORA, mAT_SOLICITANTE, tEXT_PUBLICACAO)
        {
            ID_PUBLICACAO = iD_PUBLICACAO;
            ID_SOLICITACAO_PUBLICACAO = iD_SOLICITACAO_PUBLICACAO;
            HORA = hORA;
            MAT_SOLICITANTE = mAT_SOLICITANTE;
            TEXT_PUBLICACAO = tEXT_PUBLICACAO;

            QtdAvaliacao = Avaliacao.Count;
            var sumnotas = Avaliacao.Sum(x => x.AVALIACAO);

            if (QtdAvaliacao > 0)
            {
                ActualAvaliacao = (int)Math.Round((double)(sumnotas / QtdAvaliacao), 0);
            }
            else
            {
                ActualAvaliacao = 0;
            }
        }
        public RESPOSTA_PUBLICACAODTO(RESPOSTA_PUBLICACAO item)
        {
            ID_PUBLICACAO = item.ID_PUBLICACAO;
            ID_SOLICITACAO_PUBLICACAO = item.ID_SOLICITACAO_PUBLICACAO;
            HORA = item.HORA;
            MAT_SOLICITANTE = item.MAT_SOLICITANTE;
            TEXT_PUBLICACAO = item.TEXT_PUBLICACAO;
            Solicitante = item.Solicitante;
            Avaliacao = item.Avaliacao;

            QtdAvaliacao = Avaliacao.Count;
            var sumnotas = Avaliacao.Sum(x => x.AVALIACAO);

            if (QtdAvaliacao > 0)
            {
                ActualAvaliacao = (int)Math.Round((double)(sumnotas / QtdAvaliacao), 0);
            }
            else
            {
                ActualAvaliacao = 0;
            }
        }

        public int ActualAvaliacao { get; set; }
        public int QtdAvaliacao { get; set; }
    }
}
