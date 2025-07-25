﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Keyless]
public partial class V_JORNADA_LESTE
{
    public int? RE_AVALIADO { get; set; }

    [Unicode(false)]
    public string NOME_AVALIADO { get; set; }

    [StringLength(255)]
    public string CARGO_AVALIADO { get; set; }

    [StringLength(255)]
    public string CANAL_AVALIADO { get; set; }

    public int? DDD_AVALIADO { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string REGIONAL_AVALIADO { get; set; }

    [Unicode(false)]
    public string PDV_AVALIADO { get; set; }

    public bool? ELEGIVEL_AVALIADO { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string TP_STATUS_AVALIADO { get; set; }

    [Required]
    [StringLength(16)]
    [Unicode(false)]
    public string DIVISAO_AVALIADO { get; set; }

    public int ID_PROVA_RESPONDIDA { get; set; }

    public int? ID_PROVA { get; set; }

    [StringLength(255)]
    public string TP_FORMS { get; set; }

    [StringLength(255)]
    public string ID_CRIADOR { get; set; }

    [Unicode(false)]
    public string NOME_CRIADOR { get; set; }

    [StringLength(255)]
    public string CARGO_CRIADOR { get; set; }

    [Column(TypeName = "date")]
    public DateTime? DT_AVALIACAO { get; set; }

    [Column(TypeName = "date")]
    public DateTime? DT_CRIACAO { get; set; }

    [StringLength(255)]
    public string CADERNO { get; set; }

    [Column(TypeName = "decimal(4, 1)")]
    public decimal? NOTA { get; set; }
}