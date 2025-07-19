using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.Enums;
using Shared_Class_Vivo_Apps.ModelDTO;
using Vivo_Task.Shared_Static_Class.Converters;
using Vivo_Task.Shared_Static_Class.Model_DTO;

namespace Vivo_Task.Shared_Static_Class.FundamentalModels
{
    public class QuestionModel
    {
        public int ID_QUESTION { get; set; }
        public string TEMA { get; set; }
        public string? TP_FORMS { get; set; }
        public string TP_QUESTAO { get; set; }
        public string PERGUNTA { get; set; }
        public string RESPOSTA_CORRETA { get; set; }
        public double? PESO { get; set; }
        public string EXPLICACAO { get; set; }
        public string REGIONAL { get; set; }
        public IEnumerable<Canal>? CANAIS { get; set; }
        public IEnumerable<Cargos>? CARGOS { get; set; }
        public bool STATUS_QUESTION { get; set; }
        public bool? FIXA { get; set; }
        public string SUB_TEMA { get; set; }
        public DateTime? DT_MOD { get; set; }
        public ACESSOS_MOBILE_DTO? LOGIN_MOD { get; set; }
    }
}
