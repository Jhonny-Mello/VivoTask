using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using Newtonsoft.Json;
using System.Web;

namespace Vivo_Task.Shared_Static_Class.FundamentalModels
{
    
    public class PaginationPainelRotaModel
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
        public List<string>? OCUPAÇÃO { get; set; }

    }

}

//{
//    "GetDash":"",
//"PageNumber":12,
//"PageSize":43,
//"Território":[],
//"UF":[],
//"DDD":[],
//"CIDADE":[],
//"MICRORREGIÃO":[],
//"CEP":[],
//"BAIRRO":[],
//"LOGRADOURO":[],
//"NÚMERO":[],
//"CAIXA":[],
//"TIPO_RESIDENCIA":[],
//"OCUPAÇÃO":[],
//}