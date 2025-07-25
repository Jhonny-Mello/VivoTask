﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Table("CONTROLE_DE_DEMANDAS_CHAMADO_RESPOSTA")]
[Index("ID_CHAMADO", Name = "NonClusteredIndex-20200414-145819")]
public partial class CONTROLE_DE_DEMANDAS_CHAMADO_RESPOSTum
{
    [Key]
    public int ID { get; set; }

    [Required]
    [Unicode(false)]
    public string RESPOSTA { get; set; }

    public int ID_CHAMADO { get; set; }

    [Unicode(false)]
    public string MATRICULA_RESPONSAVEL { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DATA_RESPOSTA { get; set; }

    [InverseProperty("ID_RESPOSTANavigation")]
    public virtual ICollection<CONTROLE_DEMANDAS_ARQUIVOS_RESPOSTum> CONTROLE_DEMANDAS_ARQUIVOS_RESPOSTa { get; set; } = new List<CONTROLE_DEMANDAS_ARQUIVOS_RESPOSTum>();

    [ForeignKey("ID_CHAMADO")]
    [InverseProperty("CONTROLE_DE_DEMANDAS_CHAMADO_RESPOSTa")]
    public virtual CONTROLE_DE_DEMANDAS_CHAMADO ID_CHAMADONavigation { get; set; }
}