﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Table("CONTROLE_DEMANDAS_CHAT")]
public partial class CONTROLE_DEMANDAS_CHAT
{
    [Key]
    public int ID { get; set; }

    public int IdDemandas { get; set; }

    [Required]
    [StringLength(255)]
    [Unicode(false)]
    public string RESPONSAVEL { get; set; }

    [Required]
    [Unicode(false)]
    public string DESCRICAO { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DATA { get; set; }

    [ForeignKey("IdDemandas")]
    [InverseProperty("CONTROLE_DEMANDAS_CHATs")]
    public virtual CONTROLE_DEMANDAS_CADASTRO IdDemandasNavigation { get; set; }
}