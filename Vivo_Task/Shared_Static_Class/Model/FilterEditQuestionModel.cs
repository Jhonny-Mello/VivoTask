namespace Vivo_Task.Shared_Static_Class.FundamentalModels
{
    public class FilterEditQuestionModel
    {
        public int? Id_Question { get; set; }
        public string? Pergunta { get; set; }
        public bool? Fixa { get; set; }
        public string Regional { get; set; } = string.Empty;
        public IEnumerable<Option<string>>? TP_questao { get; set; } = new List<Option<string>>();
        public List<int>? Temas { get; set; } = new List<int>();
        public List<int>? Sub_temas { get; set; } = new List<int>();
        public List<int>? Cargos { get; set; } = new List<int>();
        public IEnumerable<int>? Canal { get; set; } = new List<int>();
        public bool? Status { get; set; } = true;
    }
}
