namespace Vivo_Task.Models
{
    public class PaginationDemandasModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string matricula { get; set; } = string.Empty;
        public IReadOnlyList<DateTime> datas { get; set; } = new List<DateTime>();
        public IReadOnlyList<string> regional { get; set; } = new List<string>();
        public List<string> id_demandas { get; set; } = new List<string>();
        public IList<string> responsável { get; set; } = new List<string>();
        public IList<string> status { get; set; } = new List<string>();
        public IList<string> fila { get; set; } = new List<string>();
        public IList<string> tipo_fila { get; set; } = new List<string>();
    }
}
