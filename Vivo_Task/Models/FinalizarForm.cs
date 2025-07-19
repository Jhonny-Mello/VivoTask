using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vivo_Task.Models
{
    public class FinalizarForm
    {
        public int ID_PROVA { get; set; }
        public int ID_QUESTION { get; set; }
        public string CANAL { get; set; }
        public string DT_CRIACAO { get; set; }
        public string ID_CRIADOR { get; set; }
        public string CARGO { get; set; }
        public int CADERNO { get; set; }
        public string TP_FORMS { get; set; }
        public string DT_INICIO_AVALIACAO { get; set; }
        public string? DT_FINALIZACAO { get; set; }
        public string FIXA { get; set; }
    }
}