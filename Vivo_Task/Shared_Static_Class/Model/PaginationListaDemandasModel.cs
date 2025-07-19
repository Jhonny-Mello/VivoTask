using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;

namespace Vivo_Task.Shared_Static_Class.FundamentalModels
{
    public class PaginationListaDemandasModel
    {
        public string matricula { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
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