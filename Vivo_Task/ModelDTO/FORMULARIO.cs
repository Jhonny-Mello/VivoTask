using Vivo_Task.Shared_Static_Class.FundamentalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivo_Task.Models;

namespace Vivo_Task.ModelDTO
{
    public partial class FORMULARIO
    {
        public int ID_QUESTION { get; set; }
        public string TEMA { get; set; }
        public string TP_FORMS { get; set; }
        public string TP_QUESTAO { get; set; }
        public string PERGUNTA { get; set; }
        public string RESPOSTA_CORRETA { get; set; }
        public double? PESO { get; set; }
        public string EXPLICACAO { get; set; }
        public string CANAL { get; set; }
        public string CARGO { get; set; }
        public string STATUS_QUESTION { get; set; }
        public string TP_BASE { get; set; }
        public string RESPOSTA { get; set; }
        public bool CORRECAO()
        {
            return this.RESPOSTA == this.RESPOSTA_CORRETA ? true : false;
        }
        public List<ALTERNATIVAS> ALTERNATIVAS { get; set; }
        public string REDE_AVALIADA { get; set; }
        public string DDD_AVALIADO { get; set; }
        public string PDV_AVALIADO { get; set; }
        public string RE_AVALIADO { get; set; }
    }
}
