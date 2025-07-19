using System.Text.Json.Serialization;

namespace Vivo_Task.Shared_Static_Class.Model_DTO
{
    public class PaginationFilaDemandasModel
    {
        public string id_fila { get; set; } = string.Empty;
        public string nome_fila { get; set; } = string.Empty;
        public IReadOnlyList<string> regional { get; set; } = [];
        public List<string> campos { get; set; } = [];
        public List<int> responsável { get; set; }  = [];
        public List<int> fila_macro { get; set; }  = [];
        public List<int> sub_fila { get; set; }  = [];
    }
}
