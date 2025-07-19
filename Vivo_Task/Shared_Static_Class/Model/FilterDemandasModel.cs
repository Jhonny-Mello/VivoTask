using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.Model_DTO;

namespace Vivo_Task.Shared_Static_Class.FundamentalModels
{
    public class FilterDemandasModel
    {
        public IEnumerable<DROPDOWN_FILA_MODEL> fila { get; set; }
        public IEnumerable<ACESSO> analistassuporte { get; set; }
        public IEnumerable<string> status { get; set; }
    }
}
