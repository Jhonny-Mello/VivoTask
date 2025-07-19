
namespace Vivo_Task.Shared_Static_Class.Model_DTO
{
    public class FilterFilaDemandasModel
    {
        public IEnumerable<RELACAO_FILA_SUB_FILA> filas { get; set; } = new List<RELACAO_FILA_SUB_FILA>();
        public IEnumerable<ACESSOS_MOBILE_DTO> AnalistaSuporte { get; set; } = new List<ACESSOS_MOBILE_DTO>();
    }

    public class RELACAO_FILA_SUB_FILA
    {
        public RELACAO_FILA_SUB_FILA(int iD_FILA, string nOME_FILA, int iD_SUB_FILA, string nOME_SUB_FILA, int[] responsaveis = null)
        {
            ID_FILA = iD_FILA;
            NOME_TIPO_FILA = nOME_FILA;
            ID_SUB_FILA = iD_SUB_FILA;
            NOME_SUB_FILA = nOME_SUB_FILA;
            this.responsaveis = responsaveis ?? [];
        }

        public int ID_FILA { get; set; }
        public string NOME_TIPO_FILA { get;set;}
        public int ID_SUB_FILA {get;set;}
        public string NOME_SUB_FILA {get;set;}
        public IEnumerable<int> responsaveis {get;set;}
    }
}
