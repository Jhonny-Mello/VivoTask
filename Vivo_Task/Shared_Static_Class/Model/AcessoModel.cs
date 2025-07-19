using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.Enums;
using Vivo_Task.Shared_Static_Class.Model_DTO;
using Vivo_Task.Shared_Static_Class.Converters;

namespace Vivo_Task.Shared_Static_Class.FundamentalModels
{
    public class AcessoModel
    {
        public int ID { get; set; }
        public string EMAIL { get; set; }
        public int MATRICULA { get; set; }
        public string SENHA { get; set; }
        public string REGIONAL { get; set; }
        public Cargos CARGO { get; set; }
        public Canal CANAL { get; set; }
        public string PDV { get; set; }
        public string? CPF { get; set; }
        public string NOME { get; set; }
        public string UF { get; set; }
        public string TELEFONE { get; set; } = "(00) 00000-0000";
        public int DDD { get; set; }
        public bool? STATUS { get; set; }
        public bool? FIXA { get; set; }
        public string? TP_AFASTAMENTO { get; set; }
        public string? OBS { get; set; }
        public byte[]? UserAvatar { get; set; }
        public int? LOGIN_MOD { get; set; }
        public DateTime? DT_MOD { get; set; }
        public IEnumerable<Perfil> Perfil { get; set; } = [];
        public bool IsMaster()
        {
            if (this.Perfil.Any(x=> x.Perfil_Plataforma.ID_PERFIL == 1)
            )
            {
                return true;
            }

            return false;
        }
        public bool IsSuporte()
        {
            if (this.Perfil.Any(x=> x.Perfil_Plataforma.ID_PERFIL == 1
            || x.Perfil_Plataforma.ID_PERFIL == 10)
            )
            {
                return true;
            }

            return false;
        }
        public bool IsHierarquiaJornada()
        {
            if (this.Perfil.Any(x=> x.Perfil_Plataforma.ID_PERFIL == 1
            || x.Perfil_Plataforma.ID_PERFIL == 18
            || x.Perfil_Plataforma.ID_PERFIL == 19
            )
            )
            {
                return true;
            }

            return false;
        }
        public bool IsHierarquiaJornadaADM()
        {
            if (this.Perfil.Any(x=> x.Perfil_Plataforma.ID_PERFIL == 1
            || x.Perfil_Plataforma.ID_PERFIL == 19)
            )
            {
                return true;
            }

            return false;
        }
    }
}
