using Microsoft.Extensions.Options;
using PropertyChanged;
using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.FundamentalModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivo_Task.Shared_Static_Class.Model_DTO
{
    [AddINotifyPropertyChangedInterface]
    public record CreateProdutoDTO : INotifyPropertyChanged
    {
        [MaxLength(255, ErrorMessage = "O Nome do produto tem o máximo de 255 caracteres")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; } = string.Empty;
        [MaxLength(1200, ErrorMessage = "O Nome do produto tem o máximo de 1200 caracteres")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descrição { get; set; } = string.Empty;

        [ValidateComplexType]
        [Required]
        public AvaliacaoDTO Avaliacao { get; set; } = new();

        [ValidateComplexType]
        [Required]
        public List<ArgumentacaoDTO> Argumentacao { get; set; } = [];

        [EnumDataType(typeof(Categoria_Produto), ErrorMessage = "Este valor não é válido para este campo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Categoria_Produto Categoria { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Fabricante { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cor { get; set; } = string.Empty;
        public bool IsOferta { get; set; } = false;
        public decimal Valor { get; set; } = 0;
        public int MaxParcelas { get; set; } = 0;
        public int MaxParcelasSemJuros { get; set; } = 0;

        [ListHasElements<FichaTecnicaDTO>(mincount: 5, ErrorMessage = "É necessário no mínimo 5 valores")]
        [ValidateComplexType]
        [Required]
        public List<FichaTecnicaDTO> Ficha { get; set; } = [];

        [ListHasElements<ProdutoImageDTO>(mincount: 1, ErrorMessage = "É necessário no mínimo 1 imagem")]
        [Required]
        public List<ProdutoImageDTO> Imagens { get; set; } = [];

        public event PropertyChangedEventHandler? PropertyChanged;

        public void AddInfo(FichaTecnicaDTO? newficha = null)
        {
            if (newficha == null)
            {
                newficha = new FichaTecnicaDTO(string.Empty, string.Empty, false, false);
            }

            Ficha.Add(newficha);
        }
        public void AddArg(ArgumentacaoDTO? newarg = null)
        {
            if (newarg == null)
            {
                newarg = new ArgumentacaoDTO(string.Empty, DateTime.Now, 0, false, false);
            }

            Argumentacao.Add(newarg);
        }
        public void RemoveInfo(FichaTecnicaDTO item)
        {
            Ficha.Remove(item);
        }
        public void RemoveArg(ArgumentacaoDTO arg)
        {
            Argumentacao.Remove(arg);
        }
    }

    public record FichaTecnicaDTO
    {
        public FichaTecnicaDTO(string especificação, string valor, bool isImportant, bool isInfoAdicional, Categoria_Especificação categoria = Categoria_Especificação.GENÉRICO, Tipo_Valor_Ficha tipoValor = Tipo_Valor_Ficha.STRING)
        {
            Especificação = especificação;
            Valor = valor;
            IsImportant = isImportant;
            IsInfoAdicional = isInfoAdicional;
            Categoria = categoria;
            TipoValor = tipoValor;
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo é obrigatório")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Especificação { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo é obrigatório")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Valor { get; set; } = string.Empty;
        public Categoria_Especificação Categoria { get; set; } = Categoria_Especificação.GENÉRICO;
        public Tipo_Valor_Ficha TipoValor { get; set; } = Tipo_Valor_Ficha.STRING;
        public bool IsImportant { get; set; } = false;
        public bool IsInfoAdicional { get; set; } = false;
    }

    public record ProdutoImageDTO
    {
        public ProdutoImageDTO(byte[] image, bool isloading, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Image = image;
            IsLoading = isloading;
        }

        public Guid? Id { get; set; } = null;
        [Required(ErrorMessage = "Imagem inválida")]
        public byte[] Image { get; set; }
        public bool IsLoading { get; set; } = false;
    }
    public record AvaliacaoDTO
    {
        public AvaliacaoDTO(int avaliacao = 0, int positionInRank = 0)
        {
            Avaliacao = avaliacao;
            PositionInRank = positionInRank;
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo é obrigatório")]
        [Range(0, 100, ErrorMessage = "A avaliação tem que estar entre 0 e 100")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public int Avaliacao { get; set; }
        public int PositionInRank { get; set; }
    }

    public record ArgumentacaoDTO
    {
        public ArgumentacaoDTO(string argumentacao, DateTime data_mod, int Media_arg, bool isGold = false, bool isBadCaracter = false, Guid? id_argumentacao = null, ACESSOS_MOBILE_DTO? resp = null)
        {
            Id_Argumentacao = id_argumentacao ?? Guid.Empty;
            MediaAvaliacao = Media_arg;
            Argumentacao = argumentacao;
            IsGold = isGold;
            IsBadCaracter = isBadCaracter;
            Responsavel = resp;
            Data_mod = data_mod;
            if (MediaAvaliacao > 0)
                ActualAvaliacao = MediaAvaliacao;
        }
        public Guid Id_Argumentacao { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(500, ErrorMessage = "As dicas de argumentação do produto tem o máximo de 500 caracteres")]
        [MinLength(25, ErrorMessage = "As dicas de argumentação do produto tem o mínimo de 25 caracteres")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Argumentacao { get; set; } = string.Empty;
        public bool IsGold { get; set; }
        public bool IsBadCaracter { get; set; }
        public DateTime Data_mod { get; set; }
        public ACESSOS_MOBILE_DTO? Responsavel { get; set; }
        public List<Avaliacao_argumentacaoDTO> Avaliacoes_arg { get; set; } = [];
        public int MediaAvaliacao { get; set; } = 0;
        public int ActualAvaliacao { get; set; } = 0;
    }

    public record Avaliacao_argumentacaoDTO
    {
        public Avaliacao_argumentacaoDTO() { }
        public Avaliacao_argumentacaoDTO(int avaliacao, bool isUtil = false)
        {
            Avaliacao = avaliacao;
            IsUtil = isUtil;
        }

        [Range(0, 100)]
        public int Avaliacao { get; set; }
        public bool IsUtil { get; set; }
    }

    public class GenericProperties
    {
        public string Tipo { get; set; } = string.Empty;
        public Categoria_Produto Categoria_tipo { get; set; }
        public List<string> Propriedades { get; set; } = [];
    }
}
