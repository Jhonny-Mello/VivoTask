using Vivo_Task.Shared_Static_Class.Data;

namespace Vivo_Task.Shared_Static_Class.Model_DTO
{
    public class PaginationDemandasModel
    {
        public PaginationDemandasModel(int? matricula,
                                       List<DateTime> datas,
                                       IReadOnlyList<string> regional,
                                       List<string> id_demandas,
                                       List<ACESSO> responsável,
                                       IList<string> status,
                                       List<DROPDOWN_FILA_MODEL> fila,
                                       List<DROPDOWN_FILA_MODEL> tipo_fila)
        {
            this.matricula = matricula;
            this.datas = datas;
            this.regional = regional;
            this.id_demandas = id_demandas;
            this.responsável = responsável;
            this.status = status;
            this.fila = fila;
            this.tipo_fila = tipo_fila;
        }

        public int? matricula { get; set; }
        public List<DateTime> datas { get; set; }
        public IReadOnlyList<string> regional { get; set; }
        public List<string> id_demandas { get; set; }
        public List<ACESSO> responsável { get; set; }
        public IList<string> status { get; set; }
        public List<DROPDOWN_FILA_MODEL> fila { get; set; }
        public List<DROPDOWN_FILA_MODEL> tipo_fila { get; set; }
        public bool IsRealTime { get; set; }
    }
}
