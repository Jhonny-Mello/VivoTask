﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Table("REANALISE_CADASTRO")]
public partial class REANALISE_CADASTRO
{
    [Key]
    public int ID { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string UF { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string DDD { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string RAZAOSOCIAL { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CNPJ { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string TIPO { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CANAL { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DATACADASTRO { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string IDACESSO { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string LIMITE { get; set; }
}