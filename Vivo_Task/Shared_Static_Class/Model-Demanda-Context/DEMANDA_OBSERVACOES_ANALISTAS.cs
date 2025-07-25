﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Vivo_Task.Shared_Static_Class.Data;

[Table("DEMANDA_OBSERVACOES_ANALISTAS", Schema = "Demandas")]
public partial class DEMANDA_OBSERVACOES_ANALISTAS
{
    public DEMANDA_OBSERVACOES_ANALISTAS(Guid iD_RELACAO, DateTime dATA, int mAT_ANALISTA, string oBSERVACAO)
    {
        ID_RELACAO = iD_RELACAO;
        DATA = dATA;
        MAT_ANALISTA = mAT_ANALISTA;
        OBSERVACAO = oBSERVACAO;
    }

    [Key]
    public Guid ID { get; set; }
    public Guid ID_RELACAO { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime DATA { get; set; }

    [Unicode(false)]
    public int MAT_ANALISTA { get; set; }
    public string OBSERVACAO { get; set; }

    [ForeignKey("ID_RELACAO")]
    [JsonIgnore]
    public virtual DEMANDA_RELACAO_CHAMADO Relacao_DEMANDA { get; set; }

    [ForeignKey("MAT_ANALISTA")]
    [JsonIgnore]
    public virtual ACESSOS_MOBILE Analista { get; set; }

}