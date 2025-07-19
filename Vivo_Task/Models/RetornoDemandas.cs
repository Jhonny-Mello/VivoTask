using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vivo_Task.Models
{
    public class RetornoDemandas
    {
        public int ID { get; set; }
        public int? ID_CAMPOS_CHAMADO { get; set; }
        public int? ID_STATUS_CHAMADO { get; set; }
        public int? ID_FILA_CHAMADO { get; set; }
        public string MATRICULA_RESPONSAVEL { get; set; }
        public string MATRICULA_SOLICITANTE { get; set; }
        public DateTime? DATA_ABERTURA { get; set; }
        public DateTime? DATA_FECHAMENTO { get; set; }
        public string PRIORIDADE { get; set; }
        public string REGIONAL { get; set; }
        public string EMAIL_SECUNDARIO { get; set; }
        public string ULTIMO_STATUS { get; set; }
        public string DATA_STATUS { get; set; }
    }
}