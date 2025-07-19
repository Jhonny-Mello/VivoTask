using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Vivo_Task.Model_DTO
{

    public class BoletaModelUnvalidated : BoletaModel
    {
    }
    public class BoletaModel
    {
        public string? Id_Boleta { get; set; }
        public string? Mat_Consultor { get; set; }
        public List<BoletaDadosModel> Dados_Solicitacao { get; set; } = new List<BoletaDadosModel>
        {
            new()
        };
        public DateTime Data_Inicio { get; set; } = DateTime.Now;
        public decimal? Total_Pagamento
        {
            get
            {
                decimal total = 0;

                foreach (var dados in Dados_Solicitacao)
                {
                    foreach (var item in dados.boletaEquipamentos)
                    {
                        total += item.Valor;
                    }

                    foreach (var item in dados.Servicos_Atrelados)
                    {
                        total += item.Valor;
                    }

                    total += dados.Linha.Valor;
                }

                return total;
            }
        }
        public Met_Pagamento Met_Pagamento { get; set; }

    }
    public class BoletaClienteModel
    {
        public string? Id_Cliente_Boleta { get; set; }
        [Required(ErrorMessage = "Nome do cliente é obrigatório")]
        [DataType(DataType.Text)]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "CPF/CNPJ do cliente é obrigatório")]
        public string? Cpf_Cnpj { get; set; }
        [Required(ErrorMessage = "Senha GSS é obrigatório")]
        public string? Senha_GSS { get; set; }
        [JsonIgnore]
        private string? _telefone;
        [Required(ErrorMessage = "Telefone do Cliente é obrigatório")]
        public string? Telefone
        {
            get => _telefone;
            set
            {
                string digitsOnly = Regex.Replace(value, @"\D", "");

                if (digitsOnly.Length > 0)
                {
                    _telefone = "(" + digitsOnly.Substring(0, Math.Min(2, digitsOnly.Length)) + ")";

                    if (digitsOnly.Length > 2)
                    {
                        _telefone += digitsOnly.Substring(2, Math.Min(4, digitsOnly.Length - 2));
                    }

                    if (digitsOnly.Length > 6)
                    {
                        _telefone += digitsOnly.Substring(6, Math.Min(1, digitsOnly.Length - 6));
                    }

                    if (digitsOnly.Length > 7)
                    {
                        _telefone += "-" + digitsOnly.Substring(7, Math.Min(4, digitsOnly.Length - 7));
                    }
                }
                else
                {
                    _telefone = string.Empty;
                }
            }
        }

    }
    public class BoletaDadosModel
    {
        public int Id_Dados_Boleta { get; set; }
        private Plataforma _Plataforma;
        [Required(ErrorMessage = "Plataforma é obrigatório")]
        public Plataforma Plataforma
        {
            get => _Plataforma;
            set
            {
                _Plataforma = value;
                Movimento = null;
                Categoria = null;
                Plano = null;
                Portabilidade = false;
                Fidelizacao = false;
                Descricao = string.Empty;
                Linha = new();
                Servicos_Atrelados = new();
                boletaEquipamentos = new();
            }
        }

        private Categoria? _Categoria;
        [Required(ErrorMessage = "Categoria é obrigatório")]
        public Categoria? Categoria
        {
            get => _Categoria;
            set
            {
                _Categoria = value;
                Movimento = null;
                Plano = null;
                Portabilidade = false;
                Fidelizacao = false;
                Descricao = string.Empty;
                Linha = new();
                Servicos_Atrelados = new();
                boletaEquipamentos = new();
            }
        }

        private Movimento? _Movimento;
        [Required(ErrorMessage = "Movimento é obrigatório")]
        public Movimento? Movimento
        {
            get => _Movimento;
            set
            {
                _Movimento = value;
                Plano = null;
                Portabilidade = false;
                Fidelizacao = false;
                Descricao = string.Empty;
                Linha = new();
                Servicos_Atrelados = new();
                boletaEquipamentos = new();
            }
        }
        [Required(ErrorMessage = "Protabilidade é obrigatório")]
        public bool? Portabilidade { get; set; } = false;
        [Required(ErrorMessage = "Fidelização é obrigatório")]
        public bool? Fidelizacao { get; set; } = false;
        [Required(ErrorMessage = "Plano é obrigatório")]
        public Planos? Plano { get; set; }
        [Required(ErrorMessage = "Descrição é obrigatório")]
        public string? Descricao { get; set; }
        public bool? SVA { get; set; } = false;
        public bool? HasLinha { get; set; } = false;
        public bool? HasEquipamento { get; set; } = false;
        public BoletaLinhaModel? Linha { get; set; } = new();
        public List<SVA_Model>? Servicos_Atrelados { get; set; } = new();
        public List<BoletaEquipamentoModel>? boletaEquipamentos { get; set; } = new();
    }
    public class BoletaLinhaModel
    {
        public string? Id_Linha_Boleta { get; set; }
        [Required(ErrorMessage = "Número da linha é obrigatório")]
        [Range(1,int.MaxValue, ErrorMessage = "Número da linha é obrigatório")]
        public int Numero_Linha { get; set; }
        [Required(ErrorMessage = "Número provisório é obrigatório")]
        public int? Numero_Provisorio { get; set; }
        [Required(ErrorMessage = "ICCID é obrigatório")]
        public string? ICCID { get; set; } = string.Empty;
        [Required(ErrorMessage = "Material é obrigatório")]
        public string? Material { get; set; } = string.Empty;
        [Required(ErrorMessage = "Faturamento é obrigatório")]
        public string? Faturamento { get; set; } = string.Empty;
        [Required(ErrorMessage = "Nota Fiscal é obrigatório")]
        public string? NF { get; set; } = string.Empty;
        [Required(ErrorMessage = "Valor-Linha é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Valor mínimo da linha inválido")]
        public decimal Valor { get; set; }
        [Required(ErrorMessage = "Data de Vencimento é obrigatório")]
        public DateTime? Data_Venc_Fat { get; set; }
        [Required(ErrorMessage = "Operadora Doadora é obrigatório", AllowEmptyStrings = false)]
        public string Opera_doa { get; set; } = string.Empty;
    }
    public class SVA_Model
    {
        [Required(ErrorMessage = "Serviço atrelado é obrigatório", AllowEmptyStrings = false)]
        public SVA Nome { get; set; }
        [Required(ErrorMessage = "Valor do serviço atrelado é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Valor de SVA é obrigatório")]
        public decimal Valor { get; set; }
    }
    public class BoletaEquipamentoModel
    {
        public int Id_Equipamento_Boleta { get; set; }
        [Required(ErrorMessage = "Material é obrigatório")]
        public string? Material { get; set; } = string.Empty;
        [Required(ErrorMessage = "IMEI é obrigatório")]
        public string? IMEI { get; set; } = string.Empty;
        [Required(ErrorMessage = "Modelo é obrigatório", AllowEmptyStrings = false)]
        public string Modelo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Valor do equipamento é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Valor de equipamento é obrigatório")]
        public decimal Valor { get; set; }
        [Required(ErrorMessage = "Faturamento do equipamento é obrigatório")]
        public string? Faturamento { get; set; } = string.Empty;
        [Required(ErrorMessage = "Nota fiscal do equipamento é obrigatório")]
        public string? NF { get; set; } = string.Empty;
    }
    public enum Met_Pagamento
    {
        [Display(Name = "NULO")]
        NULO = 0,
        [Display(Name = "DINHEIRO")]
        DINHEIRO = 1,
        [Display(Name = "CRÉDITO")]
        CREDITO = 2,
        [Display(Name = "DÉBITO")]
        DEBITO = 3,
        [Display(Name = "DOAÇÃO")]
        DOACAO = 4,
    }
    public enum Movimento
    {
        [Display(Name = "NULO")]
        NULO = 0,
        [Display(Name = "ALTA")]
        ALTA = 1,
        [Display(Name = "MIGRAÇÃO")]
        MIGRACAO = 2,
        [Display(Name = "UPGRADE")]
        UPGRADE = 3,
        [Display(Name = "RESGATE")]
        RESGATE = 4,
        [Display(Name = "FIDELIZAÇÃO")]
        FIDELIZACAO = 5,
        [Display(Name = "AQUISIÇÃO AVULSA")]
        AQUISICAO_AVULSA = 6
    }
    public enum Plataforma
    {
        [Display(Name = "NULO")]
        NULO = 0,
        [Display(Name = "MÓVEL")]
        MOVEL = 1,
        [Display(Name = "FIXA")]
        FIXA = 2,
        [Display(Name = "TERMINAIS")]
        TERMINAIS = 3
    }
    public enum Categoria
    {
        [Display(Name = "NULO")]
        NULO = 0,
        [Display(Name = "POS PURO")]
        POS_PURO = 1,
        [Display(Name = "DADOS")]
        DADOS = 2,
        [Display(Name = "CONTROLE")]
        CONTROLE = 3,
        [Display(Name = "PRE-PAGO")]
        PRE_PAGO = 4,
        [Display(Name = "FIXO")]
        FIXO = 5,
        [Display(Name = "TV")]
        TV = 6,
        [Display(Name = "BANDA LARGA")]
        BANDA_LARGA = 7,
        [Display(Name = "2P (FIXO + BL)")]
        DOISP_FIXO_BL = 8,
        [Display(Name = "2P (TV + BL)")]
        DOISP_TV_BL = 9,
        [Display(Name = "3P (FIXO + BL + TV)")]
        TRESP_FIXO_BL_TV = 10,
        [Display(Name = "ACESSORIOS")]
        ACESSORIOS = 11,
        [Display(Name = "APARELHO")]
        APARELHO = 12,
        [Display(Name = "SVA")]
        SVA = 13,
        [Display(Name = "SEGURO")]
        SEGURO = 14,

    }
    public enum Planos
    {
        [Display(Name = "NULO")]
        NULO = 0,
        [Display(Name = "Vivo Total V")]
        Vivo_Total_V = 1,
        [Display(Name = "Vivo Total Familia 5")]
        Vivo_Total_Familia_5 = 2,
        [Display(Name = "Vivo Total Familia 3")]
        Vivo_Total_Familia_3 = 3,
        [Display(Name = "Vivo Total Familia 2")]
        Vivo_Total_Familia_2 = 4,
        [Display(Name = "Vivo Total Pró")]
        Vivo_Total_Pró = 5,
        [Display(Name = "Vivo Total Essencial")]
        Vivo_Total_Essencial = 6,
        [Display(Name = "Vivo V")]
        Vivo_V = 7,
        [Display(Name = "Familia 200GB")]
        Familia_200GB = 8,
        [Display(Name = "Familia 150GB")]
        Familia_150GB = 9,
        [Display(Name = "Familia 100GB")]
        Familia_100GB = 10,
        [Display(Name = "Familia 60GB")]
        Familia_60GB = 11,
        [Display(Name = "Vivo Selfie Travel")]
        Vivo_Selfie_Travel = 12,
        [Display(Name = "Vivo Selfie Premiere")]
        Vivo_Selfie_Premiere = 13,
        [Display(Name = "Vivo Selfie Netflix")]
        Vivo_Selfie_Netflix = 14,
        [Display(Name = "Vivo Selfie Disney+")]
        Vivo_Selfie_Disney = 15,
        [Display(Name = "Vivo Selfie Telecine")]
        Vivo_Selfie_Telecine = 16,
        [Display(Name = "Vivo Selfie Globoplay")]
        Vivo_Selfie_Globoplay = 17,
        [Display(Name = "Vivo Selfie Spotify")]
        Vivo_Selfie_Spotify = 18,
        [Display(Name = "Vivo Selfie Amazon Prime")]
        Vivo_Selfie_Amazon_Prime = 19,
        [Display(Name = "Conctrolel 17GB")]
        Conctrolel_17GB = 20,
        [Display(Name = "Conctrolel 13GB")]
        Conctrolel_13GB = 21,
        [Display(Name = "Conctrolel Música 13GB")]
        Conctrolel_Música_13GB = 22,
        [Display(Name = "Conctrolel Saúde 13GB")]
        Conctrolel_Saúde_13GB = 23,
        [Display(Name = "Conctrolel 11GB")]
        Conctrolel_11GB = 24,
        [Display(Name = "Conctrolel 9GB")]
        Conctrolel_9GB = 25,
        [Display(Name = "Pré Pago Vivo Turbo 10GB")]
        Pré_Pago_Vivo_Turbo_10GB = 26,
        [Display(Name = "Pré Pago Vivo Turbo 6GB")]
        Pré_Pago_Vivo_Turbo_6GB = 27,
        [Display(Name = "Pré Pago Vivo Turbo 5GB")]
        Pré_Pago_Vivo_Turbo_5GB = 28,
        [Display(Name = "Pré Pago Vivo Turbo 4GB")]
        Pré_Pago_Vivo_Turbo_4GB = 29,
        [Display(Name = "Vivo Easy Monte do seu jeito")]
        Vivo_Easy_monte_do_seu_jeito = 30,
        [Display(Name = "Vivo Easy Monte Prime Super 24GB")]
        Vivo_Easy_monte_Prime_Super_24GB = 31,
        [Display(Name = "Vivo Easy Monte Prime Especial 18GB")]
        Vivo_Easy_monte_Prime_Especial_18GB = 32,
        [Display(Name = "Vivo Easy Monte Prime Alive 12GB")]
        Vivo_Easy_monte_Prime_Alive_12GB = 33,
        [Display(Name = "Vivo Easy Monte Prime Essencial 9GB")]
        Vivo_Easy_monte_Prime_Essencial_9GB = 34,
        [Display(Name = "Vivo Easy Monte Prime Lught 6GB")]
        Vivo_Easy_monte_Prime_Lught_6GB = 35,
        [Display(Name = "300 Mega Nacional")] 
        TREZENTOS_Mega__Nacional = 36,
        [Display(Name = "300 Mega Nacional + Amazon Prime")]   
        TREZENTOS_Mega_Nacional__Amazon_Prime = 37,
        [Display(Name = "300 Mega Nacional + Globoplay")]  
        TREZENTOS_Mega_Nacional__Globoplay = 38,
        [Display(Name = "300 Mega Nacional + HBO Max")]
        TREZENTOS_Mega_Nacional__HBO_Max = 39,
        [Display(Name = "300 Mega Nacional + Disney +")]   
        TREZENTOS_Mega_Nacional__Disney_ = 40,
        [Display(Name = "300 Mega Nacional + Netflix Padrão")] 
        TREZENTOS_Mega_Nacional__Netflix_Padrão = 41,
        [Display(Name = "300 Mega Nacional + Netflix Premium")]
        TREZENTOS_Mega_Nacional__Netflix_Premium = 42,
        [Display(Name = "300 Mega Nacional + Vivo Play App Inicial")]  
        TREZENTOS_Mega_Nacional__Vivo_Play_App_Inicial = 43,
        [Display(Name = "301 Mega Nacional + Vivo Play App Estendido")]
        TREZENTOS_UM_Mega_Nacional__Vivo_Play_App_Estendido = 44,
        [Display(Name = "300 Mega Personalizado")] 
        TREZENTOS_Mega_Personalizado = 45,
        [Display(Name = "300 Mega Personalizado + Amazon Prime")]  
        TREZENTOS_Mega_Personalizado__Amazon_Prime = 46,
        [Display(Name = "300 Mega Personalizado + Globoplay")] 
        TREZENTOS_Mega_Personalizado__Globoplay = 47,
        [Display(Name = "300 Mega Personalizado + HBO Max")]   
        TREZENTOS_Mega_Personalizado__HBO_Max = 48,
        [Display(Name = "300 Mega Personalizado + Disney +")]  
        TREZENTOS_Mega_Personalizado__Disney_ = 49,
        [Display(Name = "300 Mega Personalizado + Netflix Padrão")]
        TREZENTOS_Mega_Personalizado__Netflix_Padrão = 50,
        [Display(Name = "300 Mega Personalizado + Netflix Premium")]   
        TREZENTOS_Mega_Personalizado__Netflix_Premium = 51,
        [Display(Name = "300 Mega Personalizado + Vivo Play App Inicial")] 
        TREZENTOS_Mega_Personalizado__Vivo_Play_App_Inicial = 52,
        [Display(Name = "300 Mega Personalizado + Vivo Play App Estendido")]   
        TREZENTOS_Mega_Personalizado__Vivo_Play_App_Estendido = 53,
        [Display(Name = "500 Mega Nacional")]  
        QUINHENTOS_Mega_Nacional = 54,
        [Display(Name = "500 Mega Nacional + Amazon Prime")]   
        QUINHENTOS_Mega_Nacional__Amazon_Prime = 55,
        [Display(Name = "500 Mega Nacional + Globoplay")]  
        QUINHENTOS_Mega_Nacional__Globoplay = 56,
        [Display(Name = "500 Mega Nacional + HBO Max")]
        QUINHENTOS_Mega_Nacional__HBO_Max = 57,
        [Display(Name = "500 Mega Nacional + Disney +")]   
        QUINHENTOS_Mega_Nacional__Disney_ = 58,
        [Display(Name = "500 Mega Nacional + Netflix Padrão")] 
        QUINHENTOS_Mega_Nacional__Netflix_Padrão = 59,
        [Display(Name = "500 Mega Nacional + Netflix Premium")]
        QUINHENTOS_Mega_Nacional__Netflix_Premium = 60,
        [Display(Name = "500 Mega Nacional + Vivo Play App Inicial")]  
        QUINHENTOS_Mega_Nacional__Vivo_Play_App_Inicial = 61,
        [Display(Name = "500 Mega Nacional + Vivo Play App Estendido")]
        QUINHENTOS_Mega_Nacional__Vivo_Play_App_Estendido = 62,
        [Display(Name = "700 Mega Nacional")]  
        SETECENTOS_Mega_Nacional = 63,
        [Display(Name = "700 Mega Nacional + Amazon Prime")]   
        SETECENTOS_Mega_Nacional__Amazon_Prime = 64,
        [Display(Name = "700 Mega Nacional + Globoplay")]  
        SETECENTOS_Mega_Nacional__Globoplay = 65,
        [Display(Name = "700 Mega Nacional + HBO Max")]
        SETECENTOS_Mega_Nacional__HBO_Max = 66,
        [Display(Name = "700 Mega Nacional + Disney +")]   
        SETECENTOS_Mega_Nacional__Disney_ = 67,
        [Display(Name = "700 Mega Nacional + Netflix Padrão")] 
        SETECENTOS_Mega_Nacional__Netflix_Padrão = 68,
        [Display(Name = "700 Mega Nacional + Netflix Premium")]
        SETECENTOS_Mega_Nacional__Netflix_Premium = 69,
        [Display(Name = "700 Mega Nacional + Vivo Play App Inicial")]  
        SETECENTOS_Mega_Nacional__Vivo_Play_App_Inicial = 70,
        [Display(Name = "700 Mega Nacional + Vivo Play App Estendido")]
        SETECENTOS_Mega_Nacional__Vivo_Play_App_Estendido = 71,
        [Display(Name = "1GB Nacional")]   
        UM_GB_Nacional = 72,
        [Display(Name = "1GB Nacional + Amazon Prime")]
        UM_GB_Nacional__Amazon_Prime = 73,
        [Display(Name = "1GB Nacional + Globoplay")]   
        UM_GB_Nacional__Globoplay = 74,
        [Display(Name = "1GB Nacional + HBO Max")] 
        UM_GB_Nacional__HBO_Max = 75,
        [Display(Name = "1GB Nacional + Disney +")]
        UM_GB_Nacional__Disney_ = 76,
        [Display(Name = "1GB Nacional + Netflix Padrão")]  
        UM_GB_Nacional__Netflix_Padrão = 77,
        [Display(Name = "1GB Nacional + Netflix Premium")] 
        UM_GB_Nacional__Netflix_Premium = 78,
        [Display(Name = "1GB Nacional + Vivo Play App Inicial")]   
        UM_GB_Nacional__Vivo_Play_App_Inicial = 79,
        [Display(Name = "1GB Nacional + Vivo Play App Estendido")] 
        UM_GB_Nacional__Vivo_Play_App_Estendido = 80,
        [Display(Name = "Smart Empresas 3GB")]
        Smart_Empresas_3GB = 81,
        [Display(Name = "Smart Empresas 6GB")]
        Smart_Empresas_6GB = 82,
        [Display(Name = "Smart Empresas 12GB")]
        Smart_Empresas_12GB = 83,
        [Display(Name = "Smart Empresas 15GB")]
        Smart_Empresas_15GB = 84,
        [Display(Name = "Smart Empresas 20GB")]
        Smart_Empresas_20GB = 85,
        [Display(Name = "Smart Empresas 30GB")]
        Smart_Empresas_30GB = 86,
        [Display(Name = "Smart Empresas 40GB")]
        Smart_Empresas_40GB = 87,
        [Display(Name = "Smart Empresas 60GB")]
        Smart_Empresas_60GB = 88,
        [Display(Name = "Smart Empresas 100GB")]
        Smart_Empresas_100GB = 89,
        [Display(Name = "200 Mega")]   
        DOZENTOS_Mega = 90,
        [Display(Name = "300 Mega")]   
        TREZENTOS_Mega = 91,
        [Display(Name = "600 Mega")]   
        SEISSENTOS_Mega = 92,
        [Display(Name = "1GB")]
        UM_GB = 93,

    }
    public enum SVA
    {
        [Display(Name = "NULO")]
        NULO = 0,
        [Display(Name = "NETFLIX")]
        NETFLIX = 1,
        [Display(Name = "GLOBO PLAY")]
        GLOBO_PLAY = 2,
        [Display(Name = "HBO MAX")]
        HBO_MAX = 3,
        [Display(Name = "PRIME")]
        PRIME = 4,
        [Display(Name = "STAR-PLUS")]
        STAR_PLUS = 5,

    }

}
