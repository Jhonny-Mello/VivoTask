﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Table("ACAO_STATUS")]
public partial class ACAO_STATUS
{
    [Key]
    public int id { get; set; }

    [Required]
    [StringLength(255)]
    [Unicode(false)]
    public string descricao { get; set; }
}