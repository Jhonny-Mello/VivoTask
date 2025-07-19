using Vivo_Task.Shared_Static_Class.Converters;
using Vivo_Task.Shared_Static_Class.Data;

namespace Vivo_Task.Shared_Static_Class.Model_DTO.FilterModels;

public class PainelCardapioDigital
{
    public PainelCardapioDigital()
    {
    }

    public PainelCardapioDigital(string search, int avaliacao, List<Categoria_Produto> categorias, List<Categoria_Especificação> especificações, List<string> cor, List<string> fabricante, bool? isOferta, decimal valor)
    {
        this.search = search;
        this.avaliacao = avaliacao;
        this.categorias = categorias ?? [];
        this.especificações = especificações ?? [];
        this.cor = cor ?? [];
        this.fabricante = fabricante ?? [];
        IsOferta = isOferta;
        Valor = valor;
    }

    public string search { get; set; } = string.Empty;
    public int avaliacao { get; set; } = 0;
    public List<Categoria_Produto> categorias { get; set; } = [];
    public List<Categoria_Especificação> especificações { get; set; } = [];
    public List<string> cor { get; set; } = [];
    public List<string> fabricante { get; set; } = [];
    public bool? IsOferta { get; set; } = null;
    public decimal Valor { get; set; } = 0;


}