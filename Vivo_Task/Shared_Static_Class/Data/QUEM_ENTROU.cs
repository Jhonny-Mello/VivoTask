﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Keyless]
[Table("QUEM_ENTROU")]
public partial class QUEM_ENTROU
{
    [Required]
    [Unicode(false)]
    public string Login { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Data { get; set; }
}