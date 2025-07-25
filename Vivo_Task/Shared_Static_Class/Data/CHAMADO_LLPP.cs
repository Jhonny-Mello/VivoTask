﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Table("CHAMADO_LLPP")]
public partial class CHAMADO_LLPP
{
    [Key]
    public int id { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Chamado { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Ddd { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Rede { get; set; }

    [Required]
    [StringLength(255)]
    [Unicode(false)]
    public string Tipo { get; set; }

    [Required]
    [Unicode(false)]
    public string Descricao { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string DataAbertura { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string DataPrevisaoEncerramento { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string DataEncerramento { get; set; }

    public int idAcesso { get; set; }

    [ForeignKey("idAcesso")]
    [InverseProperty("CHAMADO_LLPPs")]
    public virtual ACESSO idAcessoNavigation { get; set; }
}