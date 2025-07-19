#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Newtonsoft.Json;
using Vivo_Task.Shared_Static_Class.Model_Demanda_Context;
using Vivo_Task.Shared_Static_Class.Model_DTO;

namespace Vivo_Task.Shared_Static_Class.Data;

[Table("CARDAPIO_ARGUMENTACAO_OURO", Schema = "Cardapio")]
public partial class ARGUMENTACAO_OURO
{
    public ARGUMENTACAO_OURO()
    {

    }
    public ARGUMENTACAO_OURO(string argumentacao, bool isGold, bool isBadCaracter, int mATRICULA_RESPONSAVEL, DateTime dT_MODIFICACAO, List<AVALIACAO_ARGUMENTACAO> avaliacoes = null, Guid? id_produto = null, Guid? id_argumentacao = null)
    {
        ID_ARGUMENTACAO = id_argumentacao ?? Guid.Empty;
        ID_PRODUTO = id_produto ?? Guid.Empty;
        Argumentacao = argumentacao;
        IsGold = isGold;
        IsBadCaracter = isBadCaracter;
        MATRICULA_RESPONSAVEL = mATRICULA_RESPONSAVEL;
        DT_MODIFICACAO = dT_MODIFICACAO;
        Avaliacoes = avaliacoes ?? [];
    }

    [Key]
    public Guid ID_ARGUMENTACAO { get; set; }
    public Guid ID_PRODUTO { get; set; }
    public string Argumentacao { get; set; } = string.Empty;
    /// <summary>
    /// Define se é uma ótima argumentação, essa escolha é feita pelo time responsável pela ferramenta
    /// </summary>
    public bool IsGold { get; set; } = false;
    /// <summary>
    /// Define se o comentário em questão é boa ou má característica do produto
    /// </summary>
    public bool IsBadCaracter { get; set; } = false;
    public int MATRICULA_RESPONSAVEL { get; set; }
    public DateTime DT_MODIFICACAO { get; set; }
    public PRODUTOS_CARDAPIO Produto { get; set; } = null;
    public ACESSOS_MOBILE Responsavel { get; set; } = null;
    public List<AVALIACAO_ARGUMENTACAO> Avaliacoes { get; set; } = [];

    public int SetAvaliacaoArgumentacaoGeral()
    {
        var count = Avaliacoes.Count;
        var sumnotas = Avaliacoes.Sum(x => x.Avaliacao);

        if (count > 0)
        {
            return (int)Math.Round((double)(sumnotas / count), 0);
        }
        else
        {
            return 0;
        }
    }
}
