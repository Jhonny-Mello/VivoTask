using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivo_Task.Models
{
    public class UserModel
    {
        public string EMAIL { get; set; }
        public string MATRICULA { get; set; }
        public string SENHA { get; set; }
        public string REGIONAL { get; set; }
        public string CARGO { get; set; }
        public string CANAL { get; set; }
        public string PDV { get; set; }
        public string CPF { get; set; }
        public string NOME { get; set; }
        public string? ROLE_RTCZ { get; set; }
        public string? ROLE_VIVOMAIS { get; set; }
        public string? ROLE_PAINEL { get; set; }
        public string UF { get; set; }
        public bool STATUS { get; set; }
        public string FIXA { get; set; }
        public string TP_AFASTAMENTO { get; set; }
        public string OBS { get; set; }
        public byte[] UserAvatar { get; set; }
    }
}


