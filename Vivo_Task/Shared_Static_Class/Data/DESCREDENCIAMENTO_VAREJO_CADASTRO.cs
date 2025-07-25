﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Table("DESCREDENCIAMENTO_VAREJO_CADASTRO")]
public partial class DESCREDENCIAMENTO_VAREJO_CADASTRO
{
    [Key]
    public int ID { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ADABAS { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string TIPO_DESCREDENCIAMENTO { get; set; }

    [StringLength(550)]
    [Unicode(false)]
    public string MOTIVO { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DATA_CADASTRO { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string IDACESSO { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string CANCELADO { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string SITUACAO { get; set; }
}