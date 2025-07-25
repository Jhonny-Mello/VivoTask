﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Table("OCORRENCIAS_SISTEMICAS")]
public partial class OCORRENCIAS_SISTEMICA
{
    [Key]
    public int ID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DATA { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string CHAMADO { get; set; }

    [StringLength(550)]
    [Unicode(false)]
    public string IMPACTO { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string SISTEMA { get; set; }

    public TimeSpan? INICIO { get; set; }

    public TimeSpan? FIM { get; set; }

    [StringLength(550)]
    [Unicode(false)]
    public string TIPOERRO { get; set; }

    [Unicode(false)]
    public string DESCRICAOOCORRENCIA { get; set; }

    [StringLength(550)]
    [Unicode(false)]
    public string PLANTONISTA { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DATAFIM { get; set; }

    [StringLength(550)]
    [Unicode(false)]
    public string TIPO_IMPACTO { get; set; }
}