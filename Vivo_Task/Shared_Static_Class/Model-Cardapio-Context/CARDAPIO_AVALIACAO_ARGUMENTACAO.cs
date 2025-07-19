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

[Table("CARDAPIO_AVALIACAO_ARGUMENTACAO", Schema = "Cardapio")]
public partial class AVALIACAO_ARGUMENTACAO
{
    public AVALIACAO_ARGUMENTACAO() { }
    public AVALIACAO_ARGUMENTACAO(int avaliacao, bool isUtil, int mATRICULA_RESPONSAVEL, DateTime dT_MODIFICACAO, Guid? id_Argumentacao = null)
    {
        ID_ARGUMENTACAO = id_Argumentacao ?? Guid.Empty;
        Avaliacao = avaliacao;
        IsUtil = isUtil;
        MATRICULA_RESPONSAVEL = mATRICULA_RESPONSAVEL;
        DT_MODIFICACAO = dT_MODIFICACAO;
    }

    [Key]
    public Guid ID_AVALIACAO_ARGUMENTACAO { get; set; }
    public Guid ID_ARGUMENTACAO { get; set; }
    [Range(0, 100)]
    public int Avaliacao { get; set; }
    public bool IsUtil { get; set; }
    public int MATRICULA_RESPONSAVEL { get; set; }
    public DateTime DT_MODIFICACAO { get; set; }
    public ACESSOS_MOBILE? Responsavel { get; set; } = null;
    public ARGUMENTACAO_OURO Argumentacao { get; set; } = null;
}
