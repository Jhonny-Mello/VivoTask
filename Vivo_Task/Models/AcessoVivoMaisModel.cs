

using Vivo_Task.Shared_Static_Class.Data;

namespace Vivo_Task.Models
{
    public class AcessoVivoMaisModel
    {
        public int idAcesso { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Regional { get; set; }
        public byte[] Senha { get; set; }
        public byte[] Imagem { get; set; }
        public string Status { get; set; }
        public bool? Primeiro_Acesso { get; set; }
        public bool IsSuporte()
        {
            if (this.ACESSO_PERMISSAO_MENU.TipoAcesso.Contains("SUPORTE") ||
               this.ACESSO_PERMISSAO_MENU.TipoAcesso.Contains("ADMINISTRATIVO"))
            {
                return true;
            }
            return false;
        }
        public ACESSO_PERMISSAO_MENU ACESSO_PERMISSAO_MENU { get; set; }
    }
}
