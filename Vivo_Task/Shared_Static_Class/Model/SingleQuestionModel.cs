using Vivo_Task.Shared_Static_Class.Data;
using Shared_Class_Vivo_Apps.ModelDTO;

namespace Vivo_Task.Shared_Static_Class.FundamentalModels
{
    public class SingleQuestionModel
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
        public bool? STATUS_QUESTION { get; set; }
        public bool? FIXA { get; set; }
        public string SUB_TEMA { get; set; }
        public string DT_MOD { get; set; }
        public string LOGIN_MOD { get; set; }
        public IEnumerable<ALTERNATIVAS> ALTERNATIVAS { get; set; }
    }
}
