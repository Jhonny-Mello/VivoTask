using Vivo_Task.Shared_Static_Class.FundamentalModels;
using Vivo_Task.Shared_Static_Class.Model_ForumRTCZ_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivo_Task.Shared_Static_Class.Model_DTO
{
    public class PUBLICACAO_SOLICITACAODTO : PUBLICACAO_SOLICITACAO
    {
        public PUBLICACAO_SOLICITACAODTO()
        {

        }
        public PUBLICACAO_SOLICITACAODTO(PUBLICACAO_SOLICITACAO item, bool showRespostas = false, bool selected = false) : base(item.ID_SOLICITACAO_PUBLICACAO, item.TEXT_PUBLICACAO, item.SUB_TEMA, item.MAT_RESPONSAVEL, item.HORA)
        {
            ID_SOLICITACAO_PUBLICACAO = item.ID_SOLICITACAO_PUBLICACAO;
            TEXT_PUBLICACAO = item.TEXT_PUBLICACAO;
            SUB_TEMA = item.SUB_TEMA;
            MAT_RESPONSAVEL = item.MAT_RESPONSAVEL;
            HORA = item.HORA;
            Responsavel = item.Responsavel;
            Tema = item.Tema;
            Avaliacao = item.Avaliacao ?? [];
            Respostas = item.Respostas ?? [];
            Respostasdto = item.Respostas?.Select(x => new RESPOSTA_PUBLICACAODTO(x)).ToList() ?? [];
            ShowRespostas = showRespostas;
            Selected = selected;
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
        public bool ShowRespostas { get; set; }
        public bool Selected { get; protected set; }
        public int ActualAvaliacao { get; set; }
        public int QtdAvaliacao { get; set; }
        public List<RESPOSTA_PUBLICACAODTO> Respostasdto { get; set; } = [];
        public void SetSelected()
        {
            Selected = !Selected;
        }
    }
}
