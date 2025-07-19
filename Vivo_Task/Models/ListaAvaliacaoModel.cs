

using Vivo_Task.Shared_Static_Class.Converters;
using Vivo_Task.Shared_Static_Class.Enums;

namespace Vivo_Task.ModelDTO
{
    public class ListaAvaliacaoModel
    {
        public bool ListaTema { get; set; }
        public int ID_PROVA_RESPONDIDA { get; set; }
        public int? ID_PROVA { get; set; }
        public string TEMA { get; set; }
        public string TP_FORMS { get; set; }
        public Canal PUBLICO_CANAL { get; set; }
        public Cargos PUBLICO_CARGO { get; set; }
        public DateTime DT_AVALIACAO { get; set; }
        public int MATRICULA_AVALIADOR { get; set; }
        public string NOME { get; set; }
        public string CADERNO { get; set; }
        public double NOTA { get; set; }
        public string REDE_AVALIADA { get; set; }
        public string DDD_AVALIADO { get; set; }
        public string PDV_AVALIADO { get; set; }
        public int? RE_AVALIADO { get; set; }
        public string REGIONAL { get; set; }
    }
}
