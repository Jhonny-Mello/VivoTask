using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivo_Task.Models
{
    public class CardsPrincipaisModel
    {
        public CardsPrincipaisModel(string tITULO, string dESCRICAO, string iMAGEM, Command click)
        {
            TITULO = tITULO;
            DESCRICAO = dESCRICAO;
            IMAGEM = iMAGEM;
            Click = click;
        }

        public string TITULO { get; set; } = string.Empty;
        public string DESCRICAO { get; set; } = string.Empty;
        public string IMAGEM { get; set; } = string.Empty;
        public Command Click { get; set; }

    }
}
