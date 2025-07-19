using System.Text.RegularExpressions;
using Vivo_Task.Shared_Static_Class.Enums;

namespace Vivo_Task.Shared_Static_Class.Converters
{
    public static class DePara
    {

        public static Canal CanalCargoEnum(Cargos cargo)
        {
            switch (cargo)
            {
                case Cargos.Vendedor_PAP:
                    return Canal.Venda_Externa;
                case Cargos.Gerente_Parceiros:
                    return Canal.Consumer;
                case Cargos.Gerente_Geral:
                    return Canal.Lojas_Próprias;
                case Cargos.Supervisor_PAP:
                    return Canal.Venda_Externa;
                case Cargos.Vendedor_Revenda:
                    return Canal.Revenda;
                case Cargos.Gerente_Revenda:
                    return Canal.Revenda;
                case Cargos.Gerente_Área:
                    return Canal.Canal_Vendas;
                case Cargos.Gerente_Operações:
                    return Canal.Lojas_Próprias;
                case Cargos.Consultor_Negócios:
                    return Canal.Lojas_Próprias;
                case Cargos.Consultor_Tecnológico:
                    return Canal.Lojas_Próprias;
                case Cargos.Gerente_Vendas_B2C:
                    return Canal.Canal_Vendas;
                case Cargos.Gerente_Senior_Territorial:
                    return Canal.Canal_Vendas;
                case Cargos.Coordenador_Suporte_Vendas:
                    return Canal.Consumer;
                case Cargos.Gerente_Suporte_Vendas:
                    return Canal.Consumer;
                case Cargos.Diretora:
                    return Canal.Consumer;
                case Cargos.Consultor_Gestão_Vendas:
                    return Canal.Consumer;
                case Cargos.Analista_Suporte_Vendas_Senior:
                    return Canal.Consumer;
                case Cargos.Analista_Suporte_Vendas_Pleno:
                    return Canal.Consumer;
                case Cargos.Analista_Suporte_Vendas_Junior:
                    return Canal.Consumer;
                case Cargos.Estagiário:
                    return Canal.Consumer;
                case Cargos.Gerente_Senior_Gestão_Vendas:
                    return Canal.Consumer;
                case Cargos.Representante_de_vendas:
                    return Canal.Distribuicao;
                case Cargos.Gerente_de_area_PAP:
                    return Canal.Canal_Vendas;
                default:
                    return Canal.ADM;

            }
        }

    }
}
