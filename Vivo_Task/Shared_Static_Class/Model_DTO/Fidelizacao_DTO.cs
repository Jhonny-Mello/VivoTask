using System;
using System.Collections.Generic;
using System.Text;

namespace Vivo_Task.Shared_Static_Class.Model_DTO
{
    public class FidelizacaoDTO

    {
        public int IDUSER { get; set; }
        public string LINHAFIDELIZADA { get; set; }

        public DateTime? DATAFIDELIZACAO { get; set; }=DateTime.Now;

        public string TIPOJUSTIFICATIVA { get; set; }

        public string MOTIVO { get; set; }

        public bool MULTA_OK { get; set; }

        public bool NEXT { get; set; }

        public DateTime? DT_CHAMADO { get; set; } = DateTime.Now;

        public string N_CHAMADO { get; set; }

        public string N_TICKET { get; set; }

        public DateTime? DT_ABERTURA { get; set; } = DateTime.Now;

        public string ACAO_CORRETIVA { get; set; }

        public string ACAO_PREVENTIVA { get; set; }

        public string N_VOUCHER { get; set; }

        public DateTime? DT_VOUCHER { get; set; } = DateTime.Now;

        public decimal VL_VOUCHER { get; set; }

        public decimal VL_TABELA { get; set; }

        public int N_PROTOCOLO_GED { get; set; }



    }

}