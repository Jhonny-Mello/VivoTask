using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vivo_Task.Shared_Static_Class.FundamentalModels
{
    public partial class Form
    {
        public string TIPO_ROTA { get; set; }
        public string MATRICULA { get; set; }
        public string DT_CRIACAO { get; set; }
        public string CARGO { get; set; }
        public string FIXA { get; set; }
        public DateTime DT_FINALIZACAO { get; set; } = DateTime.MaxValue;
        public DateTime Data_Aval { get; set; }
        public string CANAL {get;set;}
        public int Qtd_Perguntas { get; set; }
        public int Qtd_Temas { get; set; }
        public List<Temas> Temas { get; set; }
    }
    public class Temas
    {
        public int Qtd_Pergunta { get; set; }
        public string Tema { get; set; }
    }
}