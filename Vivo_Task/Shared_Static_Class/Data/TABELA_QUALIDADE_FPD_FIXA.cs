﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Table("TABELA_QUALIDADE_FPD_FIXA")]
public partial class TABELA_QUALIDADE_FPD_FIXA
{
    [StringLength(255)]
    public string SAFRA_ALTA { get; set; }

    [StringLength(255)]
    public string DT_ALTA { get; set; }

    [StringLength(255)]
    public string NR_DOC { get; set; }

    [StringLength(255)]
    public string ESTADO { get; set; }

    [StringLength(255)]
    public string CIDADE { get; set; }

    [StringLength(255)]
    public string LOGIN_VNDA { get; set; }

    [StringLength(255)]
    public string LOGIN_CNST { get; set; }

    [StringLength(255)]
    public string SCORE { get; set; }

    [StringLength(255)]
    public string CLASSE_SCORE { get; set; }

    [StringLength(255)]
    public string TIPO_CLIENTE { get; set; }

    [StringLength(255)]
    public string REGIONAL_INSTALACAO { get; set; }

    [StringLength(255)]
    public string REGIONAL_CNST { get; set; }

    [StringLength(255)]
    public string CANAL_TRATADO { get; set; }

    [StringLength(255)]
    public string DEALER { get; set; }

    [StringLength(255)]
    public string TECNOLOGIA { get; set; }

    [StringLength(255)]
    public string CONTA_COBRANCA { get; set; }

    [StringLength(255)]
    public string FL_FATURADO_BL { get; set; }

    [StringLength(255)]
    public string FL_FATURADO_VOZ { get; set; }

    [StringLength(255)]
    public string FL_FATURADO_TV { get; set; }

    [StringLength(255)]
    public string FL_FATURADO { get; set; }

    [StringLength(255)]
    public string F_OVER_0 { get; set; }

    [StringLength(255)]
    public string F_OVER_8 { get; set; }

    [StringLength(255)]
    public string F_OVER_15 { get; set; }

    [StringLength(255)]
    public string F_OVER_30 { get; set; }

    [StringLength(255)]
    public string F_OVER_60 { get; set; }

    [StringLength(255)]
    public string F_OVER_180 { get; set; }

    [StringLength(255)]
    public string FL_FTRM_OVER_0 { get; set; }

    [StringLength(255)]
    public string FL_FTRM_OVER_8 { get; set; }

    [StringLength(255)]
    public string FL_FTRM_OVER_15 { get; set; }

    [StringLength(255)]
    public string FL_FTRM_OVER_30 { get; set; }

    [StringLength(255)]
    public string FL_FTRM_OVER_60 { get; set; }

    [StringLength(255)]
    public string FL_FTRM_OVER_180 { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string ANOMES { get; set; }

    [Key]
    public int Id { get; set; }

    [InverseProperty("IdFPDNavigation")]
    public virtual ICollection<TABELA_QUALIDADE_FPD_FIXA_STATUS> TABELA_QUALIDADE_FPD_FIXA_STATUSes { get; set; } = new List<TABELA_QUALIDADE_FPD_FIXA_STATUS>();
}