using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vivo_Task.Shared_Static_Class.FundamentalModels
{
    public class RespostaDemandaModel
    {
        public string resposta { get; set; }
        public int IdChamado { get; set; }
        public int MATRICULA { get; set; }
        public Guid ID_RELACAO { get; set; }
        public int? MATRICULA_REDIRECIONADO { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; } = string.Empty;
        public List<FileDataModel> Arquivos { get; set; } = new();
    }
}