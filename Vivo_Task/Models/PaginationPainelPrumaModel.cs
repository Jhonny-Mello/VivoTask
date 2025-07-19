using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;

namespace Vivo_Task.Models
{
    public class PaginationPainelPrumaModel
    {
        public bool GetDash { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public List<string>? Território { get; set; }
        public List<string>? UF { get; set; }
        public List<string>? DDD { get; set; }
        public List<string>? CIDADE { get; set; }
        public List<string>? MICROREGIÃO { get; set; }
        public List<string>? CEP { get; set; }
        public List<string>? BAIRRO { get; set; }
        public List<string>? LOGRADOURO { get; set; }
        public List<string>? NUMERO { get; set; }
        public List<string>? CAIXA { get; set; }
        public List<string>? TIPO_RESIDENCIA { get; set; }
        public List<string>? OCUPAÇAO { get; set; }
    }

}
