﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Table("CHECKLIST_DESCREDENCIAMENTO_VAREJO")]
public partial class CHECKLIST_DESCREDENCIAMENTO_VAREJO
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Adabas { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string Opcao { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Data { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string Responsavel { get; set; }
}