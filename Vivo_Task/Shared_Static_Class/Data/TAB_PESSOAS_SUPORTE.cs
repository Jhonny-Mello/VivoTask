﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Table("TAB_PESSOAS_SUPORTE")]
public partial class TAB_PESSOAS_SUPORTE
{
    public double? MATRÍCULA { get; set; }

    [StringLength(255)]
    public string NAME { get; set; }

    [StringLength(255)]
    public string CARGO { get; set; }

    [StringLength(255)]
    public string EMAIL { get; set; }

    public double? TELEFONE { get; set; }

    [Key]
    public int ID { get; set; }
}