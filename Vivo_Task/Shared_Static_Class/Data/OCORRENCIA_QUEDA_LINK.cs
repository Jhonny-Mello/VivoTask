﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Table("OCORRENCIA_QUEDA_LINK")]
public partial class OCORRENCIA_QUEDA_LINK
{
    [Key]
    public int ID { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NrChamado { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string TipoLoja { get; set; }

    [StringLength(550)]
    [Unicode(false)]
    public string NomeLoja { get; set; }

    [StringLength(550)]
    [Unicode(false)]
    public string Cidade { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string DDD { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string UF { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataInicio { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string HoraInicio { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataFim { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string HoraFim { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string TempoTotal { get; set; }

    [StringLength(550)]
    [Unicode(false)]
    public string Plantonista { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string MOTIVO_QUEDA_LINK { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string NR_INCIDENTE { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string STATUS_QUEDA_LINK { get; set; }
}