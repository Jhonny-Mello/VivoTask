﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Table("carteira_demais_canais_rede_colaborador")]
public partial class carteira_demais_canais_rede_colaborador
{
    [Key]
    [StringLength(100)]
    public string REDE { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string MATRICULA_1 { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string MATRICULA_2 { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string MATRICULA_3 { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string MATRICULA_4 { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string SAL { get; set; }

    [StringLength(10)]
    public string Uf { get; set; }

    [StringLength(30)]
    public string CANAL { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string MATRICULA_5 { get; set; }

    [StringLength(10)]
    public string MATRICULA_6 { get; set; }

    [StringLength(10)]
    public string MATRICULA_7 { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string MATRICULA_8 { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string MATRICULA_9 { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string MATRICULA_10 { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string MATRICULA_11 { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string MATRICULA_12 { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string MATRICULA_13 { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string MATRICULA_14 { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string MATRICULA_15 { get; set; }
}