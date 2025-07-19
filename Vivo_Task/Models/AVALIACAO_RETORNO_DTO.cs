using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivo_Task.Models
{
    public class AVALIACAO_RETORNO_DTO
    {
        public int ID { get; set; }
        public string ID_QUESTION { get; set; }
        public string ID_TEMAS { get; set; }
        public string TP_FORMS { get; set; }
        public string PESO { get; set; }
        public string PUBLICO_CANAL { get; set; }
        public string PUBLICO_CARGO { get; set; }
        public string DT_AVALIACAO { get; set; }
        public string MATRICULA_APLICADOR { get; set; }
        public string CADERNO { get; set; }
        public string RESPOSTA_USER { get; set; }
        public string REDE_AVALIADA { get; set; }
        public string DDD_AVALIADO { get; set; }
        public string PDV_AVALIADO { get; set; }
        public string RE_AVALIADO { get; set; }
        public bool? STATUS_RESPOSTA { get; set; }
        public int? ID_PROVA_RESPONDIDA { get; set; }
        public string? ID_SUB_TEMAS { get; set; }
        public string REGIONAL { get; set; }
        public int? ID_PROVA { get; set; }
    }
}
