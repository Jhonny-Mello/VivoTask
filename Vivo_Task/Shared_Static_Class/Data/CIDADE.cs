﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Keyless]
[Table("CIDADES")]
public partial class CIDADE
{
    public int cidade_id { get; set; }

    [Required]
    [StringLength(60)]
    [Unicode(false)]
    public string desc_cidade { get; set; }

    [Required]
    [StringLength(2)]
    [Unicode(false)]
    public string flg_estado { get; set; }

    public int? capacidade_rede_primaria { get; set; }

    public int? em_uso_rede_primaria { get; set; }

    public int? indisponivel_rede_primaria { get; set; }

    public int? disponivel_rede_primaria { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? saturacao_rede_primaria { get; set; }

    public int? capacidade_rede_secundaria { get; set; }

    public int? em_uso_rede_secundaria { get; set; }

    public int? indisponivel_rede_secundaria { get; set; }

    public int? disponivel_rede_secundaria { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? saturacao_rede_secundaria { get; set; }

    public int? qtd_predios_adequados { get; set; }

    public int? capacidade_predios_adequados { get; set; }

    public int? em_uso_predios_adequados { get; set; }

    public int? disponivel_predios_adequados { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? saturacao_predios_adequados { get; set; }

    public int? capacidade_rede_primaria_fibra { get; set; }

    public int? em_uso_rede_primaria_fibra { get; set; }

    public int? indisponivel_rede_primaria_fibra { get; set; }

    public int? disponivel_rede_primaria_fibra { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? saturacao_rede_primaria_fibra { get; set; }

    public int? capacidade_rede_secundaria_fibra { get; set; }

    public int? em_uso_rede_secundaria_fibra { get; set; }

    public int? indisponivel_rede_secundaria_fibra { get; set; }

    public int? disponivel_rede_secundaria_fibra { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? saturacao_rede_secundaria_fibra { get; set; }

    public int? qtd_predios_adequados_fibra { get; set; }

    public int? em_uso_predios_adequados_fibra { get; set; }

    public int? disponivel_predios_adequados_fibra { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? saturacao_predios_adequados_fibra { get; set; }

    public int? capacidade_predios_adequados_fibra { get; set; }
}