﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Keyless]
public partial class CNS_ACOMPANHAMENTO_CONTROLE
{
    [Required]
    [StringLength(11)]
    [Unicode(false)]
    public string TIPO_SOLICITACAO { get; set; }

    public int? QUANTIDADE { get; set; }

    public int? DENTRO_SLA { get; set; }

    public int? FECHADOS { get; set; }
}