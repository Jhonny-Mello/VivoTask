using Vivo_Task.ViewModels;

namespace Vivo_Task.Models
{
    public class PainelRotaStatePage
    {
        public int PageNumber { get; set; } = 0;
        public int PageSize { get; set; }
        public int TotalPages { get; set; } = 0;
        public int TotalRecords { get; set; }
        public bool isFirstpage { get; set; }
        public bool isLastpage { get; set; }
        public double Pcr_ocupação { get; set; }
        public double Pcr_disponível { get; set; }
        public int qtd_total_casas { get; set; }
        public int qtd_total_prédios { get; set; }
        public int qtd_clientes_FTTC { get; set; }
        public int total_cliente_BADDEBT { get; set; }
        public int total_clientes_FRAUDE { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string[] Message { get; set; }
        public List<PainelRotaModel> Data { get; set; }
    }
}